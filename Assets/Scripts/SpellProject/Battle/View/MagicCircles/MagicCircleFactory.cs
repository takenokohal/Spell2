using Cysharp.Threading.Tasks;
using Fusion;
using SpellProject.Battle.Domain.BaseRules.MagicCircles;
using SpellProject.Battle.Domain.Core;
using SpellProject.Battle.Domain.Interfaces;
using Takenokohal.Utility;
using UnityEngine;
using UnityEngine.Pool;
using VContainer;

namespace SpellProject.Battle.View.MagicCircles
{
    //いったんネットワーク中はオブジェクトプール無し！！！
    public class MagicCircleFactory : MonoBehaviour, IMagicCircleFactory
    {
        [Inject] private readonly IBattleConstDataProvider _battleConstDataProvider;
        [SerializeField] private MagicCircleView magicCirclePrefab;

        private ObjectPool<MagicCircleView> _pool;

        [Inject] private readonly NetworkRunner _networkRunner;
        [Inject] private readonly IBattleModeManager _battleModeManager;


        private void Start()
        {
            _pool = new ObjectPool<MagicCircleView>(() => Instantiate(magicCirclePrefab));
        }

        public async UniTask CreateAndWait(MagicCircleParameter magicCircleParameter)
        {
            if (_battleModeManager.BattleMode == BattleMode.Online)
            {
                var instance = _networkRunner.Spawn(magicCirclePrefab);
                instance.Activate(magicCircleParameter).Forget();
                await this.MyDelay(_battleConstDataProvider.GetBattleConstData().MagicCircleShowDuration);
                await instance.Close();
                _networkRunner.Despawn(instance.Object);
            }
            else
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

        [Rpc(RpcSources.StateAuthority, RpcTargets.Proxies, InvokeLocal = true)]
        private void CreateRpc()
        {
            CreateRpcAsync().Forget();
        }

        private async UniTaskVoid CreateRpcAsync()
        {
        }
    }
}