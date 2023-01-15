using System.IO;
using System.Text;

namespace Muhasebe_Defteri
{
    public partial class Form1 : Form
    {
        readonly int SidePanelHideWidth = 550;
        Panel CurrentPanel;

        List<Person> NewDebtPersons = new();
        //I store them as items int this empty ListBox.
        ListBox AllDebtPersons = new ListBox();

        //D:\Coding\Muhasebe Defteri\Muhasebe Defteri\bin\Debug\net6.0-windows
        readonly string pathString = Directory.GetCurrentDirectory();
        //D:\Coding\Muhasebe Defteri\Muhasebe Defteri\bin\Debug\net6.0-windows\\Info.txt
        string CurrentTxtPath;

        readonly string NameEnd = TextFormatHolder.NameEnd; //Where Name Info Ends
        readonly string DebtEnd = TextFormatHolder.DebtEnd; //Where Basic Debt Info Ends

        public Form1()
        {
            InitializeComponent();
            CurrentPanel = this.PanelEntry;//Start panel

            Directory.CreateDirectory(pathString);
            CurrentTxtPath = pathString + "\\Info.txt";

            if (!File.Exists(CurrentTxtPath))// if the app is run for the first time
            {
                using (var stream = File.Create(CurrentTxtPath))//This is required.
                {
                    Thread.Sleep(100);
                }
                Thread.Sleep(100);//These are not required but it feels safer :p
            }

            //Reads the saved file (Info.txt) and writes the info to AllDebtPersons.Items
            string[] lines = File.ReadAllLines(CurrentTxtPath);
            if (lines.Length > 0)
            {
                if (!TextIsEmpty(lines[0]))
                {
                    foreach (string line in lines)
                    {
                        AllDebtPersons.Items.Add(new Person(
                            line.Substring
                            (
                                0, (line.IndexOf(NameEnd)
                            )),
                            float.Parse(GetSubstringByString(NameEnd, DebtEnd, line)),
                            line.Substring
                            (
                                (line.IndexOf(DebtEnd)) + (DebtEnd.Length),
                                line.Length - ((line.IndexOf(DebtEnd)) + (DebtEnd.Length))
                            )));
                    }
                }
            }

            //Adds all names to current guess database
            foreach (Person DebtListItem in AllDebtPersons.Items)
            {
                TxtBoxName.AutoCompleteCustomSource.Add(DebtListItem.Name);
            }
        }

        //Calls ControllSizeAndPosOfPanels()
        private void Form1_SizeChanged(object sender, EventArgs e)
        { ControllSizeAndPosOfPanels(); }

        //Dynamicly change CurrentPanel and LeftPanel according to window size.
        private void ControllSizeAndPosOfPanels()
        {
            if (this.Width < SidePanelHideWidth)
            {
                LeftPanel.Hide();

                CurrentPanel.Width = this.Width;
                CurrentPanel.Location = new Point(0, 0);
            }
            else
            {
                LeftPanel.Show();

                CurrentPanel.Width = this.Width - 200;
                CurrentPanel.Location = new Point(200, 0);
            }
        }

        #region Left panel button clicks that call HideOtherPanels.
        private void Btn1Left_Click(object sender, EventArgs e)
        {
            SwitchPanels(1);
        }
        private void Btn2Left_Click(object sender, EventArgs e)
        {
            SwitchPanels(2);
        }
        private void Btn3Left_Click(object sender, EventArgs e)
        {
            SwitchPanels(3);
        }
        #endregion

        //Displays items that are on AllDebtPersons after updating it.
        //Also Makes only currentpanel visible
        private void SwitchPanels(int BtnClick)
        {
            this.PanelEntry.Hide();
            this.PanelDebtLogs.Hide();
            this.PanelDetailedDebtLogs.Hide();

            AddNewPersons(AllDebtPersons.Items);
            NewDebtPersons.Clear();

            //Writes items to lists and determines "CurrentPanel"
            switch (BtnClick)
            {
                case 1:
                    CurrentPanel = this.PanelEntry;
                    break;
                case 2:
                    CurrentPanel = this.PanelDebtLogs;

                    ListBoxPersons.Items.Clear();
                    ListBoxPersons.Items.AddRange(AllDebtPersons.Items);

                    UpdateTotalDebt();
                    break;
                case 3:
                    CurrentPanel = this.PanelDetailedDebtLogs;

                    ListBoxDetailedPersons.Items.Clear();
                    foreach (Person DebtListItem in AllDebtPersons.Items)
                    {
                        ListBoxDetailedPersons.Items.Add(DebtListItem + DebtListItem.Note);
                    }
                    break;
            }

            CurrentPanel.Show();
            ControllSizeAndPosOfPanels();
        }

        //Adds new persons from NewDebtPersons List to the given ObjectCollection and AutoComplete database.
        //If the person exists; adds note and the value to current person that is in ObjectCollectin.
        private void AddNewPersons(ListBox.ObjectCollection givenItems)
        {
            foreach (Person person in NewDebtPersons)
            {
                bool alreadyExists = false;

                if (givenItems.Count > 0)
                {
                    foreach (Person DebtListItem in givenItems)
                    {
                        if (person.Name == DebtListItem.Name)
                        {
                            float FinalAmmount = DebtListItem.Ammount + person.Ammount;
                            alreadyExists = true;

                            givenItems.Remove(DebtListItem);
                            givenItems.Add(
                                new Person(person.Name,
                                FinalAmmount,
                                person.Note + " + " + DebtListItem.Note));
                            break;
                        }
                    }
                }

                if (!alreadyExists)
                {
                    givenItems.Add(person);
                    TxtBoxName.AutoCompleteCustomSource.Add(person.Name);
                }
            }
        }

        //Writes AllDebtPersons.Items line by line to Info.txt
        private void SaveFiles()
        {
            ClearFile(CurrentTxtPath);

            StreamWriter sw = new StreamWriter(CurrentTxtPath, true, Encoding.UTF8);

            foreach (Person DebtListItem in AllDebtPersons.Items)
            {
                sw.WriteLine(DebtListItem + DebtListItem.Note);
            }
            sw.Close();
        }

        //Clears the content of the file that is in given path.
        private void ClearFile(string GivenFile)
        {
            TextWriter tw = new StreamWriter(GivenFile, false);
            tw.Write(string.Empty);
            tw.Close();
        }

        //Adds the new person to NewDebtPerson list and clears textbox's.
        //If the texts does not cover required parameters,
        //a message is shown and wrong texts are reset.
        private void AssignNewPerson()
        {
            bool isASuccesfull = true;

            if (TxtBoxName.Text.Contains('.') || TxtBoxName.Text.Contains(':'))
            {
                isASuccesfull = false;
                MessageBox.Show("İsim nokta (.) veya iki nokta üst üste (:) içeremez.");
                TxtBoxName.Text = "";

                TxtBoxName.Focus();
            }
            if (!Double.TryParse(TxtBoxDebt.Text, out double a))
            {
                isASuccesfull = false;
                MessageBox.Show("Borç sayı olmak zorunda.");
                TxtBoxDebt.Text = "";

                TxtBoxDebt.Focus();
            }
            if (TxtBoxNote.Text.Contains('.') || TxtBoxName.Text.Contains(':'))
            {
                isASuccesfull = false;
                MessageBox.Show("Not nokta (.) veya iki nokta üst üste (:) içeremez.");
                TxtBoxNote.Text = "";

                TxtBoxNote.Focus();
            }

            if (isASuccesfull)
            {
                NewDebtPersons.Add(new Person
                   (TxtBoxName.Text.ToUpper(),
                   float.Parse(TxtBoxDebt.Text),
                   "(" + DateTime.Today.Day + "/" + DateTime.Today.Month + "/" + DateTime.Today.Year +
                   ", " + TxtBoxDebt.Text + "TL" + ") " + TxtBoxNote.Text));

                TxtBoxName.Text = "";
                TxtBoxDebt.Text = "";
                TxtBoxNote.Text = "";
            }
        }

        //Gets the string in the middle of the First and Second
        public string GetSubstringByString(string First, string Second, string GivenText)
        {
            return GivenText.Substring(
                (GivenText.IndexOf(First) + First.Length),
                (GivenText.IndexOf(Second) - (GivenText.IndexOf(First) + First.Length)));
        }

        //Deletes Selected Debt
        private void deleteSelectedDebt(object sender, EventArgs e)
        {
            AllDebtPersons.Items.Remove(ListBoxPersons.SelectedItem);
            ListBoxPersons.Items.Remove(ListBoxPersons.SelectedItem);
            ListBoxDetailedPersons.Items.Remove(ListBoxPersons.SelectedItem);

            UpdateTotalDebt();
        }

        //Updates the total debt label in secondpanel
        void UpdateTotalDebt()
        {
            float TotalDebt = 0;
            foreach (Person DebtListItem in AllDebtPersons.Items)
            {
                TotalDebt += DebtListItem.Ammount;
            }

            LabelTotalAmmount.Text = TotalDebt + "";
        }

        bool TextIsEmpty(string input)
        {
            return (input == "" || input == " " || input == null || input == String.Empty);
        }

        //Saves automatically when closed
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            SaveFiles();
            base.OnFormClosed(e);
        }
        
        #region Enter and arrow key functionality when PanelEntry is selected
        private void BtnAssign_Click(object sender, EventArgs e)
        {
            AssignNewPerson();
        }
        private void TxtBoxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(TextIsEmpty(TxtBoxDebt.Text))
                {
                    TxtBoxDebt.Focus();
                }
                else
                {
                    AssignNewPerson();
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                TxtBoxDebt.Focus();
            }
        }
        private void TxtBoxDebt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AssignNewPerson();
            }
            else if (e.KeyCode == Keys.Up)
            {
                TxtBoxName.Focus();
            }
            else if(e.KeyCode == Keys.Down)
            {
                TxtBoxNote.Focus();
            }
        }
        private void TxtBoxNote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AssignNewPerson();
            }
            else if (e.KeyCode == Keys.Up)
            {
                TxtBoxDebt.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                BtnAssign.Focus();
            }
        }
        #endregion
    }
}