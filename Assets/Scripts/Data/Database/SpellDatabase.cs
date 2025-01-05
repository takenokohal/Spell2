﻿using UnityEngine;
using Utility;

namespace Data.Database
{
    [CreateAssetMenu(menuName = "Create SpellDatabase", fileName = "SpellDatabase", order = 0)]
    public class SpellDatabase : DatabaseBase<SpellData, SpellDatabase>
    {
        protected override DatabaseURL.SheetName GetSheetName()
        {
            return DatabaseURL.SheetName.Spell;
        }
    }
}