using SpellProject.Utility;
using UnityEngine;

namespace SpellProject.Data.Database
{
    [CreateAssetMenu(menuName = "Create AttackDatabase", fileName = "AttackDatabase", order = 0)]
    public class AttackDatabase : DatabaseBase<AttackData>
    {
        protected override DatabaseURL.SheetName GetSheetName()
        {
            return DatabaseURL.SheetName.Attack;
        }
    }
}