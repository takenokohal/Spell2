using System;
using SpellProject.Data.Database;

namespace SpellProject.Data
{
    [Serializable]
    public class SpellData : IKeyHoldingData
    {
        public string spellKey;
        public string nameJp;
        public float manaCost;
        public SpellType spellType;
        public string description;
        string IKeyHoldingData.Key => spellKey;
    }
}