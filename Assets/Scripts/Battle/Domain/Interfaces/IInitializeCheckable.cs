using System.Threading;
using Cysharp.Threading.Tasks;

namespace Battle.Domain.Interfaces
{
    public interface IInitializeCheckable
    {
        public bool IsInitialized { get; }


        public UniTask WaitUntilInitialize(CancellationToken cancellationToken)
        {
            return UniTask.WaitUntil(() => IsInitialized, cancellationToken: cancellationToken);
        }
    }
}