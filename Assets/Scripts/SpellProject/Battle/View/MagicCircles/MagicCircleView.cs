using System;
using Cysharp.Threading.Tasks;
using LitMotion;
using LitMotion.Extensions;
using R3;
using R3.Triggers;
using UnityEngine;

namespace SpellProject.Battle.View.MagicCircles
{
    public class MagicCircleView : MonoBehaviour
    {
        private IDisposable _disposable;

        public UniTask Activate(MagicCircleParameter magicCircleParameter)
        {
            _disposable = this.FixedUpdateAsObservable().Subscribe(_ =>
            {
                transform.position = magicCircleParameter.Position();
            }).AddTo(this);
            gameObject.SetActive(true);
            return LMotion.Create(Vector3.zero, Vector3.one * magicCircleParameter.Size, 0.2f)
                .BindToLocalScale(transform).ToUniTask(cancellationToken: destroyCancellationToken);
        }

        public async UniTask Close()
        {
            var originScale = transform.position;
            await LMotion.Create(originScale, Vector3.zero, 0.2f)
                .BindToLocalScale(transform).ToUniTask(cancellationToken: destroyCancellationToken);
            gameObject.SetActive(false);

            _disposable.Dispose();
            _disposable = null;
        }
    }
}