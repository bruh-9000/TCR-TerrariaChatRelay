﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using TerrariaChatRelay.Helpers;

namespace TerrariaChatRelay.Clients.DiscordClient
{
	public class DiscordConfig : SimpleConfig<DiscordConfig>
	{
		public override string FileName { get; set; }
			= Path.Combine(Global.ModConfigPath, "TerrariaChatRelay-Discord.json");

		[JsonProperty(Order = 10)]
		public string CommentGuide { get; set; } = "Setup Guide: https://tinyurl.com/TCR-Setup";
		[JsonProperty(Order = 40)]
		public bool EnableDiscord { get; set; } = true;
		[JsonProperty(Order = 50)]
		public string CommandPrefix { get; set; } = "t!";
		[JsonProperty(Order = 60)]
		public bool ShowMessageOnStartup { get; set; } = true;
		[JsonProperty(Order = 75)]
		public ulong OwnerUserId { get; set; } = 0;
		[JsonProperty(Order = 110)]
		public List<ulong> ManagerUserIds { get; set; } = new List<ulong>();
		[JsonProperty(Order = 120)]
		public List<ulong> AdminUserIds { get; set; } = new List<ulong>();
		[JsonProperty(Order = 130)]
		public string HelpEndpoint1 { get; set; } = "Use commands to handle denying sending and receiving! Use 't!help admin' for more information";
		[JsonProperty(Order = 133)]
		public List<Endpoint> EndPoints { get; set; } = new List<Endpoint>();
		[JsonProperty(Order = 134)]
		public string HelpGameStatus1 { get; set; } = "Sets the bots now playing status. Can be configured with variables";
		[JsonProperty(Order = 135)]
		public string HelpGameStatus2 { get; set; } = "%playercount% = Number of current players on the server";
		[JsonProperty(Order = 136)]
		public string HelpGameStatus3 { get; set; } = "%maxplayers% = Maximum number of players allowed, based on serverconfig.txt or command prompt entry";
		[JsonProperty(Order = 138)]
		public string BotGameStatus { get; set; } = "with %playercount%/%maxplayers% players!";
		[JsonProperty(Order = 139)]
		public string BotChannelDescription { get; set; } = "%worldname% - **Players Online:** %playercount% / %maxplayers%";
		[JsonProperty(Order = 140)]
		public string RetryHelp { get; set; } = "Set NumberOfTimesToRetryConnectionAfterError to -1 to retry infinitely";
		[JsonProperty(Order = 150)]
		public int NumberOfTimesToRetryConnectionAfterError { get; set; } = 5;
		[JsonProperty(Order = 160)]
		public int SecondsToWaitBeforeRetryingAgain { get; set; } = 10;
		[JsonProperty(Order = 170)]
		public string HelpFormat1 { get; set; } = "You can insert any of these formatters to change how your message looks! (CASE SENSITIVE)";
		[JsonProperty(Order = 180)]
		public string HelpFormat2 { get; set; } = "%playername% = Player Name";
		[JsonProperty(Order = 190)]
		public string HelpFormat3 { get; set; } = "%worldname% = World Name";
		[JsonProperty(Order = 200)]
		public string HelpFormat4 { get; set; } = "%message% = Initial message content";
		[JsonProperty(Order = 220)]
		public string HelpFormat5 { get; set; } = "%groupprefix% = Group prefix";
		[JsonProperty(Order = 230)]
		public string HelpFormat6 { get; set; } = "%groupsuffix% = Group suffix";
        [JsonProperty(Order = 234)]
        public bool EnableSlashCommands = true;
        [JsonProperty(Order = 235)]
		public string TerrariaInGameDiscordPrefix = "[c/7489d8:Discord] - ";
		[JsonProperty(Order = 240)]
		public string PlayerChatFormat = "> **%playername%:** %message%";
		[JsonProperty(Order = 250)]
		public string PlayerLoggedInFormat = ":arrow_right: **%playername%** joined the server.";
		[JsonProperty(Order = 260)]
		public string PlayerLoggedOutFormat = ":arrow_left: **%playername%** left the server.";
		[JsonProperty(Order = 270)]
		public string WorldEventFormat = "**%message%**";
		[JsonProperty(Order = 280)]
		public string ServerStartingFormat = ":green_circle: **%message%**";
		[JsonProperty(Order = 290)]
		public string ServerStoppingFormat = ":red_circle: **%message%**";
		[JsonProperty(Order = 305)]
		public string BossSpawned = ":anger: **%message%**";
		[JsonProperty(Order = 305)]
		public string BossKilled = ":headstone: **%message%**";
		[JsonProperty(Order = 308)]
		public bool EnableUserAndEveryonePings = false;
		[JsonProperty(Order = 310)]
		public EmbedSettings EmbedSettings = new EmbedSettings();
		[JsonProperty(Order = 315)]
		public string HelpRegex1 { get; set; } = "For more advanced users, you can use RegexMessageReplace to modify/filter the final message being sent.";
		[JsonProperty(Order = 322)]
		public string HelpRegex2 { get; set; } = "Example (Filtering nth mob kill annoucements): { \"^.+ has defeated the \\d+th .+$\": \"\" }";
		[JsonProperty(Order = 330)]
		public bool RegexMessageEnabled { get; set; } = false;
		[JsonProperty(Order = 340)]
		public Dictionary<string, string> RegexMessageReplace { get; set; } = new Dictionary<string, string>();
		[JsonProperty(Order = 350)]
		public string HelpHideMessageWithString { get; set; } = "If the raw message has any of the strings in this list, it will not relay the message.";
		[JsonProperty(Order = 360)]
		public List<string> HideMessagesWithString { get; set; } = new List<string>();

		public DiscordConfig()
		{
			if (!File.Exists(FileName))
			{
				// Discord
				EndPoints.Add(new Endpoint());
				ManagerUserIds.Add(0);
				AdminUserIds.Add(0);

				// Regex
				RegexMessageReplace = new Dictionary<string, string>
				{
					["^(.*)$"] = "$1"
				};
			}
		}
	}

	public class EmbedSettings
	{
		public bool EmbedPlayerChat { get; set; } = false;
		public bool EmbedPlayerEnterLeave { get; set; } = true;
		public bool EmbedWorldEvents { get; set; } = false;
		public bool EmbedServerStartStop { get; set; } = true;
		public bool EmbedBossSpawnAndKill { get; set; } = false;
		public bool EmbedOther { get; set; } = true;
	}

	public class Endpoint
	{
		public string BotToken { get; set; } = "BOT_TOKEN";
		public List<ulong> Channel_IDs { get; set; } = new List<ulong>();
		public List<ulong> Console_Channel_IDs { get; set; } = new List<ulong>();
		public List<ulong> DenySendingMessagesToGame { get; set; } = new List<ulong>();
		public List<ulong> DenyReceivingMessagesFromGame { get; set; } = new List<ulong>();
	}
}