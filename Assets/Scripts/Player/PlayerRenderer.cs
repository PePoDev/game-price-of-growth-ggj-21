using System;
using UnityEngine;

namespace Player
{
    public class PlayerRenderer : MonoBehaviour
    {
        private Animator _animator;
        private PlayerMovementController _playerMovementController;
        private SpriteRenderer _spriteRenderer;
        private int _lastDirection = 0;

        private static readonly int MovingSpeed = Animator.StringToHash("MovingSpeed");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _playerMovementController = GetComponent<PlayerMovementController>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Update()
        {
            _animator.SetFloat(MovingSpeed, _playerMovementController.GetMovingSpeed());

            if (_playerMovementController.GetDirection() != _lastDirection)
                _lastDirection = _playerMovementController.GetDirection();

            _spriteRenderer.flipX = _lastDirection == 1 ? true : false;
        }
    }
}