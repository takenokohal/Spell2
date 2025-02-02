using LitMotion;
using LitMotion.Extensions;
using R3;
using SpellProject.Battle.Domain.Core.Attack;
using SpellProject.Battle.Domain.Core.Player;
using SpellProject.Battle.Domain.Interfaces.Player;
using SpellProject.Battle.Domain.UseCase;
using Takenokohal.Utility;
using UnityEngine;

namespace SpellProject.Battle.View
{
    public class CharacterBodyView : MonoBehaviour, ICharacterBodyView
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

            var animT = _animator.transform;
            animT.localRotation = Quaternion.Euler(0, _currentRotation, 0);
            animT.localPosition = Vector3.Lerp(animT.localPosition, Vector3.zero, 0.1f);
        }

        public bool Rotation { get; set; }
    }
}