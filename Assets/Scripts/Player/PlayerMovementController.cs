using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        public float movementSpeed = 1f;
    
        private Rigidbody2D _rigid;
        private float _movingSpeed = 0f;
        private int _lastDirection = 1;
        
        public float GetMovingSpeed() => _movingSpeed;
        public int GetDirection() => _lastDirection;
        
        private void Awake()
        {
            _rigid = GetComponent<Rigidbody2D>();
        }

        public void EnablePlayerMovementAfter(float time)
        {
            StartCoroutine(Show());
            IEnumerator Show()
            {
                yield return new WaitForSeconds(time);
                enabled = true;
            }
        }
        
        private void FixedUpdate()
        {
            var currentPos = _rigid.position;
            var horizontalInput = Input.GetAxis(Statics.INPUT_HORIZONTAL);
            var verticalInput = Input.GetAxis(Statics.INPUT_VERTICAL);

            Lebug.Log("Horizontal Input", horizontalInput, "Player");
            Lebug.Log("Vertical Input", verticalInput, "Player");
            
            var inputVector = new Vector2(horizontalInput, verticalInput);
            inputVector = Vector2.ClampMagnitude(inputVector, 1);
            var movement = inputVector * movementSpeed;
            var newPos = currentPos + movement * Time.fixedDeltaTime;

            _movingSpeed =  math.abs(horizontalInput);
            if (horizontalInput > 0) _lastDirection = 1;
            if (horizontalInput < 0) _lastDirection = -1;
            
            _rigid.MovePosition(newPos);
        }
    }
}
