using System;

namespace BannerLib.Gameplay.Models
{
    public abstract class ModelInfoBase
    {
        public string SubModName { get; }

        internal ModelInfoBase(string subModName)
        {
            SubModName = subModName;
        }
    }
}