using System;

namespace BannerLib.Gameplay.Models
{
    public class AddedModelInfo : ModelInfoBase
    {
        public Type AddedType;
        public Type AddedBase;
        
        public AddedModelInfo(string subModName, Type addedType, Type addedBase) : base(subModName)
        {
            AddedType = addedType;
            AddedBase = addedBase;
        }
    }
}