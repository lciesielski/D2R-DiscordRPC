
namespace D2RRPCWinForms
{
	partial class D2RRPCMainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(D2RRPCMainForm));
			this.BtnExit = new System.Windows.Forms.Button();
			this.NumUpDownPlayerLevel = new System.Windows.Forms.NumericUpDown();
			this.LabelPlayerLevel = new System.Windows.Forms.Label();
			this.ComboBoxPlayerClass = new System.Windows.Forms.ComboBox();
			this.GroupBoxPlayerInfo = new System.Windows.Forms.GroupBox();
			this.LabelPlayerClass = new System.Windows.Forms.Label();
			this.GroupBoxGameInfo = new System.Windows.Forms.GroupBox();
			this.ComboBoxGameState = new System.Windows.Forms.ComboBox();
			this.LabelGameState = new System.Windows.Forms.Label();
			this.LabeGameDifficulty = new System.Windows.Forms.Label();
			this.ComboBoxGameDifficulty = new System.Windows.Forms.ComboBox();
			this.MainFormMenuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SaveSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.LoadSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.BtnStopPresence = new System.Windows.Forms.Button();
			this.BtnStartPresence = new System.Windows.Forms.Button();
			this.TextBoxDiabloExePath = new System.Windows.Forms.TextBox();
			this.LabelDiabloExeFilePath = new System.Windows.Forms.Label();
			this.LabelDiscordClientId = new System.Windows.Forms.Label();
			this.TextBoxDiscordClientId = new System.Windows.Forms.TextBox();
			this.BtnFindDiabloExeFile = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.NumUpDownPlayerLevel)).BeginInit();
			this.GroupBoxPlayerInfo.SuspendLayout();
			this.GroupBoxGameInfo.SuspendLayout();
			this.MainFormMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// BtnExit
			// 
			this.BtnExit.AutoSize = true;
			this.BtnExit.Location = new System.Drawing.Point(612, 492);
			this.BtnExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.BtnExit.Name = "BtnExit";
			this.BtnExit.Size = new System.Drawing.Size(150, 50);
			this.BtnExit.TabIndex = 0;
			this.BtnExit.Text = "Exit";
			this.BtnExit.UseVisualStyleBackColor = true;
			this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
			// 
			// NumUpDownPlayerLevel
			// 
			this.NumUpDownPlayerLevel.Location = new System.Drawing.Point(154, 102);
			this.NumUpDownPlayerLevel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.NumUpDownPlayerLevel.Maximum = new decimal(new int[] {
			99,
			0,
			0,
			0});
			this.NumUpDownPlayerLevel.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			0});
			this.NumUpDownPlayerLevel.Name = "NumUpDownPlayerLevel";
			this.NumUpDownPlayerLevel.Size = new System.Drawing.Size(198, 39);
			this.NumUpDownPlayerLevel.TabIndex = 1;
			this.NumUpDownPlayerLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.NumUpDownPlayerLevel.Value = new decimal(new int[] {
			1,
			0,
			0,
			0});
			this.NumUpDownPlayerLevel.ValueChanged += new System.EventHandler(this.NumUpDownPlayerLevel_ValueChanged);
			// 
			// LabelPlayerLevel
			// 
			this.LabelPlayerLevel.AutoSize = true;
			this.LabelPlayerLevel.Location = new System.Drawing.Point(8, 102);
			this.LabelPlayerLevel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.LabelPlayerLevel.Name = "LabelPlayerLevel";
			this.LabelPlayerLevel.Size = new System.Drawing.Size(140, 32);
			this.LabelPlayerLevel.TabIndex = 2;
			this.LabelPlayerLevel.Text = "Player Level";
			// 
			// ComboBoxPlayerClass
			// 
			this.ComboBoxPlayerClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ComboBoxPlayerClass.FormattingEnabled = true;
			this.ComboBoxPlayerClass.Location = new System.Drawing.Point(152, 36);
			this.ComboBoxPlayerClass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.ComboBoxPlayerClass.Name = "ComboBoxPlayerClass";
			this.ComboBoxPlayerClass.Size = new System.Drawing.Size(196, 40);
			this.ComboBoxPlayerClass.TabIndex = 3;
			this.ComboBoxPlayerClass.TextChanged += new System.EventHandler(this.ComboBoxPlayerClass_TextChanged);
			// 
			// GroupBoxPlayerInfo
			// 
			this.GroupBoxPlayerInfo.AutoSize = true;
			this.GroupBoxPlayerInfo.Controls.Add(this.LabelPlayerClass);
			this.GroupBoxPlayerInfo.Controls.Add(this.ComboBoxPlayerClass);
			this.GroupBoxPlayerInfo.Controls.Add(this.NumUpDownPlayerLevel);
			this.GroupBoxPlayerInfo.Controls.Add(this.LabelPlayerLevel);
			this.GroupBoxPlayerInfo.Location = new System.Drawing.Point(402, 44);
			this.GroupBoxPlayerInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.GroupBoxPlayerInfo.Name = "GroupBoxPlayerInfo";
			this.GroupBoxPlayerInfo.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.GroupBoxPlayerInfo.Size = new System.Drawing.Size(360, 300);
			this.GroupBoxPlayerInfo.TabIndex = 5;
			this.GroupBoxPlayerInfo.TabStop = false;
			this.GroupBoxPlayerInfo.Text = "Player Info";
			// 
			// LabelPlayerClass
			// 
			this.LabelPlayerClass.AutoSize = true;
			this.LabelPlayerClass.Location = new System.Drawing.Point(8, 40);
			this.LabelPlayerClass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.LabelPlayerClass.Name = "LabelPlayerClass";
			this.LabelPlayerClass.Size = new System.Drawing.Size(138, 32);
			this.LabelPlayerClass.TabIndex = 3;
			this.LabelPlayerClass.Text = "Player Class";
			// 
			// GroupBoxGameInfo
			// 
			this.GroupBoxGameInfo.AutoSize = true;
			this.GroupBoxGameInfo.Controls.Add(this.ComboBoxGameState);
			this.GroupBoxGameInfo.Controls.Add(this.LabelGameState);
			this.GroupBoxGameInfo.Controls.Add(this.LabeGameDifficulty);
			this.GroupBoxGameInfo.Controls.Add(this.ComboBoxGameDifficulty);
			this.GroupBoxGameInfo.Location = new System.Drawing.Point(12, 44);
			this.GroupBoxGameInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.GroupBoxGameInfo.Name = "GroupBoxGameInfo";
			this.GroupBoxGameInfo.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.GroupBoxGameInfo.Size = new System.Drawing.Size(384, 300);
			this.GroupBoxGameInfo.TabIndex = 6;
			this.GroupBoxGameInfo.TabStop = false;
			this.GroupBoxGameInfo.Text = "Game Info";
			// 
			// ComboBoxGameState
			// 
			this.ComboBoxGameState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ComboBoxGameState.FormattingEnabled = true;
			this.ComboBoxGameState.Items.AddRange(new object[] {
			"Slaying Demons",
			"Chilling in Town"});
			this.ComboBoxGameState.Location = new System.Drawing.Point(148, 104);
			this.ComboBoxGameState.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.ComboBoxGameState.Name = "ComboBoxGameState";
			this.ComboBoxGameState.Size = new System.Drawing.Size(224, 40);
			this.ComboBoxGameState.TabIndex = 5;
			this.ComboBoxGameState.TextChanged += new System.EventHandler(this.ComboBoxGameState_TextChanged);
			// 
			// LabelGameState
			// 
			this.LabelGameState.AutoSize = true;
			this.LabelGameState.Location = new System.Drawing.Point(6, 104);
			this.LabelGameState.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.LabelGameState.Name = "LabelGameState";
			this.LabelGameState.Size = new System.Drawing.Size(136, 32);
			this.LabelGameState.TabIndex = 4;
			this.LabelGameState.Text = "Game State";
			// 
			// LabeGameDifficulty
			// 
			this.LabeGameDifficulty.AutoSize = true;
			this.LabeGameDifficulty.Location = new System.Drawing.Point(6, 40);
			this.LabeGameDifficulty.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.LabeGameDifficulty.Name = "LabeGameDifficulty";
			this.LabeGameDifficulty.Size = new System.Drawing.Size(179, 32);
			this.LabeGameDifficulty.TabIndex = 3;
			this.LabeGameDifficulty.Text = "Game Difficulty";
			// 
			// ComboBoxGameDifficulty
			// 
			this.ComboBoxGameDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ComboBoxGameDifficulty.FormattingEnabled = true;
			this.ComboBoxGameDifficulty.Items.AddRange(new object[] {
			"Normal",
			"Nightmare",
			"Hell"});
			this.ComboBoxGameDifficulty.Location = new System.Drawing.Point(192, 40);
			this.ComboBoxGameDifficulty.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.ComboBoxGameDifficulty.Name = "ComboBoxGameDifficulty";
			this.ComboBoxGameDifficulty.Size = new System.Drawing.Size(180, 40);
			this.ComboBoxGameDifficulty.TabIndex = 3;
			this.ComboBoxGameDifficulty.TextChanged += new System.EventHandler(this.ComboBoxGameDifficulty_TextChanged);
			// 
			// MainFormMenuStrip
			// 
			this.MainFormMenuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.MainFormMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.fileToolStripMenuItem});
			this.MainFormMenuStrip.Location = new System.Drawing.Point(0, 0);
			this.MainFormMenuStrip.Name = "MainFormMenuStrip";
			this.MainFormMenuStrip.Size = new System.Drawing.Size(774, 40);
			this.MainFormMenuStrip.TabIndex = 7;
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.SaveSettingsToolStripMenuItem,
			this.LoadSettingsToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(71, 36);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// SaveSettingsToolStripMenuItem
			// 
			this.SaveSettingsToolStripMenuItem.Name = "SaveSettingsToolStripMenuItem";
			this.SaveSettingsToolStripMenuItem.Size = new System.Drawing.Size(291, 44);
			this.SaveSettingsToolStripMenuItem.Text = "Save Settings";
			this.SaveSettingsToolStripMenuItem.Click += new System.EventHandler(this.SaveSettingsToolStripMenuItem_Click);
			// 
			// LoadSettingsToolStripMenuItem
			// 
			this.LoadSettingsToolStripMenuItem.Name = "LoadSettingsToolStripMenuItem";
			this.LoadSettingsToolStripMenuItem.Size = new System.Drawing.Size(291, 44);
			this.LoadSettingsToolStripMenuItem.Text = "Load Settings";
			this.LoadSettingsToolStripMenuItem.Click += new System.EventHandler(this.LoadSettingsToolStripMenuItem_Click);
			// 
			// BtnStopPresence
			// 
			this.BtnStopPresence.AutoSize = true;
			this.BtnStopPresence.Enabled = false;
			this.BtnStopPresence.Location = new System.Drawing.Point(456, 492);
			this.BtnStopPresence.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.BtnStopPresence.Name = "BtnStopPresence";
			this.BtnStopPresence.Size = new System.Drawing.Size(150, 50);
			this.BtnStopPresence.TabIndex = 8;
			this.BtnStopPresence.Text = "Stop";
			this.BtnStopPresence.UseVisualStyleBackColor = true;
			this.BtnStopPresence.Click += new System.EventHandler(this.BtnStopPresence_Click);
			// 
			// BtnStartPresence
			// 
			this.BtnStartPresence.AutoSize = true;
			this.BtnStartPresence.Location = new System.Drawing.Point(300, 492);
			this.BtnStartPresence.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.BtnStartPresence.Name = "BtnStartPresence";
			this.BtnStartPresence.Size = new System.Drawing.Size(150, 50);
			this.BtnStartPresence.TabIndex = 9;
			this.BtnStartPresence.Text = "Start";
			this.BtnStartPresence.UseVisualStyleBackColor = true;
			this.BtnStartPresence.Click += new System.EventHandler(this.BtnStartPresence_Click);
			// 
			// TextBoxDiabloExePath
			// 
			this.TextBoxDiabloExePath.Location = new System.Drawing.Point(198, 362);
			this.TextBoxDiabloExePath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.TextBoxDiabloExePath.Name = "TextBoxDiabloExePath";
			this.TextBoxDiabloExePath.ReadOnly = true;
			this.TextBoxDiabloExePath.Size = new System.Drawing.Size(494, 39);
			this.TextBoxDiabloExePath.TabIndex = 12;
			// 
			// LabelDiabloExeFilePath
			// 
			this.LabelDiabloExeFilePath.AutoSize = true;
			this.LabelDiabloExeFilePath.Location = new System.Drawing.Point(13, 365);
			this.LabelDiabloExeFilePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.LabelDiabloExeFilePath.Name = "LabelDiabloExeFilePath";
			this.LabelDiabloExeFilePath.Size = new System.Drawing.Size(179, 32);
			this.LabelDiabloExeFilePath.TabIndex = 13;
			this.LabelDiabloExeFilePath.Text = "Diablo Exe Path";
			// 
			// LabelDiscordClientId
			// 
			this.LabelDiscordClientId.AutoSize = true;
			this.LabelDiscordClientId.Location = new System.Drawing.Point(4, 427);
			this.LabelDiscordClientId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.LabelDiscordClientId.Name = "LabelDiscordClientId";
			this.LabelDiscordClientId.Size = new System.Drawing.Size(193, 32);
			this.LabelDiscordClientId.TabIndex = 14;
			this.LabelDiscordClientId.Text = "Discord Client ID";
			// 
			// TextBoxDiscordClientId
			// 
			this.TextBoxDiscordClientId.Location = new System.Drawing.Point(198, 424);
			this.TextBoxDiscordClientId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.TextBoxDiscordClientId.Name = "TextBoxDiscordClientId";
			this.TextBoxDiscordClientId.PasswordChar = '*';
			this.TextBoxDiscordClientId.PlaceholderText = "Discord Client ID";
			this.TextBoxDiscordClientId.Size = new System.Drawing.Size(494, 39);
			this.TextBoxDiscordClientId.TabIndex = 15;
			this.TextBoxDiscordClientId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// BtnFindDiabloExeFile
			// 
			this.BtnFindDiabloExeFile.Location = new System.Drawing.Point(698, 348);
			this.BtnFindDiabloExeFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.BtnFindDiabloExeFile.Name = "BtnFindDiabloExeFile";
			this.BtnFindDiabloExeFile.Size = new System.Drawing.Size(64, 64);
			this.BtnFindDiabloExeFile.TabIndex = 11;
			this.BtnFindDiabloExeFile.UseVisualStyleBackColor = true;
			this.BtnFindDiabloExeFile.Click += new System.EventHandler(this.BtnFindDiabloExeFile_Click);
			// 
			// D2RRPCMainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(774, 548);
			this.Controls.Add(this.TextBoxDiscordClientId);
			this.Controls.Add(this.LabelDiscordClientId);
			this.Controls.Add(this.LabelDiabloExeFilePath);
			this.Controls.Add(this.TextBoxDiabloExePath);
			this.Controls.Add(this.BtnFindDiabloExeFile);
			this.Controls.Add(this.BtnStartPresence);
			this.Controls.Add(this.BtnStopPresence);
			this.Controls.Add(this.GroupBoxGameInfo);
			this.Controls.Add(this.GroupBoxPlayerInfo);
			this.Controls.Add(this.BtnExit);
			this.Controls.Add(this.MainFormMenuStrip);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.MainFormMenuStrip;
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.MaximizeBox = false;
			this.Name = "D2RRPCMainForm";
			this.Text = "Diablo 2 Resurrected Rich Presence";
			this.Load += new System.EventHandler(this.D2RRPCMainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.NumUpDownPlayerLevel)).EndInit();
			this.GroupBoxPlayerInfo.ResumeLayout(false);
			this.GroupBoxPlayerInfo.PerformLayout();
			this.GroupBoxGameInfo.ResumeLayout(false);
			this.GroupBoxGameInfo.PerformLayout();
			this.MainFormMenuStrip.ResumeLayout(false);
			this.MainFormMenuStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button BtnExit;
		private System.Windows.Forms.NumericUpDown NumUpDownPlayerLevel;
		private System.Windows.Forms.Label LabelPlayerLevel;
		private System.Windows.Forms.ComboBox ComboBoxPlayerClass;
		private System.Windows.Forms.GroupBox GroupBoxPlayerInfo;
		private System.Windows.Forms.Label LabelPlayerClass;
		private System.Windows.Forms.GroupBox GroupBoxGameInfo;
		private System.Windows.Forms.Label LabeGameDifficulty;
		private System.Windows.Forms.ComboBox ComboBoxGameDifficulty;
		private System.Windows.Forms.MenuStrip MainFormMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem SaveSettingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem LoadSettingsToolStripMenuItem;
		private System.Windows.Forms.Button BtnStopPresence;
		private System.Windows.Forms.Button BtnStartPresence;
		private System.Windows.Forms.ComboBox ComboBoxGameState;
		private System.Windows.Forms.Label LabelGameState;
		private System.Windows.Forms.TextBox TextBoxDiabloExePath;
		private System.Windows.Forms.Label LabelDiabloExeFilePath;
		private System.Windows.Forms.Label LabelDiscordClientId;
		private System.Windows.Forms.TextBox TextBoxDiscordClientId;
		private System.Windows.Forms.Button BtnFindDiabloExeFile;
	}
}

