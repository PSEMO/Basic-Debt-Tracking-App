using System.IO;
using System.Text;

namespace Muhasebe_Defteri
{
    public partial class Form1 : Form
    {
        readonly int SidePanelHideWidth = 550;
        Panel CurrentPanel;

        List<Person> NewIndebtedPersons = new();
        //I store them as items in this empty ListBox.
        ListBox AllIndebtedPersons = new ();


        List<Person> NewPayeePersons = new();
        //I store them as items in this empty ListBox.
        ListBox AllPayeePersons = new ();

        //D:\Coding\Muhasebe Defteri\Muhasebe Defteri\bin\Debug\net6.0-windows
        readonly string pathString = Directory.GetCurrentDirectory();
        //D:\Coding\Muhasebe Defteri\Muhasebe Defteri\bin\Debug\net6.0-windows\\Info.txt
        string CurrentTxtPath;

        readonly string NameEnd = TextFormatHolder.NameEnd; //Where Name Info Ends
        readonly string DebtEnd = TextFormatHolder.DebtEnd; //Where Basic Debt Info Ends
        readonly string SecondPhase = TextFormatHolder.SecondFase; //Where Second Phase Starts on Save File

        bool isReadingPayee = false;

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

            //Reads the saved file (Info.txt) and writes the info to AllIndebtedPersons and AllPayeePersons
            string[] lines = File.ReadAllLines(CurrentTxtPath);
            if (lines.Length > 0)
            {
                if (!TextIsEmpty(lines[0]))
                {
                    foreach (string line in lines)
                    {
                        if(line != SecondPhase && !isReadingPayee)
                        {
                            AllIndebtedPersons.Items.Add(new Person(
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
                        else
                        {
                            if(isReadingPayee)//This does not run the code when we just found the "NEXT:"
                            {
                                AllPayeePersons.Items.Add(new Person(
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
                            isReadingPayee = true;
                        }
                    }
                }
            }

            //Adds all names to current guess databases
            {
                foreach (Person IndebtedListItem in AllIndebtedPersons.Items)
                {
                    TxtBoxName.AutoCompleteCustomSource.Add(IndebtedListItem.Name);
                }
                foreach (Person PayeeListItem in AllPayeePersons.Items)
                {
                    TxtBoxName.AutoCompleteCustomSource.Add(PayeeListItem.Name);
                }
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

        #region Left panel button clicks that call SwitchPanels.
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
        private void Btn4Left_Click(object sender, EventArgs e)
        {
            SwitchPanels(4);
        }
        private void Btn5Left_Click(object sender, EventArgs e)
        {
            SwitchPanels(5);
        }
        private void Btn6Left_Click(object sender, EventArgs e)
        {
            SwitchPanels(6);
        }
        #endregion

        //Displays items that are on AllDebtPersons after updating it.
        //Also Makes only currentpanel visible
        private void SwitchPanels(int BtnClick)
        {
            this.PanelEntry.Hide();
            this.PanelIndebtLogs.Hide();
            this.PanelDetailedIndebtLogs.Hide();
            this.panelPayees.Hide();
            this.Payees.Hide();
            this.panelPayeesDetailed.Hide();

            AddNewPersons(AllIndebtedPersons.Items, NewIndebtedPersons);
            NewIndebtedPersons.Clear();
            AddNewPersons(AllPayeePersons.Items, NewPayeePersons);
            NewPayeePersons.Clear();

            //Writes items to lists and determines "CurrentPanel"
            switch (BtnClick)
            {
                case 1:
                    CurrentPanel = this.PanelEntry;
                    break;
                case 2:
                    CurrentPanel = this.PanelIndebtLogs;

                    ListBoxPersons1.Items.Clear();
                    ListBoxPersons1.Items.AddRange(AllIndebtedPersons.Items);

                    UpdateTotalDebt(AllIndebtedPersons, LabelTotalAmmount);
                    break;
                case 3:
                    CurrentPanel = this.PanelDetailedIndebtLogs;

                    ListBoxDetailedPersons.Items.Clear();
                    foreach (Person DebtListItem in AllIndebtedPersons.Items)
                    {
                        ListBoxDetailedPersons.Items.Add(DebtListItem + DebtListItem.Note);
                    }
                    break;
                case 4:
                    CurrentPanel = this.panelPayees;
                    break;
                case 5:
                    CurrentPanel = this.Payees;

                    ListBoxPersons2.Items.Clear();
                    ListBoxPersons2.Items.AddRange(AllPayeePersons.Items);

                    UpdateTotalDebt(AllPayeePersons, LabelTotalAmmount2);
                    break;
                case 6:
                    CurrentPanel = this.panelPayeesDetailed;

                    ListBoxDetailedPersons2.Items.Clear();
                    foreach (Person DebtListItem in AllPayeePersons.Items)
                    {
                        ListBoxDetailedPersons2.Items.Add(DebtListItem + DebtListItem.Note);
                    }
                    break;
            }

            CurrentPanel.Show();
            ControllSizeAndPosOfPanels();
        }

        //Updates the total debt label in secondpanel
        static void UpdateTotalDebt(ListBox items, Label WriteTo)
        {
            float TotalDebt = 0;
            foreach (Person DebtListItem in items.Items)
            {
                TotalDebt += DebtListItem.Ammount;
            }

            WriteTo.Text = TotalDebt + "";
        }

        //Adds new persons from NewDebtPersons List to the given ObjectCollection and AutoComplete database.
        //If the person exists; adds note and the value to current person that is in ObjectCollectin.
        private void AddNewPersons(ListBox.ObjectCollection givenItems, List<Person> NewPersons)
        {
            if(NewPersons.Count > 0)
            {
                foreach (Person person in NewPersons)
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
        }

        //Writes All???Persons.Items line by line to Info.txt
        private void SaveFiles()
        {
            AddNewPersons(AllIndebtedPersons.Items, NewIndebtedPersons);
            NewIndebtedPersons.Clear();
            AddNewPersons(AllPayeePersons.Items, NewPayeePersons);
            NewPayeePersons.Clear();

            ClearFile(CurrentTxtPath);

            StreamWriter sw = new (CurrentTxtPath, true, Encoding.UTF8);

            foreach (Person DebtListItem in AllIndebtedPersons.Items)
            {
                sw.WriteLine(DebtListItem + DebtListItem.Note);
            }
            sw.WriteLine("NEXT:");
            foreach (Person DebtListItem in AllPayeePersons.Items)
            {
                sw.WriteLine(DebtListItem + DebtListItem.Note);
            }
            sw.Close();
        }

        //Clears the content of the file that is in given path.
        static private void ClearFile(string GivenFile)
        {
            TextWriter tw = new StreamWriter(GivenFile, false);
            tw.Write(string.Empty);
            tw.Close();
        }

        //Gets the string in the middle of the First and Second
        static public string GetSubstringByString(string First, string Second, string GivenText)
        {
            return GivenText.Substring(
                (GivenText.IndexOf(First) + First.Length),
                (GivenText.IndexOf(Second) - (GivenText.IndexOf(First) + First.Length)));
        }

        //Checks if the given text is empty
        static bool TextIsEmpty(string input)
        {
            return (input == "" || input == " " || input == null || input == String.Empty);
        }

        //Saves automatically when closed
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            SaveFiles();
            base.OnFormClosed(e);
        }

        //Adds the new person to one of the "New" lists and clears textbox's.
        //If the texts does not cover required parameters,
        //a message is shown and wrong texts are reset and are selected.
        private void AssignNewPerson(int x)
        {
            TextBox a;
            TextBox b;
            TextBox c;

            if(x == 1)
            {
                a = TxtBoxName;
                b = TxtBoxIndebt;
                c = TxtBoxNote;
            }
            else
            {
                a = TxtBoxName2;
                b = TxtBoxIndebt2;
                c = TxtBoxNote2;
            }

            bool isASuccesfull = true;

            if (a.Text.Contains('.') || a.Text.Contains(':'))
            {
                isASuccesfull = false;
                MessageBox.Show("İsim nokta (.) veya iki nokta üst üste (:) içeremez.");
                a.Text = "";

                a.Focus();
            }
            if (!Double.TryParse(b.Text, out double garbage))
            {
                isASuccesfull = false;
                MessageBox.Show("Borç sayı olmak zorunda.");
                b.Text = "";

                b.Focus();
            }
            if (c.Text.Contains('.') || c.Text.Contains(':'))
            {
                isASuccesfull = false;
                MessageBox.Show("Not nokta (.) veya iki nokta üst üste (:) içeremez.");
                c.Text = "";

                c.Focus();
            }

            if (isASuccesfull)
            {
                if(x == 1)
                {
                    NewIndebtedPersons.Add(new Person
                       (a.Text.ToUpper(),
                       float.Parse(b.Text),
                       "(" + DateTime.Today.ToShortDateString() + ", " +
                       b.Text + "TL" + ") " + c.Text));

                    a.Text = "";
                    b.Text = "";
                    c.Text = "";
                }
                else
                {
                    NewPayeePersons.Add(new Person
                      (a.Text.ToUpper(),
                      float.Parse(b.Text),
                      "(" + DateTime.Today.ToShortDateString() + ", " +
                      b.Text + "TL" + ") " + c.Text));

                    a.Text = "";
                    b.Text = "";
                    c.Text = "";
                }

            }
        }

        //Deletes Selected Debt
        private void DeleteSelectedIndebt(object sender, EventArgs e)
        {
            AllIndebtedPersons.Items.Remove(ListBoxPersons1.SelectedItem);
            ListBoxPersons1.Items.Remove(ListBoxPersons1.SelectedItem);
            ListBoxDetailedPersons.Items.Remove(ListBoxPersons1.SelectedItem);

            UpdateTotalDebt(AllIndebtedPersons, LabelTotalAmmount);
        }
        //Deletes Selected Debt
        private void DeleteSelectedPayee(object sender, EventArgs e)
        {
            AllPayeePersons.Items.Remove(ListBoxPersons2.SelectedItem);
            ListBoxPersons2.Items.Remove(ListBoxPersons2.SelectedItem);
            ListBoxDetailedPersons2.Items.Remove(ListBoxPersons2.SelectedItem);

            UpdateTotalDebt(AllPayeePersons, LabelTotalAmmount2);
        }

        #region Enter and arrow key functionalities for 1
        private void BtnAssign_Click(object sender, EventArgs e)
        {
            AssignNewPerson(1);
        }
        private void TxtBoxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(TextIsEmpty(TxtBoxIndebt.Text))
                {
                    TxtBoxIndebt.Focus();
                }
                else
                {
                    AssignNewPerson(1);
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                TxtBoxIndebt.Focus();
            }
        }
        private void TxtBoxIndebt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AssignNewPerson(1);
                TxtBoxName.Focus();
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
                AssignNewPerson(1);
            }
            else if (e.KeyCode == Keys.Up)
            {
                TxtBoxIndebt.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                BtnAssign.Focus();
            }
        }
        #endregion

        #region Enter and arrow key functionalities for 2
        private void Button2_Click(object sender, EventArgs e)
        {
            AssignNewPerson(2);
        }
        private void TxtBoxName2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TextIsEmpty(TxtBoxIndebt2.Text))
                {
                    TxtBoxIndebt2.Focus();
                }
                else
                {
                    AssignNewPerson(2);
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                TxtBoxIndebt2.Focus();
            }
        }
        private void TxtBoxIndebt2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AssignNewPerson(2);
                TxtBoxName2.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                TxtBoxName2.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                TxtBoxNote2.Focus();
            }
        }
        private void TxtBoxNote2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AssignNewPerson(2);
            }
            else if (e.KeyCode == Keys.Up)
            {
                TxtBoxIndebt2.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                BtnAssign2.Focus();
            }
        }
        #endregion
    }
}