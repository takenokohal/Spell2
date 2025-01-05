using System.Threading;
using Cysharp.Threading.Tasks;

namespace Takenokohal.Utility
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