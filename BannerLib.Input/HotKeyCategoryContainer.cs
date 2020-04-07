using System.Collections.Generic;
using TaleWorlds.Core;
using TaleWorlds.InputSystem;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
#pragma warning disable 1591

namespace BannerLib.Input
{
    public class HotKeyCategoryContainer : GameKeyContext
    {
        public HotKeyCategoryContainer(string categoryId, int gameKeysCount, IEnumerable<HotKeyBase> keys) 
            : base(categoryId, gameKeysCount)
        {
            var keyName = Module.CurrentModule.GlobalTextManager.AddGameText("str_key_name");
            var keyDesc = Module.CurrentModule.GlobalTextManager.AddGameText("str_key_description");
            var variationString = $"{categoryId}_";
            foreach (var key in keys)
            {
                keyName.AddVariationWithId(variationString+key.ID, new TextObject(key.DisplayName), new List<GameTextManager.ChoiceTag>());
                keyDesc.AddVariationWithId(variationString+key.ID, new TextObject(key.Description), new List<GameTextManager.ChoiceTag>());
                RegisterGameKey(new GameKey(key.ID, key.IdName, categoryId, key.DefaultKey, key.Category));
            }
        }
    }
}