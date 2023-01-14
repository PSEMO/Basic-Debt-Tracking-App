namespace Muhasebe_Defteri
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.Btn5Left = new System.Windows.Forms.Button();
            this.Btn4Left = new System.Windows.Forms.Button();
            this.Btn3Left = new System.Windows.Forms.Button();
            this.Btn2Left = new System.Windows.Forms.Button();
            this.Btn1Left = new System.Windows.Forms.Button();
            this.PanelEntry = new System.Windows.Forms.Panel();
            this.TxtBoxNote = new System.Windows.Forms.TextBox();
            this.LabelNote = new System.Windows.Forms.Label();
            this.TxtBoxDebt = new System.Windows.Forms.TextBox();
            this.TxtBoxName = new System.Windows.Forms.TextBox();
            this.LabelDebt = new System.Windows.Forms.Label();
            this.LabeName = new System.Windows.Forms.Label();
            this.BtnAddDebt = new System.Windows.Forms.Button();
            this.PanelDebtLogs = new System.Windows.Forms.Panel();
            this.TotalPanel = new System.Windows.Forms.Panel();
            this.LabelTotal = new System.Windows.Forms.Label();
            this.LabelTotalAmmount = new System.Windows.Forms.Label();
            this.BtnDeleteSelectedDebt = new System.Windows.Forms.Button();
            this.ListBoxPersons = new System.Windows.Forms.ListBox();
            this.PanelDetailedDebtLogs = new System.Windows.Forms.Panel();
            this.ListBoxDetailedPersons = new System.Windows.Forms.ListBox();
            this.LeftPanel.SuspendLayout();
            this.PanelEntry.SuspendLayout();
            this.PanelDebtLogs.SuspendLayout();
            this.TotalPanel.SuspendLayout();
            this.PanelDetailedDebtLogs.SuspendLayout();
            this.SuspendLayout();
            // 
            // LeftPanel
            // 
            this.LeftPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LeftPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.LeftPanel.Controls.Add(this.Btn5Left);
            this.LeftPanel.Controls.Add(this.Btn4Left);
            this.LeftPanel.Controls.Add(this.Btn3Left);
            this.LeftPanel.Controls.Add(this.Btn2Left);
            this.LeftPanel.Controls.Add(this.Btn1Left);
            this.LeftPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LeftPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftPanel.Margin = new System.Windows.Forms.Padding(0);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(200, 441);
            this.LeftPanel.TabIndex = 0;
            // 
            // Btn5Left
            // 
            this.Btn5Left.Location = new System.Drawing.Point(10, 239);
            this.Btn5Left.Name = "Btn5Left";
            this.Btn5Left.Size = new System.Drawing.Size(180, 50);
            this.Btn5Left.TabIndex = 4;
            this.Btn5Left.Text = "Kaydet";
            this.Btn5Left.UseVisualStyleBackColor = true;
            this.Btn5Left.Click += new System.EventHandler(this.Btn5Left_Click);
            // 
            // Btn4Left
            // 
            this.Btn4Left.Location = new System.Drawing.Point(10, 183);
            this.Btn4Left.Name = "Btn4Left";
            this.Btn4Left.Size = new System.Drawing.Size(180, 50);
            this.Btn4Left.TabIndex = 3;
            this.Btn4Left.Text = "button4";
            this.Btn4Left.UseVisualStyleBackColor = true;
            this.Btn4Left.Click += new System.EventHandler(this.Btn4Left_Click);
            // 
            // Btn3Left
            // 
            this.Btn3Left.Location = new System.Drawing.Point(10, 127);
            this.Btn3Left.Name = "Btn3Left";
            this.Btn3Left.Size = new System.Drawing.Size(180, 50);
            this.Btn3Left.TabIndex = 2;
            this.Btn3Left.Text = "Detaylı Borç Girdileri";
            this.Btn3Left.UseVisualStyleBackColor = true;
            this.Btn3Left.Click += new System.EventHandler(this.Btn3Left_Click);
            // 
            // Btn2Left
            // 
            this.Btn2Left.Location = new System.Drawing.Point(10, 71);
            this.Btn2Left.Name = "Btn2Left";
            this.Btn2Left.Size = new System.Drawing.Size(180, 50);
            this.Btn2Left.TabIndex = 1;
            this.Btn2Left.Text = "Borçlular";
            this.Btn2Left.UseVisualStyleBackColor = true;
            this.Btn2Left.Click += new System.EventHandler(this.Btn2Left_Click);
            // 
            // Btn1Left
            // 
            this.Btn1Left.Location = new System.Drawing.Point(10, 15);
            this.Btn1Left.Name = "Btn1Left";
            this.Btn1Left.Size = new System.Drawing.Size(180, 50);
            this.Btn1Left.TabIndex = 0;
            this.Btn1Left.Text = "Alacak paneli";
            this.Btn1Left.UseVisualStyleBackColor = true;
            this.Btn1Left.Click += new System.EventHandler(this.Btn1Left_Click);
            // 
            // PanelEntry
            // 
            this.PanelEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.PanelEntry.BackColor = System.Drawing.Color.DarkGray;
            this.PanelEntry.Controls.Add(this.TxtBoxNote);
            this.PanelEntry.Controls.Add(this.LabelNote);
            this.PanelEntry.Controls.Add(this.TxtBoxDebt);
            this.PanelEntry.Controls.Add(this.TxtBoxName);
            this.PanelEntry.Controls.Add(this.LabelDebt);
            this.PanelEntry.Controls.Add(this.LabeName);
            this.PanelEntry.Controls.Add(this.BtnAddDebt);
            this.PanelEntry.Location = new System.Drawing.Point(200, 0);
            this.PanelEntry.Name = "PanelEntry";
            this.PanelEntry.Size = new System.Drawing.Size(584, 441);
            this.PanelEntry.TabIndex = 2;
            // 
            // TxtBoxNote
            // 
            this.TxtBoxNote.Location = new System.Drawing.Point(20, 154);
            this.TxtBoxNote.Name = "TxtBoxNote";
            this.TxtBoxNote.Size = new System.Drawing.Size(135, 23);
            this.TxtBoxNote.TabIndex = 5;
            // 
            // LabelNote
            // 
            this.LabelNote.AutoSize = true;
            this.LabelNote.Location = new System.Drawing.Point(29, 136);
            this.LabelNote.Name = "LabelNote";
            this.LabelNote.Size = new System.Drawing.Size(61, 15);
            this.LabelNote.TabIndex = 4;
            this.LabelNote.Text = "Borç Notu";
            // 
            // TxtBoxDebt
            // 
            this.TxtBoxDebt.Location = new System.Drawing.Point(20, 98);
            this.TxtBoxDebt.Name = "TxtBoxDebt";
            this.TxtBoxDebt.Size = new System.Drawing.Size(135, 23);
            this.TxtBoxDebt.TabIndex = 3;
            // 
            // TxtBoxName
            // 
            this.TxtBoxName.Location = new System.Drawing.Point(20, 42);
            this.TxtBoxName.Name = "TxtBoxName";
            this.TxtBoxName.Size = new System.Drawing.Size(135, 23);
            this.TxtBoxName.TabIndex = 2;
            // 
            // LabelDebt
            // 
            this.LabelDebt.AutoSize = true;
            this.LabelDebt.Location = new System.Drawing.Point(29, 80);
            this.LabelDebt.Name = "LabelDebt";
            this.LabelDebt.Size = new System.Drawing.Size(71, 15);
            this.LabelDebt.TabIndex = 1;
            this.LabelDebt.Text = "Borç Miktarı";
            // 
            // LabeName
            // 
            this.LabeName.AutoSize = true;
            this.LabeName.Location = new System.Drawing.Point(29, 24);
            this.LabeName.Name = "LabeName";
            this.LabeName.Size = new System.Drawing.Size(29, 15);
            this.LabeName.TabIndex = 0;
            this.LabeName.Text = "İsim";
            // 
            // BtnAddDebt
            // 
            this.BtnAddDebt.Location = new System.Drawing.Point(30, 200);
            this.BtnAddDebt.Name = "BtnAddDebt";
            this.BtnAddDebt.Size = new System.Drawing.Size(115, 23);
            this.BtnAddDebt.TabIndex = 6;
            this.BtnAddDebt.Text = "Borcu işle";
            this.BtnAddDebt.UseVisualStyleBackColor = true;
            this.BtnAddDebt.Click += new System.EventHandler(this.BtnAssign_Click);
            // 
            // PanelDebtLogs
            // 
            this.PanelDebtLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.PanelDebtLogs.BackColor = System.Drawing.SystemColors.ControlDark;
            this.PanelDebtLogs.Controls.Add(this.TotalPanel);
            this.PanelDebtLogs.Controls.Add(this.BtnDeleteSelectedDebt);
            this.PanelDebtLogs.Controls.Add(this.ListBoxPersons);
            this.PanelDebtLogs.Location = new System.Drawing.Point(200, 0);
            this.PanelDebtLogs.Margin = new System.Windows.Forms.Padding(0);
            this.PanelDebtLogs.Name = "PanelDebtLogs";
            this.PanelDebtLogs.Size = new System.Drawing.Size(584, 441);
            this.PanelDebtLogs.TabIndex = 3;
            this.PanelDebtLogs.Visible = false;
            // 
            // TotalPanel
            // 
            this.TotalPanel.BackColor = System.Drawing.SystemColors.Info;
            this.TotalPanel.Controls.Add(this.LabelTotal);
            this.TotalPanel.Controls.Add(this.LabelTotalAmmount);
            this.TotalPanel.Location = new System.Drawing.Point(252, 166);
            this.TotalPanel.Name = "TotalPanel";
            this.TotalPanel.Size = new System.Drawing.Size(74, 57);
            this.TotalPanel.TabIndex = 4;
            // 
            // LabelTotal
            // 
            this.LabelTotal.AutoSize = true;
            this.LabelTotal.Location = new System.Drawing.Point(13, 12);
            this.LabelTotal.Name = "LabelTotal";
            this.LabelTotal.Size = new System.Drawing.Size(49, 15);
            this.LabelTotal.TabIndex = 2;
            this.LabelTotal.Text = "Toplam:";
            // 
            // LabelTotalAmmount
            // 
            this.LabelTotalAmmount.AutoSize = true;
            this.LabelTotalAmmount.ForeColor = System.Drawing.Color.Red;
            this.LabelTotalAmmount.Location = new System.Drawing.Point(28, 34);
            this.LabelTotalAmmount.Margin = new System.Windows.Forms.Padding(0);
            this.LabelTotalAmmount.Name = "LabelTotalAmmount";
            this.LabelTotalAmmount.Size = new System.Drawing.Size(13, 15);
            this.LabelTotalAmmount.TabIndex = 3;
            this.LabelTotalAmmount.Text = "0";
            this.LabelTotalAmmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnDeleteSelectedDebt
            // 
            this.BtnDeleteSelectedDebt.Location = new System.Drawing.Point(252, 245);
            this.BtnDeleteSelectedDebt.Name = "BtnDeleteSelectedDebt";
            this.BtnDeleteSelectedDebt.Size = new System.Drawing.Size(74, 39);
            this.BtnDeleteSelectedDebt.TabIndex = 1;
            this.BtnDeleteSelectedDebt.Text = "Seçili borcu sil";
            this.BtnDeleteSelectedDebt.UseVisualStyleBackColor = true;
            this.BtnDeleteSelectedDebt.Click += new System.EventHandler(this.deleteSelectedDebt);
            // 
            // ListBoxPersons
            // 
            this.ListBoxPersons.FormattingEnabled = true;
            this.ListBoxPersons.ItemHeight = 15;
            this.ListBoxPersons.Location = new System.Drawing.Point(20, 15);
            this.ListBoxPersons.Name = "ListBoxPersons";
            this.ListBoxPersons.Size = new System.Drawing.Size(204, 289);
            this.ListBoxPersons.TabIndex = 0;
            this.ListBoxPersons.SelectedIndexChanged += new System.EventHandler(this.ListBoxPersons_SelectedIndexChanged);
            // 
            // PanelDetailedDebtLogs
            // 
            this.PanelDetailedDebtLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.PanelDetailedDebtLogs.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.PanelDetailedDebtLogs.Controls.Add(this.ListBoxDetailedPersons);
            this.PanelDetailedDebtLogs.Location = new System.Drawing.Point(200, 0);
            this.PanelDetailedDebtLogs.Name = "PanelDetailedDebtLogs";
            this.PanelDetailedDebtLogs.Size = new System.Drawing.Size(584, 441);
            this.PanelDetailedDebtLogs.TabIndex = 4;
            this.PanelDetailedDebtLogs.Visible = false;
            // 
            // ListBoxDetailedPersons
            // 
            this.ListBoxDetailedPersons.FormattingEnabled = true;
            this.ListBoxDetailedPersons.ItemHeight = 15;
            this.ListBoxDetailedPersons.Location = new System.Drawing.Point(20, 15);
            this.ListBoxDetailedPersons.Name = "ListBoxDetailedPersons";
            this.ListBoxDetailedPersons.Size = new System.Drawing.Size(450, 289);
            this.ListBoxDetailedPersons.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 441);
            this.Controls.Add(this.LeftPanel);
            this.Controls.Add(this.PanelDebtLogs);
            this.Controls.Add(this.PanelEntry);
            this.Controls.Add(this.PanelDetailedDebtLogs);
            this.MinimumSize = new System.Drawing.Size(400, 350);
            this.Name = "Form1";
            this.Text = "Muhasebe Defteri";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.LeftPanel.ResumeLayout(false);
            this.PanelEntry.ResumeLayout(false);
            this.PanelEntry.PerformLayout();
            this.PanelDebtLogs.ResumeLayout(false);
            this.TotalPanel.ResumeLayout(false);
            this.TotalPanel.PerformLayout();
            this.PanelDetailedDebtLogs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button Btn1Left;
        private Button Btn2Left;
        private Button Btn3Left;
        private Button Btn4Left;
        private Button Btn5Left;
        private Button BtnDeleteSelectedDebt;
        private Button BtnAddDebt;
        private Label LabeName;
        private Label LabelDebt;
        private Label LabelNote;
        private Label LabelTotal;
        private Label LabelTotalAmmount;
        private TextBox TxtBoxNote;
        private TextBox TxtBoxDebt;
        private TextBox TxtBoxName;
        private ListBox ListBoxPersons;
        private ListBox ListBoxDetailedPersons;
        private Panel LeftPanel;
        private Panel PanelEntry;
        private Panel PanelDebtLogs;
        private Panel PanelDetailedDebtLogs;
        private Panel TotalPanel;
    }
}