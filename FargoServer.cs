using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using System.ComponentModel;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace NoFargosExplosives
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
		
		[DefaultValue(true)]
        public bool SupremeRenewalDisable;
		
		[DefaultValue(true)]
        public bool RenewalDisable;
    }

	public class GRDisable : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
			Mod mod = ModLoader.GetMod("FargowiltasSouls");
			if (mod != null)
				return entity.type == ModContent.ItemType<FargowiltasSouls.Items.Misc.GalacticReformer>();
			return false;
        }

        public override bool CanUseItem(Item item, Player player) => !ModContent.GetInstance<FargoServerConfig>().GalacticReformDisable;

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine line = new TooltipLine(Mod, "disabled", "DISABLED FOR SERVER (no trolling)");
            line.OverrideColor = Color.Red;
            if (!CanUseItem(item, Main.LocalPlayer)) tooltips.Add(line);
        }
    }

    public class UCDisable : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
			Mod mod = ModLoader.GetMod("FargowiltasSouls");
			if (mod != null)
				return entity.type == ModContent.ItemType<FargowiltasSouls.Items.Misc.UniversalCollapse>();
			return false;
        }

        public override bool CanUseItem(Item item, Player player) => !ModContent.GetInstance<FargoServerConfig>().UniversalCollapseDisable;

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine line = new TooltipLine(Mod, "disabled", "DISABLED FOR SERVER (no trolling)");
            line.OverrideColor = Color.Red;
            if (!CanUseItem(item, Main.LocalPlayer)) tooltips.Add(line);
        }
    }
	
	/*public class SupremeDisable : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return entity.type == ModContent.ItemType<Fargowiltas.Items.Renewals.BaseRenewalItem>();
        }

        public override bool CanUseItem(Item item, Player player) 
		{
			if (item.ModItem is Fargowiltas.Items.Renewals.BaseRenewalItem modItem)
			{
				if (modItem.supreme)
					return ModContent.GetInstance<FargoServerConfig>().SupremeRenewalDisable;
				else
					return ModContent.GetInstance<FargoServerConfig>().RenewalDisable;
			}
		}

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine line = new TooltipLine(Mod, "disabled", "DISABLED FOR SERVER (no trolling)");
            line.OverrideColor = Color.Red;
            if (!CanUseItem(item, Main.LocalPlayer)) tooltips.Add(line);
        }
    }*/
	
	public class SupremeDisable : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return entity.type == ModContent.ItemType<Fargowiltas.Items.Renewals.CorruptRenewalSupreme>() ||
					entity.type == ModContent.ItemType<Fargowiltas.Items.Renewals.CrimsonRenewalSupreme>() ||
					entity.type == ModContent.ItemType<Fargowiltas.Items.Renewals.HallowRenewalSupreme>() ||
					entity.type == ModContent.ItemType<Fargowiltas.Items.Renewals.MushroomRenewalSupreme>() ||
					entity.type == ModContent.ItemType<Fargowiltas.Items.Renewals.PurityRenewalSupreme>();
        }

        public override bool CanUseItem(Item item, Player player) => !ModContent.GetInstance<FargoServerConfig>().SupremeRenewalDisable;

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine line = new TooltipLine(Mod, "disabled", "DISABLED FOR SERVER (no trolling)");
            line.OverrideColor = Color.Red;
            if (!CanUseItem(item, Main.LocalPlayer)) tooltips.Add(line);
        }
    }
	
	public class RenewalDisable : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return entity.type == ModContent.ItemType<Fargowiltas.Items.Renewals.CorruptRenewal>() ||
					entity.type == ModContent.ItemType<Fargowiltas.Items.Renewals.CrimsonRenewal>() ||
					entity.type == ModContent.ItemType<Fargowiltas.Items.Renewals.HallowRenewal>() ||
					entity.type == ModContent.ItemType<Fargowiltas.Items.Renewals.MushroomRenewal>() ||
					entity.type == ModContent.ItemType<Fargowiltas.Items.Renewals.PurityRenewal>();
        }

        public override bool CanUseItem(Item item, Player player) => !ModContent.GetInstance<FargoServerConfig>().RenewalDisable;

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine line = new TooltipLine(Mod, "disabled", "DISABLED FOR SERVER (no trolling)");
            line.OverrideColor = Color.Red;
            if (!CanUseItem(item, Main.LocalPlayer)) tooltips.Add(line);
        }
    }
}