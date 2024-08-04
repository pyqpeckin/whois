using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Whois.Command
{
    public class Whois : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "whois";

        public string Help => "To find out who owns the building ";

        public string Syntax => String.Empty;

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string>();

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer uPlayer = (UnturnedPlayer)caller;

            var see = Physics.Raycast(new Ray(uPlayer.Player.look.aim.position, uPlayer.Player.look.aim.forward), out var hitInfo, 6f, RayMasks.BARRICADE_INTERACT | RayMasks.BARRICADE | RayMasks.STRUCTURE);
            if (!see)
            {
                UnturnedChat.Say(uPlayer, Plugin.Instance.Translate("whois_1"));
                return;
            }

            ulong owner = 0;

            if (StructureManager.tryGetInfo(hitInfo.transform, out byte x, out byte t, out ushort index, out StructureRegion region, out StructureDrop structure)) 
                owner = region.structures[index].owner;
            else if (BarricadeManager.tryGetInfo(hitInfo.transform, out byte q, out byte w, out ushort plant, out ushort indexs, out BarricadeRegion regiona, out BarricadeDrop bar)) 
                owner = regiona.barricades[indexs].owner;
            else if (BarricadeManager.tryGetInfo(hitInfo.transform.parent.parent, out byte qs, out byte ws, out ushort plants, out ushort indexss, out BarricadeRegion regionas, out BarricadeDrop bars)) 
                owner = regionas.barricades[indexss].owner;
            else
            {
                UnturnedChat.Say(uPlayer, Plugin.Instance.Translate("whois_1"));
                return;
            }


            uPlayer.Player.sendBrowserRequest("Owner this object", "http://steamcommunity.com/profiles/" + owner);
        }
    }
}
