using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

namespace BannerLib.Gameplay
{
    public class PerkSystem
    {
        public void UpdatePerks()
        {
            foreach (Hero hero in Hero.All)
            {
                hero.HeroDeveloper.call("DiscoverOpenedPerks");
            }
        }

        public PerkObject CreateCustomPerk(Game game, string stringId)
        {
            PerkObject customPerk = game.ObjectManager.GetObject<PerkObject>(stringId);
            if (customPerk == null)
            {
                customPerk = new PerkObject(stringId);
                game.ObjectManager.RegisterPresumedObject(customPerk);
            }

            return customPerk;
        }
    }
}
