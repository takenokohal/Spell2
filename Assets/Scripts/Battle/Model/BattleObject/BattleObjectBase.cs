using Battle.Model.Player;
using Cysharp.Threading.Tasks;
using Fusion;
using UnityEngine;

namespace Battle.Model.BattleObject
{
    public abstract class BattleObjectBase : NetworkBehaviour
    {
        protected AllPlayerManager AllPlayerManager { get; private set; }

        public bool IsInitialized { get; private set; }

        public UniTask WaitUntilInitialized =>
            UniTask.WaitUntil(() => IsInitialized, cancellationToken: destroyCancellationToken);

        public class ConstructParameter
        {
            public ConstructParameter(AllPlayerManager allPlayerManager)
            {
                AllPlayerManager = allPlayerManager;
            }

            public AllPlayerManager AllPlayerManager { get; }
        }

        public void Construct(ConstructParameter constructParameter)
        {
            AllPlayerManager = constructParameter.AllPlayerManager;
            
            InitializeOnChild();

            IsInitialized = true;
        }

        protected virtual void InitializeOnChild()
        {
        }
    }
}