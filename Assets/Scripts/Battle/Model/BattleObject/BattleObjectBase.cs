using Battle.Model.Player;
using Cysharp.Threading.Tasks;
using Fusion;
using UnityEngine;

namespace Battle.Model.BattleObject
{
    //生成した側だけが処理
    public abstract class BattleObjectBase : NetworkBehaviour
    {
        protected AllPlayerManager AllPlayerManager { get; private set; }
        
        protected PlayerKey OwnerKey { get; private set; }

        public bool IsInitialized { get; private set; }

        public UniTask WaitUntilInitialized =>
            UniTask.WaitUntil(() => IsInitialized, cancellationToken: destroyCancellationToken);

        public class ConstructParameter
        {
            public ConstructParameter(PlayerKey playerKey, AllPlayerManager allPlayerManager)
            {
                PlayerKey = playerKey;
                AllPlayerManager = allPlayerManager;
            }

            public AllPlayerManager AllPlayerManager { get; }
            public PlayerKey PlayerKey { get; }
        }

        public void Construct(ConstructParameter constructParameter)
        {
            AllPlayerManager = constructParameter.AllPlayerManager;
            OwnerKey = constructParameter.PlayerKey;
            
            InitializeOnChild();

            IsInitialized = true;
        }

        protected virtual void InitializeOnChild()
        {
        }
    }
}