﻿using Newtonsoft.Json;
using System;
using System.IO;
using TerrariaChatRelay.Helpers;

namespace TerrariaChatRelay
{
    public class TCRConfig : SimpleConfig<TCRConfig>
    {
        public override string FileName { get; set; }
            = Path.Combine(Global.ModConfigPath, "TCR.json");

        // TerrariaChatRelay
        public bool ShowChatMessages { get; set; } = true;
        public bool ShowGameEvents { get; set; } = true;
		public bool ShowServerStartMessage { get; set; } = true;
		public bool ShowServerStopMessage { get; set; } = true;
        public bool ShowWorldSeed { get; set; } = false;
		public bool CheckForLatestVersion { get; set; } = true;
		public string LangOnlyForTShock { get; set; } = "";

		public TCRConfig()
        {
            if (!File.Exists(FileName))
            {
                // Discord
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("TerrariaChatRelay - Mod Config Generated: " + FileName);
                Console.ResetColor();
            }
        }
    }
}