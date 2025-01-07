using System;
using SpellProject.Data.Database;

namespace SpellProject.Data
{
    [Serializable]
    public class AttackData : IKeyHoldingData
    {
        public string attackKey;
        public int power;
        public Attribute attribute;
        public string Key => attackKey;
    }
}