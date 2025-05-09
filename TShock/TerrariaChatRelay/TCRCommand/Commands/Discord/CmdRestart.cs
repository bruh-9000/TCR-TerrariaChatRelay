﻿using System.Threading.Tasks;

namespace TerrariaChatRelay.TCRCommand.Commands.Discord
{
	[Command]
	public class CmdRestart : ICommand
	{
		public string Name { get; } = "Restart";

		public string CommandKey { get; } = "restart";

		public string[] Aliases { get; } = { "reset", "reboot", "reload" };

		public string Description { get; } = "Restarts the bot.";

		public string Usage { get; } = "restart";

		public Permission DefaultPermissionLevel { get; } = Permission.Admin;

		public string Execute(object sender, string input = null, TCRClientUser whoRanCommand = null)
		{
			Task.Run(async () =>
			{
				await Task.Delay(1500);
				Core.DisconnectClients();
				Global.Config = new TCRConfig().GetOrCreateConfiguration();
				Core.ConnectClients();
			});

			return "Restarting bot...";
		}
	}
}
