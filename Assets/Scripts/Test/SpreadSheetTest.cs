using Cysharp.Threading.Tasks;
using Data;
using Sirenix.OdinInspector;
using Takenokohal.Utility;
using UnityEngine;
using Utility;

namespace Test
{
    public class SpreadSheetTest : SerializedMonoBehaviour
    {
        [SerializeField] private SpellData spellData;
        
        [Button]
        private void Test()
        {
            UniTask.Void(async () =>
            {
                var url = DatabaseURL.GetDataURL(DatabaseURL.SheetName.Spell);
                var s = await SpreadSheetLoader.LoadData<SpellData>(url);
                foreach (var dataList in s)
                {
                   // Debug.Log(dataList.spellKey);
                }

                spellData = s[0];
            });
        }
    }
}