using Cysharp.Threading.Tasks;
using SpellProject.Battle.Domain.Interfaces;
using Takenokohal.Utility;
using UnityEngine;
using UnityEngine.Pool;
using VContainer;

namespace SpellProject.Battle.View.MagicCircles
{
    public class MagicCircleFactory : MonoBehaviour
    {
        [Inject] private readonly IBattleConstDataProvider _battleConstDataProvider;
        [SerializeField] private MagicCircleView magicCirclePrefab;

        private ObjectPool<MagicCircleView> _pool;

        private void Start()
        {
            _pool = new ObjectPool<MagicCircleView>(() => Instantiate(magicCirclePrefab));
        }

        public async UniTask CreateAndWait(MagicCircleParameter magicCircleParameter)
        {
            var instance = _pool.Get();
            instance.Activate(magicCircleParameter).Forget();

            //ダウン時に魔法陣をキャンセルするかも
            //Sprite変更するかも
            await this.MyDelay(_battleConstDataProvider.GetBattleConstData().MagicCircleShowDuration);

            await instance.Close();
            _pool.Release(instance);
        }
    }
}