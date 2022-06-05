using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace D2RRPCWinForms
{
	public class SettingsHelper
	{
		public readonly string DEFAULT_LARGE_ICON_NAME = "d2r_background";
		public readonly string DEFAULT_LARGE_ICON_TITLE = "Diablo 2 Resurrected";
		public readonly string DEFAULT_DIABLO_EXE_FILE_NAME = "D2R";
		public readonly string DEFAULT_BATTLE_NET_EXE_FILE_NAME = "Battle.net";

		public D2RRPCMainForm mainForm;
		
		private readonly string DEFAULT_SETTINGS_EXTENSION = "json";
		private readonly string DEFAULT_EXECUTABLE_EXTENSION = "exe";
		private readonly string DEFAULT_SETTINGS_FILE_NAME = "Settings";
		private readonly string SETTINGS_EXTENSION_FILTER = "JSON (*.json)|*.json";

		public SettingsHelper(D2RRPCMainForm mainForm)
		{
			this.mainForm = mainForm;
		}

		public class RichPresenceSettings
		{
			public string DiscordClientId { get; set; }
			public string GameDifficulty { get; set; }
			public string GameState { get; set; }
			public string BattleNetExePath { get; set; }
			public string PlayerClass { get; set; }
			public int PlayerLevel { get; set; }
		}

		public void SaveRichPresenceSettings()
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				Filter = SETTINGS_EXTENSION_FILTER,
				DefaultExt = DEFAULT_SETTINGS_EXTENSION,
				Title = "Save Rich Presence Settings",
				AddExtension = true,
				FileName = DEFAULT_SETTINGS_FILE_NAME,
				InitialDirectory = Environment.CurrentDirectory
			};

			if (saveFileDialog.ShowDialog() != DialogResult.OK || string.IsNullOrEmpty(saveFileDialog.FileName)) return;

			byte[] byteData = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(new RichPresenceSettings
			{
				DiscordClientId = mainForm.GetDiscordClientId(),
				GameDifficulty = mainForm.GetGameDifficulty(),
				GameState = mainForm.GetGameState(),
				BattleNetExePath = mainForm.GetBattleNetExePath(),
				PlayerClass = mainForm.GetPlayerClass(),
				PlayerLevel = mainForm.GetPlayerLevel()
			}));

			using Stream saveFileDialogStream = saveFileDialog.OpenFile();
			saveFileDialogStream.Write(byteData, 0, byteData.Length);
		}

		public RichPresenceSettings LoadRichPresenceSettings() 
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Filter = SETTINGS_EXTENSION_FILTER,
				DefaultExt = DEFAULT_SETTINGS_EXTENSION,
				Title = "Load Rich Presence Settings",
				AddExtension = true,
				FileName = DEFAULT_SETTINGS_FILE_NAME
			};

			if (openFileDialog.ShowDialog() != DialogResult.OK || string.IsNullOrEmpty(openFileDialog.FileName)) return null;

			using Stream openFileDialogStream = openFileDialog.OpenFile();
			byte[] byteData = new byte[openFileDialogStream.Length];
			openFileDialogStream.Read(byteData, 0, (int)openFileDialogStream.Length);

			return JsonSerializer.Deserialize<RichPresenceSettings>(Encoding.UTF8.GetString(byteData));
		}

		public RichPresenceSettings LoadRichPresenceSettingsSilent() 
		{
			string path = Environment.CurrentDirectory + $@"\{DEFAULT_SETTINGS_FILE_NAME}.{DEFAULT_SETTINGS_EXTENSION}";
			if (File.Exists(path))
			{
				using FileStream openFileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				byte[] byteData = new byte[openFileStream.Length];
				openFileStream.Read(byteData, 0, (int)openFileStream.Length);
				return JsonSerializer.Deserialize<RichPresenceSettings>(Encoding.UTF8.GetString(byteData));
			}
			else 
			{
				return null;
			}
		}

		public string GetBattleNetExeFilePath()
		{
			string currentPath = mainForm.GetBattleNetExePath();

			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Filter = $"{DEFAULT_BATTLE_NET_EXE_FILE_NAME}.{DEFAULT_EXECUTABLE_EXTENSION}|{DEFAULT_BATTLE_NET_EXE_FILE_NAME}.{DEFAULT_EXECUTABLE_EXTENSION}",
				DefaultExt = DEFAULT_EXECUTABLE_EXTENSION,
				Title = "Get Battle.Net EXE",
				AddExtension = true,
				FileName = $"{DEFAULT_BATTLE_NET_EXE_FILE_NAME}.{DEFAULT_EXECUTABLE_EXTENSION}",
				InitialDirectory = string.IsNullOrEmpty(currentPath) ? Environment.CurrentDirectory : currentPath
			};

			if (openFileDialog.ShowDialog() != DialogResult.OK || string.IsNullOrEmpty(openFileDialog.FileName))
			{
				return currentPath;
			}
			else
			{
				return openFileDialog.FileName;
			}
		}

	}
}
