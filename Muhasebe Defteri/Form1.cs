using System.IO;
using System.Text;

namespace Muhasebe_Defteri
{
    public partial class Form1 : Form
    {
        readonly int SidePanelHideWidth = 550;
        Panel CurrentPanel;

        List<Person> NewDebtPersons = new();
        //I store them as items.
        ListBox AllDebtPersons = new ListBox();

        //D:\Coding\Muhasebe Defteri\Muhasebe Defteri\bin\Debug\net6.0-windows
        readonly string pathString = Directory.GetCurrentDirectory();
        string CurrentTxtPath;

        public Form1()
        {
            InitializeComponent();
            CurrentPanel = this.PanelEntry;//Start panel

            Directory.CreateDirectory(pathString);
            CurrentTxtPath = pathString + "\\Info.txt";

            if (!File.Exists(CurrentTxtPath))// if the app is run for the first time
                File.Create(CurrentTxtPath);

            //Reads the saved file (Info.txt) and writes the info to AllDebtPersons.Items
            string[] lines = File.ReadAllLines(CurrentTxtPath);
            foreach (string line in lines)
            {
                AllDebtPersons.Items.Add(new Person(
                    line.Substring
                    (
                        0, (line.IndexOf(": ")
                    )),
                    float.Parse(GetSubstringByString(": ", ".", line)),
                    line.Substring
                    ((
                        line.IndexOf(". ")) + (". ".Length),
                        line.Length - (line.IndexOf(". ")) - (". ".Length
                    ))
                    ));
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
            HideOtherPanels(1);
        }
        private void Btn2Left_Click(object sender, EventArgs e)
        {
            HideOtherPanels(2);
        }
        private void Btn3Left_Click(object sender, EventArgs e)
        {
            HideOtherPanels(3);
        }
        private void Btn4Left_Click(object sender, EventArgs e)
        {
            HideOtherPanels(4);
        }
        private void Btn5Left_Click(object sender, EventArgs e)
        {
            HideOtherPanels(5);
        }
        #endregion

        //Displays items that are on AllDebtPersons after updating it.
        //Also Makes only currentpanel visible
        private void HideOtherPanels(int BtnClick)
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
                case 4:

                    break;
                case 5:
                    SaveFiles();
                    break;
            }

            CurrentPanel.Show();
            ControllSizeAndPosOfPanels();
        }

        //Adds new persons from NewDebtPersons List to the given ObjectCollection
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
            if (!File.Exists(GivenFile))
                File.Create(GivenFile);

            TextWriter tw = new StreamWriter(GivenFile, false);
            tw.Write(string.Empty);
            tw.Close();
        }

        //Adds the new person to NewDebtPerson list and clears textbox's.
        //If the texts does not cover required parameters,
        //a message is shown and wrong texts are reset.
        private void BtnAssign_Click(object sender, EventArgs e)
        {
            bool isASuccesfull = true;

            if (TxtBoxName.Text.Contains('.'))
            {
                isASuccesfull = false;
                MessageBox.Show("İsim nokta (.) veya iki nokta üst üste (:) içeremez.");
                TxtBoxName.Text = "";
            }
            if (Double.TryParse(TxtBoxDebt.Text, out double a))
            {
                isASuccesfull = false;
                MessageBox.Show("Borç sayı olmak zorunda.");
                TxtBoxDebt.Text = "";
            }
            if (TxtBoxNote.Text.Contains(':'))
            {
                isASuccesfull = false;
                MessageBox.Show("Not nokta (.) veya iki nokta üst üste (:) içeremez.");
                TxtBoxNote.Text = "";
            }

            if (isASuccesfull)
            {
                NewDebtPersons.Add(new Person
                   (TxtBoxName.Text,
                   float.Parse(TxtBoxDebt.Text),
                   TxtBoxNote.Text));

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
                (GivenText.IndexOf(Second) - GivenText.IndexOf(First) - First.Length));
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
    }
}