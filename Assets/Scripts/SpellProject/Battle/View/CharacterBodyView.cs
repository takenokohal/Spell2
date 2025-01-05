using LitMotion;
using LitMotion.Extensions;
using SpellProject.Battle.Domain.Core.Attack;
using SpellProject.Battle.Domain.Interfaces.Attack;
using SpellProject.Battle.Domain.Interfaces.Player;
using UnityEngine;

namespace SpellProject.Battle.View
{
    public class CharacterBodyView : MonoBehaviour, ICharacterBodyView, IAttackPassiveView
    {
        [SerializeField] private float rotationValue = 120f;
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

        public bool Rotation { get; set; }


        //ネットワーク系は後で別クラスに入れる。
        //  [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
        private void OnHitAnimationRpc()
        {
            LMotion.Shake
                .Create(Vector3.zero, new Vector3(2, 2), 0.2f)
                .BindToLocalPosition(_animator.transform);
        }

        public void OnAttacked(AttackParameter attackParameter)
        {
            OnHitAnimationRpc();
        }
    }
}