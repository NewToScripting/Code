namespace MeetingSpaceExportService
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_GetMtgSpace = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.text_UserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.text_EventKey = new System.Windows.Forms.TextBox();
            this.text_Password = new System.Windows.Forms.TextBox();
            this.text_PropertyKey = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.text_OutputFile = new System.Windows.Forms.TextBox();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.text_ServiceURL = new System.Windows.Forms.TextBox();
            this.btn_ViewOutput = new System.Windows.Forms.Button();
            this.btn_GetMtgSpaceChar = new System.Windows.Forms.Button();
            this.radio_PostSkip = new System.Windows.Forms.RadioButton();
            this.radio_PostNo = new System.Windows.Forms.RadioButton();
            this.radio_PostYes = new System.Windows.Forms.RadioButton();
            this.radio_ExhibitSkip = new System.Windows.Forms.RadioButton();
            this.radio_ExhibitNo = new System.Windows.Forms.RadioButton();
            this.radio_ExhibitYes = new System.Windows.Forms.RadioButton();
            this.timeEnd = new System.Windows.Forms.DateTimePicker();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.timeStart = new System.Windows.Forms.DateTimePicker();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
            this.text_RoomGrouping = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_GetMtgSpace
            // 
            this.btn_GetMtgSpace.Location = new System.Drawing.Point(27, 15);
            this.btn_GetMtgSpace.Name = "btn_GetMtgSpace";
            this.btn_GetMtgSpace.Size = new System.Drawing.Size(142, 23);
            this.btn_GetMtgSpace.TabIndex = 11;
            this.btn_GetMtgSpace.Text = "Get Meeting Space";
            this.toolTip1.SetToolTip(this.btn_GetMtgSpace, "Call MeetingSpaceRequest.");
            this.btn_GetMtgSpace.UseVisualStyleBackColor = true;
            this.btn_GetMtgSpace.Click += new System.EventHandler(this.btn_GetEvents_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(27, 112);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(142, 23);
            this.btn_Exit.TabIndex = 14;
            this.btn_Exit.Text = "Exit";
            this.toolTip1.SetToolTip(this.btn_Exit, "Exit");
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Event Key:";
            // 
            // text_UserName
            // 
            this.text_UserName.Location = new System.Drawing.Point(69, 29);
            this.text_UserName.Name = "text_UserName";
            this.text_UserName.Size = new System.Drawing.Size(100, 20);
            this.text_UserName.TabIndex = 1;
            this.text_UserName.Text = "TEST";
            this.toolTip1.SetToolTip(this.text_UserName, "Enter the account name to use for the transaction.");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "User Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Password:";
            // 
            // text_EventKey
            // 
            this.text_EventKey.Location = new System.Drawing.Point(97, 19);
            this.text_EventKey.Name = "text_EventKey";
            this.text_EventKey.Size = new System.Drawing.Size(191, 20);
            this.text_EventKey.TabIndex = 3;
            this.toolTip1.SetToolTip(this.text_EventKey, "Sales & Catering Event Key.");
            // 
            // text_Password
            // 
            this.text_Password.Location = new System.Drawing.Point(68, 53);
            this.text_Password.Name = "text_Password";
            this.text_Password.Size = new System.Drawing.Size(100, 20);
            this.text_Password.TabIndex = 2;
            this.text_Password.Text = "TEST_PASS";
            this.toolTip1.SetToolTip(this.text_Password, "Enter the password to use for the transaction.");
            // 
            // text_PropertyKey
            // 
            this.text_PropertyKey.Location = new System.Drawing.Point(113, 66);
            this.text_PropertyKey.Name = "text_PropertyKey";
            this.text_PropertyKey.Size = new System.Drawing.Size(100, 20);
            this.text_PropertyKey.TabIndex = 5;
            this.text_PropertyKey.Text = "3917";
            this.toolTip1.SetToolTip(this.text_PropertyKey, "Property Identifier");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Property Key:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 370);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Response xml File:";
            // 
            // text_OutputFile
            // 
            this.text_OutputFile.Location = new System.Drawing.Point(122, 367);
            this.text_OutputFile.Name = "text_OutputFile";
            this.text_OutputFile.Size = new System.Drawing.Size(363, 20);
            this.text_OutputFile.TabIndex = 9;
            this.text_OutputFile.Text = "MeetingSpaceOutput.xml";
            this.toolTip1.SetToolTip(this.text_OutputFile, "Enter an output file name for Beo response data.  If you don\'t specify a path the" +
                    "n the file is created in the application directory.");
            // 
            // btn_Browse
            // 
            this.btn_Browse.Location = new System.Drawing.Point(110, 46);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(53, 23);
            this.btn_Browse.TabIndex = 13;
            this.btn_Browse.Text = "Browse";
            this.toolTip1.SetToolTip(this.btn_Browse, "Browse for a file location to save the Beo response data to");
            this.btn_Browse.UseVisualStyleBackColor = true;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xml";
            this.saveFileDialog1.FileName = "BeoOutput.xml";
            this.saveFileDialog1.Title = "Select an xml output file for Beo response data";
            // 
            // text_ServiceURL
            // 
            this.text_ServiceURL.Location = new System.Drawing.Point(114, 40);
            this.text_ServiceURL.Name = "text_ServiceURL";
            this.text_ServiceURL.Size = new System.Drawing.Size(347, 20);
            this.text_ServiceURL.TabIndex = 10;
            this.text_ServiceURL.Text = "http://localhost:2025/MeetingSpaceProviderService/Request.asmx";
            this.toolTip1.SetToolTip(this.text_ServiceURL, "Web Service URL.");
            // 
            // btn_ViewOutput
            // 
            this.btn_ViewOutput.Location = new System.Drawing.Point(169, 46);
            this.btn_ViewOutput.Name = "btn_ViewOutput";
            this.btn_ViewOutput.Size = new System.Drawing.Size(42, 23);
            this.btn_ViewOutput.TabIndex = 21;
            this.btn_ViewOutput.Text = "View";
            this.toolTip1.SetToolTip(this.btn_ViewOutput, "Browse for a file location to save the Beo response data to");
            this.btn_ViewOutput.UseVisualStyleBackColor = true;
            this.btn_ViewOutput.Click += new System.EventHandler(this.btn_ViewOutput_Click);
            // 
            // btn_GetMtgSpaceChar
            // 
            this.btn_GetMtgSpaceChar.Location = new System.Drawing.Point(27, 44);
            this.btn_GetMtgSpaceChar.Name = "btn_GetMtgSpaceChar";
            this.btn_GetMtgSpaceChar.Size = new System.Drawing.Size(142, 23);
            this.btn_GetMtgSpaceChar.TabIndex = 22;
            this.btn_GetMtgSpaceChar.Text = "Get Meeting Space Char";
            this.toolTip1.SetToolTip(this.btn_GetMtgSpaceChar, "Call MeetingSpaceCharacteristicsRequest");
            this.btn_GetMtgSpaceChar.UseVisualStyleBackColor = true;
            this.btn_GetMtgSpaceChar.Click += new System.EventHandler(this.btn_GetMtgRooms_Click);
            // 
            // radio_PostSkip
            // 
            this.radio_PostSkip.AutoSize = true;
            this.radio_PostSkip.Checked = true;
            this.radio_PostSkip.Location = new System.Drawing.Point(3, 3);
            this.radio_PostSkip.Name = "radio_PostSkip";
            this.radio_PostSkip.Size = new System.Drawing.Size(90, 17);
            this.radio_PostSkip.TabIndex = 16;
            this.radio_PostSkip.TabStop = true;
            this.radio_PostSkip.Text = "Skip Postable";
            this.toolTip1.SetToolTip(this.radio_PostSkip, "Include all meeting space.");
            this.radio_PostSkip.UseVisualStyleBackColor = true;
            // 
            // radio_PostNo
            // 
            this.radio_PostNo.AutoSize = true;
            this.radio_PostNo.Location = new System.Drawing.Point(175, 3);
            this.radio_PostNo.Name = "radio_PostNo";
            this.radio_PostNo.Size = new System.Drawing.Size(83, 17);
            this.radio_PostNo.TabIndex = 17;
            this.radio_PostNo.TabStop = true;
            this.radio_PostNo.Text = "Postable - N";
            this.toolTip1.SetToolTip(this.radio_PostNo, "Do not include posted meeting space.");
            this.radio_PostNo.UseVisualStyleBackColor = true;
            // 
            // radio_PostYes
            // 
            this.radio_PostYes.AutoSize = true;
            this.radio_PostYes.Location = new System.Drawing.Point(93, 3);
            this.radio_PostYes.Name = "radio_PostYes";
            this.radio_PostYes.Size = new System.Drawing.Size(82, 17);
            this.radio_PostYes.TabIndex = 18;
            this.radio_PostYes.TabStop = true;
            this.radio_PostYes.Text = "Postable - Y";
            this.toolTip1.SetToolTip(this.radio_PostYes, "Inlclude posted meeting space.");
            this.radio_PostYes.UseVisualStyleBackColor = true;
            // 
            // radio_ExhibitSkip
            // 
            this.radio_ExhibitSkip.AutoSize = true;
            this.radio_ExhibitSkip.Checked = true;
            this.radio_ExhibitSkip.Location = new System.Drawing.Point(3, 3);
            this.radio_ExhibitSkip.Name = "radio_ExhibitSkip";
            this.radio_ExhibitSkip.Size = new System.Drawing.Size(80, 17);
            this.radio_ExhibitSkip.TabIndex = 16;
            this.radio_ExhibitSkip.TabStop = true;
            this.radio_ExhibitSkip.Text = "Skip Exhibit";
            this.toolTip1.SetToolTip(this.radio_ExhibitSkip, "Include all meeting space.");
            this.radio_ExhibitSkip.UseVisualStyleBackColor = true;
            // 
            // radio_ExhibitNo
            // 
            this.radio_ExhibitNo.AutoSize = true;
            this.radio_ExhibitNo.Location = new System.Drawing.Point(175, 3);
            this.radio_ExhibitNo.Name = "radio_ExhibitNo";
            this.radio_ExhibitNo.Size = new System.Drawing.Size(73, 17);
            this.radio_ExhibitNo.TabIndex = 17;
            this.radio_ExhibitNo.TabStop = true;
            this.radio_ExhibitNo.Text = "Exhibit - N";
            this.toolTip1.SetToolTip(this.radio_ExhibitNo, "Do not include exhibitors in search.");
            this.radio_ExhibitNo.UseVisualStyleBackColor = true;
            // 
            // radio_ExhibitYes
            // 
            this.radio_ExhibitYes.AutoSize = true;
            this.radio_ExhibitYes.Location = new System.Drawing.Point(93, 3);
            this.radio_ExhibitYes.Name = "radio_ExhibitYes";
            this.radio_ExhibitYes.Size = new System.Drawing.Size(72, 17);
            this.radio_ExhibitYes.TabIndex = 18;
            this.radio_ExhibitYes.TabStop = true;
            this.radio_ExhibitYes.Text = "Exhibit - Y";
            this.toolTip1.SetToolTip(this.radio_ExhibitYes, "Include only Exhibitors in search.");
            this.radio_ExhibitYes.UseVisualStyleBackColor = true;
            // 
            // timeEnd
            // 
            this.timeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeEnd.Location = new System.Drawing.Point(97, 152);
            this.timeEnd.Name = "timeEnd";
            this.timeEnd.ShowCheckBox = true;
            this.timeEnd.ShowUpDown = true;
            this.timeEnd.Size = new System.Drawing.Size(106, 20);
            this.timeEnd.TabIndex = 14;
            this.toolTip1.SetToolTip(this.timeEnd, "Event date range end time.");
            // 
            // dateEnd
            // 
            this.dateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateEnd.Location = new System.Drawing.Point(97, 126);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.ShowCheckBox = true;
            this.dateEnd.Size = new System.Drawing.Size(106, 20);
            this.dateEnd.TabIndex = 12;
            this.toolTip1.SetToolTip(this.dateEnd, "Event date range end date.");
            // 
            // timeStart
            // 
            this.timeStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeStart.Location = new System.Drawing.Point(97, 100);
            this.timeStart.Name = "timeStart";
            this.timeStart.ShowCheckBox = true;
            this.timeStart.ShowUpDown = true;
            this.timeStart.Size = new System.Drawing.Size(106, 20);
            this.timeStart.TabIndex = 10;
            this.toolTip1.SetToolTip(this.timeStart, "Event date range start time");
            // 
            // dateStart
            // 
            this.dateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateStart.Location = new System.Drawing.Point(97, 74);
            this.dateStart.Name = "dateStart";
            this.dateStart.ShowCheckBox = true;
            this.dateStart.Size = new System.Drawing.Size(106, 20);
            this.dateStart.TabIndex = 8;
            this.toolTip1.SetToolTip(this.dateStart, "Event date range start date.");
            // 
            // text_RoomGrouping
            // 
            this.text_RoomGrouping.Location = new System.Drawing.Point(97, 45);
            this.text_RoomGrouping.Name = "text_RoomGrouping";
            this.text_RoomGrouping.Size = new System.Drawing.Size(191, 20);
            this.text_RoomGrouping.TabIndex = 7;
            this.toolTip1.SetToolTip(this.text_RoomGrouping, "Fuction Room Group");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Web Svc URL:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.timeEnd);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.dateEnd);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.timeStart);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dateStart);
            this.groupBox1.Controls.Add(this.text_RoomGrouping);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.text_EventKey);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(294, 246);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Get Meeting Space";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radio_PostSkip);
            this.panel2.Controls.Add(this.radio_PostNo);
            this.panel2.Controls.Add(this.radio_PostYes);
            this.panel2.Location = new System.Drawing.Point(10, 209);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(265, 25);
            this.panel2.TabIndex = 26;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radio_ExhibitSkip);
            this.panel1.Controls.Add(this.radio_ExhibitNo);
            this.panel1.Controls.Add(this.radio_ExhibitYes);
            this.panel1.Location = new System.Drawing.Point(10, 178);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 25);
            this.panel1.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 156);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "End Time:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 130);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "End Date:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Start Time:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Start Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Room Grouping:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.text_UserName);
            this.groupBox2.Controls.Add(this.text_Password);
            this.groupBox2.Location = new System.Drawing.Point(316, 99);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(191, 92);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Credentials";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(16, 17);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(489, 79);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Resource / Property Id";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_Exit);
            this.groupBox4.Controls.Add(this.btn_GetMtgSpaceChar);
            this.groupBox4.Controls.Add(this.btn_GetMtgSpace);
            this.groupBox4.Location = new System.Drawing.Point(316, 193);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(191, 152);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btn_Browse);
            this.groupBox5.Controls.Add(this.btn_ViewOutput);
            this.groupBox5.Location = new System.Drawing.Point(16, 348);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(491, 80);
            this.groupBox5.TabIndex = 27;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Response";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 442);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.text_ServiceURL);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.text_OutputFile);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.text_PropertyKey);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Meeting Space Provider Client";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_GetMtgSpace;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text_UserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox text_EventKey;
        private System.Windows.Forms.TextBox text_Password;
        private System.Windows.Forms.TextBox text_PropertyKey;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox text_OutputFile;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox text_ServiceURL;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_ViewOutput;
        private System.Windows.Forms.Button btn_GetMtgSpaceChar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateStart;
        private System.Windows.Forms.TextBox text_RoomGrouping;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker timeStart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker timeEnd;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private System.Windows.Forms.RadioButton radio_ExhibitYes;
        private System.Windows.Forms.RadioButton radio_ExhibitNo;
        private System.Windows.Forms.RadioButton radio_ExhibitSkip;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radio_PostSkip;
        private System.Windows.Forms.RadioButton radio_PostNo;
        private System.Windows.Forms.RadioButton radio_PostYes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
    }
}

