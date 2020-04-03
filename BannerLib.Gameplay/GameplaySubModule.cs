using TaleWorlds.MountAndBlade;

namespace BannerLib.Gameplay
{
    public class GameplaySubModule : MBSubModuleBase
    {
        internal static GameplaySubModule Instance { get; private set; }
        internal static PerkSystem _perkSystem = null;
        internal static ModelSystem _modelSystem = null;
        protected override void OnSubModuleLoad()
        {
            if (Instance == null) Instance = this;
            _perkSystem = new PerkSystem();
            _modelSystem = new ModelSystem();
        }

        public static PerkSystem GetPerkSystem()
        {
            return _perkSystem;
        }
        public static ModelSystem GetModelSystem()
        {
            return _modelSystem;
        }
    }
}