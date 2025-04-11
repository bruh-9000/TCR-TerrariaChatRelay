﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Terraria.ModLoader.Config;
using TerrariaChatRelay.Clients.DiscordClient;

namespace TerrariaChatRelay
{
	public class Config : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ClientSide;

		[Header("General")]
		[DefaultValue("t!")]
		[ReloadRequired]
		public string CommandPrefix { get; set; }

		[DefaultValue("TerrariaChatRelay")]
		public string BotStatus { get; set; }

		[DefaultValue("%worldname% - **Players Online:** %playercount% / %maxplayers%")]
		public string BotChannelDescription { get; set; }

		[DefaultValue(true)]
		public bool ShowPoweredByMessageOnStartup { get; set; }

		[DefaultValue(5)]
		[ReloadRequired]
		public int NumberOfTimesToRetryConnectionAfterError { get; set; }

		[DefaultValue(10)]
		[ReloadRequired]
		public int SecondsToWaitBeforeRetryingAgain { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool EnableSlashCommands = true;

        [Header("UserManagement")]
		[DefaultValue("0")]
		[ReloadRequired]
		public string OwnerUserId { get; set; }

        [ReloadRequired]
        [DefaultListValue("0")]
        public List<string> ManagerUserIds { get; set; } = new List<string>();

        [ReloadRequired]
        [DefaultListValue("0")]
        public List<string> AdminUserIds { get; set; } = new List<string>();

        [JsonIgnore]
		[ShowDespiteJsonIgnore]
		public bool OpenDiscordTokenGuide
		{
			get
			{
				return false;
			}
			set
			{
				if (value)
				{
					Process.Start(new ProcessStartInfo
					{
						FileName = "https://github.com/xNarnia/TCR-TerrariaChatRelay/wiki/Discord-Relay-Setup",
						UseShellExecute = true
					});
				}
			}
		}

		public List<EndpointModConfig> Endpoints { get; set; } = new List<EndpointModConfig>();

        [Header("Formatting")]
		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		public bool HoverHereForFormatHelp { get { return false; } set { } }

		[DefaultValue("[c/7489d8:Discord] - ")]
		[ReloadRequired]
		public string TerrariaInGameDiscordPrefix { get; set; }

		[DefaultValue("> **%playername%:** %message%")]
		[ReloadRequired]
		public string PlayerChatFormat { get; set; }

		[DefaultValue(":arrow_right: **%playername%** joined the server.")]
		[ReloadRequired]
		public string PlayerLoggedInFormat { get; set; }

		[DefaultValue(":arrow_left: **%playername%** left the server.")]
		[ReloadRequired]
		public string PlayerLoggedOutFormat { get; set; }

		[DefaultValue("**%message%**")]
		[ReloadRequired]
		public string WorldEventFormat { get; set; }

		[DefaultValue(":green_circle: **%message%**")]
		[ReloadRequired]
		public string ServerStartingFormat { get; set; }

		[DefaultValue(":red_circle: **%message%**")]
		[ReloadRequired]
		public string ServerStoppingFormat { get; set; }

		[DefaultValue(":anger: **%bossname% has awoken!**")]
		[ReloadRequired]
		public string VanillaBossSpawned { get; set; }

		[DefaultValue(false)]
		[ReloadRequired]
		public bool EnableUserAndEveryonePings;

		[ReloadRequired]
		public EmbedSettings EmbedSettings { get; set; }

		public List<string> HideMessagesWithString { get; set; } = new List<string>();

		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[Header("StillNeedHelp")]
		public bool OpenDiscordSupportServer
		{
			get
			{
				return false;
			}
			set
			{
				if (value)
				{
					Process.Start(new ProcessStartInfo
					{
						FileName = "https://discord.gg/xAQGT4VetN",
						UseShellExecute = true
					});
				}
			}
		}

		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		public bool SpecialThanks { get { return false; } set { } }

		public Config()
		{
			Endpoints.Add(new EndpointModConfig
            {
				BotToken = "BOT_TOKEN",
				Channel_IDs = new List<string>(),
				Console_Channel_IDs = new List<string>(),
				DenyReceivingMessagesFromGame = new List<string>(),
				DenySendingMessagesToGame = new List<string>()
			});
		}
	}

    public class EndpointModConfig
    {
        public string BotToken { get; set; } = "BOT_TOKEN";
        public List<string> Channel_IDs { get; set; } = new List<string>();
        public List<string> Console_Channel_IDs { get; set; } = new List<string>();
        public List<string> DenySendingMessagesToGame { get; set; } = new List<string>();
        public List<string> DenyReceivingMessagesFromGame { get; set; } = new List<string>();
    }
}