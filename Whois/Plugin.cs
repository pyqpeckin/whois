using Rocket.API.Collections;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whois
{
    public class Plugin : RocketPlugin
    {
        public override TranslationList DefaultTranslations => new TranslationList
        {
             { "whois_1", "Server: You're not looking at the construction" },         // cmd
        };

        public static Plugin Instance;

        protected override void Load()
        {
            base.Load();
            Instance = this;

            Logger.Log("----------------------------");
            Logger.Log("- Plugin created: https://discord.gg/PaDvuGPSyK");
            Logger.Log("- tg: t.me/pyqpeckin");
            Logger.Log("----------------------------");

        }

        protected override void Unload()
        {
            Logger.Log("----------------------------");
            Logger.Log("- Plugin created: https://discord.gg/PaDvuGPSyK");
            Logger.Log("- tg: t.me/pyqpeckin");
            Logger.Log("----------------------------");

            Instance = null;    
            base.Unload();
        }
    }
}
