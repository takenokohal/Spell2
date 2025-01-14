using System;
using Cysharp.Threading.Tasks;
using Fusion;
using LitMotion;
using LitMotion.Extensions;
using SpellProject.Battle.Domain.BaseRules.MagicCircles;
using UnityEngine;

namespace SpellProject.Battle.View.MagicCircles
{
    public class MagicCircleView : NetworkBehaviour
    {
        private IDisposable _disposable;
        private MagicCircleParameter _magicCircleParameter;
        private bool _isActive;
        public override void FixedUpdateNetwork()
        {
            if(!_isActive)
                return;
            transform.position = _magicCircleParameter.Position();
        }

        public UniTask Activate(MagicCircleParameter magicCircleParameter)
        {
            _isActive = true;
            _magicCircleParameter = magicCircleParameter;

            gameObject.SetActive(true);
            return LMotion.Create(Vector3.zero, Vector3.one * magicCircleParameter.Size, 0.2f)
                .BindToLocalScale(transform).ToUniTask(cancellationToken: destroyCancellationToken);
        }

        public async UniTask Close()
        {
            var originScale = transform.localScale;
            await LMotion.Create(originScale, Vector3.zero, 0.2f)
                .BindToLocalScale(transform).ToUniTask(cancellationToken: destroyCancellationToken);
            gameObject.SetActive(false);
            _isActive = false;
        }
    }
}