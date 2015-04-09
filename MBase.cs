using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using TAPI;
using Terraria;

namespace jLiquids
{
    [GlobalMod]
    public sealed class MBase : ModBase
    {
        internal static MBase BaseInstance;
        public override void PreGameUpdate() 
        {
            BaseInstance = this;
            if (Main.localPlayer.zoneBlood/* || Main.localPlayer.HasItem(2) */)
            {
                Main.liquidTexture[1] = MBase.BaseInstance.textures["Images/Ichor"];
            }
            else if (Main.localPlayer.zoneEvil)
            {
                Main.liquidTexture[1] = MBase.BaseInstance.textures["Images/Cursed Flames"];
            }
            else if (Main.localPlayer.zoneHoly)
            {
                Main.liquidTexture[1] = MBase.BaseInstance.textures["Images/Hallowed"];
            }
            else if (Main.localPlayer.zoneJungle)
            {
                Main.liquidTexture[1] = MBase.BaseInstance.textures["Images/Tar"];
            }
            else
            {
                Main.liquidTexture[1] = MBase.BaseInstance.textures["Images/Lava"];
            }
        }
        public override void OnUnload() 
        {

        }
    }
} //Work on adding some unique functionality to buckets in the alt biomes. Fix waterfall, lighting and fire bubbles