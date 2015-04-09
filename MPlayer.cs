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
    public sealed class MPlayer : ModPlayer
    {
        public override void Initialize()
        {
            base.Initialize();
        }
        public override void MidUpdate()
        {
            int num176 = player.height;
            if (player.waterWalk)
            {
                num176 -= 6;
            }
            if (Collision.LavaCollision(player.position, player.width, num176))
            {
                if (!player.lavaImmune && Main.myPlayer == player.whoAmI && !player.immune && player.zoneBlood && player.HasBuff(1) == -1)
                {
                    if (player.lavaTime > 0)
                    {
                        player.lavaTime--;
                    }
                    else
                    {
                        player.Hurt((int)(80f * player.lavaRoseVanilla), 0, false, false, Lang.deathMsg(-1, -1, -1, 2), false, 2f);
                        player.AddBuff(69, 420, true);
                    }
                }
                else if (!player.lavaImmune && Main.myPlayer == player.whoAmI && !player.immune && player.zoneEvil && player.HasBuff(1) == -1)
                {
                    if (player.lavaTime > 0)
                    {
                        player.lavaTime--;
                    }
                    else
                    {
                        player.Hurt((int)(80f * player.lavaRoseVanilla), 0, false, false, Lang.deathMsg(-1, -1, -1, 2), false, 2f);
                        player.AddBuff(39, 420, true);
                    }
                }
                else if (!player.lavaImmune && Main.myPlayer == player.whoAmI && !player.immune && player.zoneHoly && player.HasBuff(1) == -1)
                {
                    if (player.lavaTime > 0)
                    {
                        player.lavaTime--;
                    }
                    else
                    {
                        player.Hurt((int)(120f * player.lavaRoseVanilla), 0, false, false, Lang.deathMsg(-1, -1, -1, 2), false, 2f);
                    }
                }
                else if (!player.lavaImmune && Main.myPlayer == player.whoAmI && !player.immune && player.zoneJungle)
                {
                    if (player.lavaTime > 0)
                    {
                        player.lavaTime--;
                    }
                    else
                    {
                        player.Hurt((int)(40f * player.lavaRoseVanilla), 0, false, false, Lang.deathMsg(-1, -1, -1, 2), false, 2f);
                        player.AddBuff("jLiquids:Tarred", 420, true);
                    }
                }
                else if (!player.lavaImmune && Main.myPlayer == player.whoAmI && !player.immune && player.HasBuff(1) == -1 && (!player.zoneEvil || !player.zoneBlood || !player.zoneHoly || !player.zoneJungle))
                {
                    if (player.lavaTime > 0)
                    {
                        player.lavaTime--;
                    }
                    else
                    {
                        player.Hurt((int)(80f * player.lavaRoseVanilla), 0, false, false, Lang.deathMsg(-1, -1, -1, 2), false, 2f);
                        player.AddBuff(24, 420, true);
                    }
                }

                player.lavaWet = true;
            }
            else
            {
                player.lavaWet = false;
                if (player.lavaTime < player.lavaMax)
                {
                    player.lavaTime++;
                }
            }
        }
        public void UpdatePlayer(Player player)
        {
            if (player.lavaWet && player.zoneJungle)
            {
                player.gravity = 0.2f;
                player.moveSpeedMod *= 0.75f;
            }
        }
/*        public void UpdateBuffs()
        {
            int num176 = player.height;
            if (player.lavaWet && player.zoneBlood || player.zoneEvil)
			{
                player.DelBuff(24);
            }
        }*/
    }
}