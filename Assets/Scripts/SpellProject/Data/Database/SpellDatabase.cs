using SpellProject.Utility;
using UnityEngine;

namespace SpellProject.Data.Database
{
    [CreateAssetMenu(menuName = "Create SpellDatabase", fileName = "SpellDatabase", order = 0)]
    public class SpellDatabase : DatabaseBase<SpellData>
    {
        protected override DatabaseURL.SheetName GetSheetName()
        {
            return DatabaseURL.SheetName.Spell;
        }
    }
}