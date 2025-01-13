using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Takenokohal.Utility
{
    public static class MonoBehaviourExtension
    {
        public static UniTask MyDelay(this MonoBehaviour monoBehaviour, float duration)
        {
            return UniTask.Delay((int)(duration * 1000), cancellationToken: monoBehaviour.destroyCancellationToken);
        }
    }
}