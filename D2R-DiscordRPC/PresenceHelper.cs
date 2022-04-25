using DiscordRPC;
using System.Collections.Generic;

namespace D2RRPCWinForms
{
	public class PresenceHelper
	{
		public D2RRPCMainForm mainForm;

		public PresenceHelper(D2RRPCMainForm mainForm)
		{
			this.mainForm = mainForm;
		}

		public void UpdatePresence(bool resetTimestamp) 
		{
			if (mainForm.client == null) return;

			mainForm.client.SetPresence(new RichPresence()
			{
				Details = mainForm.GetGameState(),
				State = $"Difficulty: {mainForm.GetGameDifficulty()}",
				Assets = new Assets()
				{
					LargeImageKey = mainForm.settingsHelper.DEFAULT_LARGE_ICON_NAME,
					LargeImageText = mainForm.settingsHelper.DEFAULT_LARGE_ICON_TITLE,
					SmallImageKey = mainForm.classToIcon.GetValueOrDefault(mainForm.GetPlayerClass()),
					SmallImageText = $"{mainForm.GetPlayerClass()} - Level: {mainForm.GetPlayerLevel()}"
				},
				Timestamps = resetTimestamp ? D2RRPCMainForm.rpcStart : mainForm.client.CurrentPresence.Timestamps
			});
		}

		public void StartClient(string discordClientId)
		{
			D2RRPCMainForm.rpcStart = Timestamps.Now;
			mainForm.client = new DiscordRpcClient(discordClientId);
			mainForm.client.Initialize();
			UpdatePresence(true);
		}

		public void StopClient()
		{
			if (mainForm.client != null && mainForm.client.IsInitialized)
			{
				mainForm.client.ClearPresence();
				mainForm.client.Dispose();
				mainForm.DisableStopButton();
				mainForm.EnableStartButton();
				mainForm.EnableDiscordClientId();
			}
		}
	}
}
