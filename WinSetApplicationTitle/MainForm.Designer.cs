namespace WinSetApplicationTitle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEditHotkey = new System.Windows.Forms.Button();
            this.txtHotkey = new System.Windows.Forms.TextBox();
            this.chkHideWindowOnStartup = new System.Windows.Forms.CheckBox();
            this.chkStartAppAutomatically = new System.Windows.Forms.CheckBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnOpenWebsite = new System.Windows.Forms.Button();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.trayContextMenuStrip.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayContextMenuStrip;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "WinSetApplicationTitle";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseDoubleClick);
            // 
            // trayContextMenuStrip
            // 
            this.trayContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.trayContextMenuStrip.Name = "trayContextMenuStrip";
            this.trayContextMenuStrip.Size = new System.Drawing.Size(169, 54);
            // 
            // showApplicationToolStripMenuItem
            // 
            this.showApplicationToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showApplicationToolStripMenuItem.Name = "showApplicationToolStripMenuItem";
            this.showApplicationToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.showApplicationToolStripMenuItem.Text = "Show application";
            this.showApplicationToolStripMenuItem.Click += new System.EventHandler(this.showApplicationToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(165, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.tabPage2);
            this.mainTabControl.Controls.Add(this.tabPage1);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Location = new System.Drawing.Point(0, 0);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(223, 256);
            this.mainTabControl.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnExit);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.chkHideWindowOnStartup);
            this.tabPage2.Controls.Add(this.chkStartAppAutomatically);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(215, 230);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(134, 199);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEditHotkey);
            this.groupBox1.Controls.Add(this.txtHotkey);
            this.groupBox1.Location = new System.Drawing.Point(8, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 77);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "React on hotkey:";
            // 
            // btnEditHotkey
            // 
            this.btnEditHotkey.Location = new System.Drawing.Point(119, 45);
            this.btnEditHotkey.Name = "btnEditHotkey";
            this.btnEditHotkey.Size = new System.Drawing.Size(75, 23);
            this.btnEditHotkey.TabIndex = 1;
            this.btnEditHotkey.Text = "Edit hotkey";
            this.btnEditHotkey.UseVisualStyleBackColor = true;
            this.btnEditHotkey.Click += new System.EventHandler(this.btnEditHotkey_Click);
            // 
            // txtHotkey
            // 
            this.txtHotkey.Location = new System.Drawing.Point(6, 19);
            this.txtHotkey.Name = "txtHotkey";
            this.txtHotkey.ReadOnly = true;
            this.txtHotkey.Size = new System.Drawing.Size(188, 20);
            this.txtHotkey.TabIndex = 0;
            // 
            // chkHideWindowOnStartup
            // 
            this.chkHideWindowOnStartup.AutoSize = true;
            this.chkHideWindowOnStartup.Location = new System.Drawing.Point(8, 29);
            this.chkHideWindowOnStartup.Name = "chkHideWindowOnStartup";
            this.chkHideWindowOnStartup.Size = new System.Drawing.Size(137, 17);
            this.chkHideWindowOnStartup.TabIndex = 3;
            this.chkHideWindowOnStartup.Text = "Hide window on startup";
            this.chkHideWindowOnStartup.UseVisualStyleBackColor = true;
            this.chkHideWindowOnStartup.CheckedChanged += new System.EventHandler(this.chkHideWindowOnStartup_CheckedChanged);
            // 
            // chkStartAppAutomatically
            // 
            this.chkStartAppAutomatically.AutoSize = true;
            this.chkStartAppAutomatically.Location = new System.Drawing.Point(8, 6);
            this.chkStartAppAutomatically.Name = "chkStartAppAutomatically";
            this.chkStartAppAutomatically.Size = new System.Drawing.Size(166, 17);
            this.chkStartAppAutomatically.TabIndex = 2;
            this.chkStartAppAutomatically.Text = "Start application automatically";
            this.chkStartAppAutomatically.UseVisualStyleBackColor = true;
            this.chkStartAppAutomatically.CheckedChanged += new System.EventHandler(this.chkStartAppAutomatically_CheckedChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtVersion);
            this.tabPage1.Controls.Add(this.btnOpenWebsite);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(215, 230);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "About";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnOpenWebsite
            // 
            this.btnOpenWebsite.Location = new System.Drawing.Point(118, 199);
            this.btnOpenWebsite.Name = "btnOpenWebsite";
            this.btnOpenWebsite.Size = new System.Drawing.Size(94, 23);
            this.btnOpenWebsite.TabIndex = 0;
            this.btnOpenWebsite.Text = "Open website";
            this.btnOpenWebsite.UseVisualStyleBackColor = true;
            this.btnOpenWebsite.Click += new System.EventHandler(this.btnOpenWebsite_Click);
            // 
            // txtVersion
            // 
            this.txtVersion.Location = new System.Drawing.Point(57, 6);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.ReadOnly = true;
            this.txtVersion.Size = new System.Drawing.Size(152, 20);
            this.txtVersion.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Version:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 256);
            this.Controls.Add(this.mainTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "WinSetApplicationTitle";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.trayContextMenuStrip.ResumeLayout(false);
            this.mainTabControl.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ContextMenuStrip trayContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem showApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkHideWindowOnStartup;
        private System.Windows.Forms.CheckBox chkStartAppAutomatically;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtHotkey;
        private System.Windows.Forms.Button btnEditHotkey;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnOpenWebsite;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtVersion;
    }
}

