using System;

namespace BannerLib.Gameplay.Models
{
    public class ReplacedModelInfo : ModelInfoBase
    {
        public Type BaseType { get; }
        public Type OriginalType { get; }
        public Type ReplacedType { get; }
        public Action<Type> OnReplace { get; }

        public ReplacedModelInfo(string subModName, Type baseType, Type originalType, Type replacedType) : base(subModName)
        {
            
        }
    }
}