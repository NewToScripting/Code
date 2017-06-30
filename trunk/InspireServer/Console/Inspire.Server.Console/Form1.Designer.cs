namespace Inspire.Server.Console
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblServiceStatus = new System.Windows.Forms.Label();
            this.btnPingInterval = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPingInterval = new System.Windows.Forms.TextBox();
            this.txtEventInterval = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnStartService = new System.Windows.Forms.Button();
            this.btnEndService = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.grdSystemEvents = new System.Windows.Forms.DataGridView();
            this.btnRefreshGrid = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdSystemEvents)).BeginInit();
            this.SuspendLayout();
            // 
            // lblServiceStatus
            // 
            this.lblServiceStatus.AutoSize = true;
            this.lblServiceStatus.Location = new System.Drawing.Point(6, 41);
            this.lblServiceStatus.Name = "lblServiceStatus";
            this.lblServiceStatus.Size = new System.Drawing.Size(86, 13);
            this.lblServiceStatus.TabIndex = 2;
            this.lblServiceStatus.Text = "System Events...";
            // 
            // btnPingInterval
            // 
            this.btnPingInterval.Location = new System.Drawing.Point(206, 285);
            this.btnPingInterval.Name = "btnPingInterval";
            this.btnPingInterval.Size = new System.Drawing.Size(128, 23);
            this.btnPingInterval.TabIndex = 4;
            this.btnPingInterval.Text = "Change Ping Interval";
            this.btnPingInterval.UseVisualStyleBackColor = true;
            this.btnPingInterval.Click += new System.EventHandler(this.btnPingInterval_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 287);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ping Interval:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 315);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Event Interval:";
            // 
            // txtPingInterval
            // 
            this.txtPingInterval.Location = new System.Drawing.Point(98, 287);
            this.txtPingInterval.Name = "txtPingInterval";
            this.txtPingInterval.Size = new System.Drawing.Size(100, 20);
            this.txtPingInterval.TabIndex = 8;
            // 
            // txtEventInterval
            // 
            this.txtEventInterval.Location = new System.Drawing.Point(98, 314);
            this.txtEventInterval.Name = "txtEventInterval";
            this.txtEventInterval.Size = new System.Drawing.Size(100, 20);
            this.txtEventInterval.TabIndex = 9;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(206, 315);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(128, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "Change Event Interval";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Intervals Config:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 351);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "900000 milliseconds = 15 mins";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 364);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "60000 milliseconds = 1 minute";
            // 
            // btnStartService
            // 
            this.btnStartService.Location = new System.Drawing.Point(20, 57);
            this.btnStartService.Name = "btnStartService";
            this.btnStartService.Size = new System.Drawing.Size(121, 23);
            this.btnStartService.TabIndex = 17;
            this.btnStartService.Text = "Start Service";
            this.btnStartService.UseVisualStyleBackColor = true;
            this.btnStartService.Click += new System.EventHandler(this.btnStartService_Click);
            // 
            // btnEndService
            // 
            this.btnEndService.Location = new System.Drawing.Point(147, 57);
            this.btnEndService.Name = "btnEndService";
            this.btnEndService.Size = new System.Drawing.Size(121, 23);
            this.btnEndService.TabIndex = 18;
            this.btnEndService.Text = "End Service";
            this.btnEndService.UseVisualStyleBackColor = true;
            this.btnEndService.Click += new System.EventHandler(this.btnEndService_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(274, 57);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(54, 23);
            this.btnRefresh.TabIndex = 19;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // grdSystemEvents
            // 
            this.grdSystemEvents.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.grdSystemEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSystemEvents.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.grdSystemEvents.Location = new System.Drawing.Point(18, 138);
            this.grdSystemEvents.Name = "grdSystemEvents";
            this.grdSystemEvents.Size = new System.Drawing.Size(415, 127);
            this.grdSystemEvents.TabIndex = 20;
            // 
            // btnRefreshGrid
            // 
            this.btnRefreshGrid.Location = new System.Drawing.Point(19, 103);
            this.btnRefreshGrid.Name = "btnRefreshGrid";
            this.btnRefreshGrid.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshGrid.TabIndex = 21;
            this.btnRefreshGrid.Text = "Refresh";
            this.btnRefreshGrid.UseVisualStyleBackColor = true;
            this.btnRefreshGrid.Click += new System.EventHandler(this.btnRefreshGrid_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Inspire Displays Console";
            this.notifyIcon1.Visible = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(409, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(47, 23);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnMinimize
            // 
            this.btnMinimize.Location = new System.Drawing.Point(364, 3);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(39, 23);
            this.btnMinimize.TabIndex = 23;
            this.btnMinimize.Text = "Min";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(459, 393);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRefreshGrid);
            this.Controls.Add(this.grdSystemEvents);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnEndService);
            this.Controls.Add(this.btnStartService);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txtEventInterval);
            this.Controls.Add(this.txtPingInterval);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPingInterval);
            this.Controls.Add(this.lblServiceStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.grdSystemEvents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblServiceStatus;
        private System.Windows.Forms.Button btnPingInterval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPingInterval;
        private System.Windows.Forms.TextBox txtEventInterval;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnStartService;
        private System.Windows.Forms.Button btnEndService;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView grdSystemEvents;
        private System.Windows.Forms.Button btnRefreshGrid;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;
    }
}

