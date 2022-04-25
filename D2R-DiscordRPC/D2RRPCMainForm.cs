using DiscordRPC;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace D2RRPCWinForms
{
	public partial class D2RRPCMainForm : Form
	{
		public static Timestamps rpcStart;
		public Dictionary<string, string> classToIcon = new Dictionary<string, string>()
		{
			{"Amazon", "d2r_amazon_portrait"},
			{"Assassin", "d2r_assassin_portrait"},
			{"Barbarian", "d2r_barbarian_portrait"},
			{"Druid", "d2r_druid_portrait"},
			{"Necromancer", "d2r_necromancer_portrait"},
			{"Paladin", "d2r_paladin_portrait"},
			{"Sorceress", "d2r_sorceress_portrait"}
		};

		public DiscordRpcClient client;
		public SettingsHelper settingsHelper;
		public PresenceHelper presenceHelper;
		public LauncherHelper launcherHelper;

		private delegate void ThreadSafeDelegate();

		public D2RRPCMainForm()
		{
			InitializeComponent();
		}

		internal string GetDiscordClientId()
		{
			return TextBoxDiscordClientId.Text;
		}

		internal string GetGameDifficulty()
		{
			return ComboBoxGameDifficulty.Text;
		}

		internal string GetPlayerClass()
		{
			return ComboBoxPlayerClass.Text;
		}

		internal int GetPlayerLevel()
		{
			return (int)NumUpDownPlayerLevel.Value;
		}

		internal string GetGameState()
		{
			return ComboBoxGameState.Text;
		}

		internal string GetBattleNetExePath()
		{
			return TextBoxBattleNetExePath.Text;
		}

		internal void EnableStartButton()
		{
			if (BtnStopPresence.InvokeRequired)
			{
				BtnStopPresence.Invoke(new ThreadSafeDelegate(EnableStartButton));
			}
			else
			{
				BtnStartPresence.Enabled = true;
			}
		}

		internal void EnableStopButton()
		{
			if (BtnStopPresence.InvokeRequired)
			{
				BtnStopPresence.Invoke(new ThreadSafeDelegate(EnableStopButton));
			}
			else
			{
				BtnStopPresence.Enabled = true;
			}
		}

		internal void EnableDiscordClientId()
		{
			if (BtnStopPresence.InvokeRequired)
			{
				BtnStopPresence.Invoke(new ThreadSafeDelegate(EnableDiscordClientId));
			}
			else
			{
				TextBoxDiscordClientId.Enabled = true;
			}
		}

		internal void DisableStartButton()
		{
			if (BtnStartPresence.InvokeRequired)
			{
				BtnStartPresence.Invoke(new ThreadSafeDelegate(DisableStartButton));
			}
			else
			{
				BtnStartPresence.Enabled = false;
			}
		}

		internal void DisableStopButton()
		{
			if (BtnStopPresence.InvokeRequired)
			{
				BtnStopPresence.Invoke(new ThreadSafeDelegate(DisableStopButton));
			}
			else
			{
				BtnStopPresence.Enabled = false;
			}
		}

		internal void DisableDiscordClientId()
		{
			if (BtnStopPresence.InvokeRequired)
			{
				BtnStopPresence.Invoke(new ThreadSafeDelegate(DisableDiscordClientId));
			}
			else
			{
				TextBoxDiscordClientId.Enabled = false;
			}
		}

		private void D2RRPCMainForm_Load(object sender, EventArgs e)
		{
			BtnFindBattleNetExeFile.Image = Screen.PrimaryScreen.Bounds.Width switch
			{
				1024 => D2R_DiscordRPC.Properties.Resources.BNET_16x16.ToBitmap(),
				1280 => D2R_DiscordRPC.Properties.Resources.BNET_16x16.ToBitmap(),
				1360 => D2R_DiscordRPC.Properties.Resources.BNET_16x16.ToBitmap(),
				1366 => D2R_DiscordRPC.Properties.Resources.BNET_16x16.ToBitmap(),
				1920 => D2R_DiscordRPC.Properties.Resources.BNET_32x32.ToBitmap(),
				2048 => D2R_DiscordRPC.Properties.Resources.BNET_32x32.ToBitmap(),
				2560 => D2R_DiscordRPC.Properties.Resources.BNET_64x64.ToBitmap(),
				3440 => D2R_DiscordRPC.Properties.Resources.BNET_64x64.ToBitmap(),
				3840 => D2R_DiscordRPC.Properties.Resources.BNET_64x64.ToBitmap(),
				4096 => D2R_DiscordRPC.Properties.Resources.BNET_64x64.ToBitmap(),
				_ => D2R_DiscordRPC.Properties.Resources.BNET_32x32.ToBitmap(),
			};

			ComboBoxPlayerClass.Items.AddRange(new List<object>(classToIcon.Keys).ToArray());

			settingsHelper = new SettingsHelper(this);
			presenceHelper = new PresenceHelper(this);
			launcherHelper = new LauncherHelper(this);

			SettingsHelper.RichPresenceSettings richPresenceData = settingsHelper.LoadRichPresenceSettingsSilent();
			if (richPresenceData != null)
			{
				UpdateFormFromSettings(richPresenceData);
				if (!IsFormDataMissing())
				{
					launcherHelper.HandleDiabloProcess();
					presenceHelper.StartClient(richPresenceData.DiscordClientId);
					DisableStartButton();
				}
			}

			if (!BtnStartPresence.Enabled)
			{
				DisableDiscordClientId();
				EnableStopButton();
			}
		}

		private void BtnExit_Click(object sender, EventArgs e)
		{
			presenceHelper.StopClient();
			Application.Exit();
		}

		private void SaveSettingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			settingsHelper.SaveRichPresenceSettings();
		}

		private void LoadSettingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SettingsHelper.RichPresenceSettings richPresenceData = settingsHelper.LoadRichPresenceSettings();

			if (richPresenceData == null)
			{
				UpdateFormFromSettings(richPresenceData);
			}
			else
			{
				MessageBox.Show("Error parsing settings file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void BtnStopPresence_Click(object sender, EventArgs e)
		{
			if (client != null && client.IsInitialized)
			{
				presenceHelper.StopClient();
			}
			else
			{
				MessageBox.Show("Rich presence is not started.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void BtnStartPresence_Click(object sender, EventArgs e)
		{
			if (client != null && client.IsInitialized)
			{
				MessageBox.Show("Rich presence is already started.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else if (IsFormDataMissing())
			{
				MessageBox.Show("You must select proper game data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				launcherHelper.HandleDiabloProcess();
				presenceHelper.StartClient(TextBoxDiscordClientId.Text);
				BtnStopPresence.Enabled = true;
				BtnStartPresence.Enabled = false;
				TextBoxDiscordClientId.Enabled = false;
			}
		}

		private void UpdateFormFromSettings(SettingsHelper.RichPresenceSettings richPresenceData)
		{
			TextBoxDiscordClientId.Text = richPresenceData.DiscordClientId;
			ComboBoxGameState.Text = richPresenceData.GameState;
			ComboBoxGameDifficulty.Text = richPresenceData.GameDifficulty;
			TextBoxBattleNetExePath.Text = richPresenceData.GameExePath;
			ComboBoxPlayerClass.Text = richPresenceData.PlayerClass;
			NumUpDownPlayerLevel.Value = richPresenceData.PlayerLevel;
		}

		private bool IsFormDataMissing()
		{
			return
				string.IsNullOrEmpty(TextBoxDiscordClientId.Text) ||
				string.IsNullOrEmpty(ComboBoxGameDifficulty.Text) ||
				string.IsNullOrEmpty(ComboBoxGameState.Text) ||
				string.IsNullOrEmpty(ComboBoxPlayerClass.Text) ||
				string.IsNullOrEmpty(NumUpDownPlayerLevel.Value.ToString()) ||
				(string.IsNullOrEmpty(TextBoxBattleNetExePath.Text) && Process.GetProcessesByName(settingsHelper.DEFAULT_DIABLO_EXE_FILE_NAME).Length == 0);
		}

		private void ComboBoxGameDifficulty_TextChanged(object sender, EventArgs e)
		{
			presenceHelper.UpdatePresence(false);
		}

		private void ComboBoxGameState_TextChanged(object sender, EventArgs e)
		{
			presenceHelper.UpdatePresence(false);
		}

		private void ComboBoxPlayerClass_TextChanged(object sender, EventArgs e)
		{
			presenceHelper.UpdatePresence(false);
		}

		private void NumUpDownPlayerLevel_ValueChanged(object sender, EventArgs e)
		{
			presenceHelper.UpdatePresence(false);
		}

		private void BtnFindDiabloExeFile_Click(object sender, EventArgs e)
		{
			TextBoxBattleNetExePath.Text = settingsHelper.GetBattleNetExeFilePath();
		}
	}
}
