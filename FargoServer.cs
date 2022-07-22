using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using System.ComponentModel;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace FargoServer
{
	public class FargoServer : Mod
	{
	}

    public class FargoServerConfig : ModConfig
    {
        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message) => false;

        public override ConfigScope Mode => ConfigScope.ServerSide;
        
        [DefaultValue(true)]
        public bool UniversalCollapseDisable;

        [DefaultValue(true)]
        public bool GalacticReformDisable;
    }

	public class DisabledItem : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return (entity.type == ModContent.ItemType<FargowiltasSouls.Items.Misc.GalacticReformer>() && 
						ModContent.GetInstance<FargoServerConfig>().GalacticReformDisable && 
						Main.netMode != Terraria.ID.NetmodeID.SinglePlayer) 
					||
				   (entity.type == ModContent.ItemType<FargowiltasSouls.Items.Misc.UniversalCollapse>() && 
						ModContent.GetInstance<FargoServerConfig>().UniversalCollapseDisable && 
						Main.netMode != Terraria.ID.NetmodeID.SinglePlayer);
        }

        public override bool CanUseItem(Item item, Player player) => false;

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine line = new TooltipLine(Mod, "disabled", "DISABLED FOR SERVER (no trolling)");
            line.OverrideColor = Color.Red;
            tooltips.Add(line);
        }
    }
}