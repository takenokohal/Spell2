using Battle.Model.Attack;
using Battle.Model.Player;
using Fusion;
using LitMotion;
using LitMotion.Extensions;
using UnityEngine;

namespace Battle.View
{
    public class PlayerView : NetworkBehaviour, IPlayerBodyView, IPlayerAttackHitView
    {
        [SerializeField] private float rotationValue;
        [SerializeField] private float lerpValue = 0.1f;

        private Rigidbody2D _rigidbody2D;
        private Animator _animator;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _animator = GetComponentInChildren<Animator>();
        }

        public Vector2 Position
        {
            get => _rigidbody2D.position;
            set => _rigidbody2D.position = value;
        }

        public Vector2 Velocity
        {
            get => _rigidbody2D.linearVelocity;
            set => _rigidbody2D.linearVelocity = value;
        }

        private float _currentRotation;

        private void Update()
        {
            var r = Rotation ? 1 : -1;
            _currentRotation = Mathf.Lerp(_currentRotation, r * rotationValue, lerpValue);

            _animator.transform.localRotation = Quaternion.Euler(0, _currentRotation, 0);
        }

        [Networked] public bool Rotation { get; set; }

        void IPlayerAttackHitView.OnHit(AttackParameter attackParameter)
        {
            OnHitAnimationRpc();
        }

        [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
        private void OnHitAnimationRpc()
        {
            LMotion.Shake
                .Create(Vector3.zero, new Vector3(2, 2), 0.2f)
                .BindToLocalPosition(_animator.transform);
        }
    }
}