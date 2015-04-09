using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

using TAPI;
using Terraria;

namespace jLiquids.Buffs
{
    public class Tarred : TAPI.ModBuff
    {
        public static Color buffColor = new Color(75, 75, 75);
        public override void Effects(Player player, int index)
        {
            player.moveSpeedMod *= 0.45f;
            player.moveSpeedMax = 0.55f;
            Player.jumpSpeed = 3f;
            Player.jumpHeight = 12;
            player.maxFallSpeed = 5f;
            if (Main.rand.Next(30) == 0)
            {
                float speedX = (float)Main.rand.Next(1) * 0.01f;
                int dust = Dust.NewDust(player.position, player.width, player.height, 36, speedX, +0.5f, 15, default(Color), 0.4f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].fadeIn = 1.0f;
                Main.playerDrawDust.Add(dust);
            }
        }
        Color newColor = default(Color);
        public override Color ModifyDrawColor(Player drawPlayer, Color color)
        {
            return new Color(75, 75, 75, 255);
        }

        public override Color ModifyDrawColor(NPC npc, Color color)
        {
            return new Color(75, 75, 75, 255);
        }
    }
}