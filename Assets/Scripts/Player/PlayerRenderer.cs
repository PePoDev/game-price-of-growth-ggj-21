using UnityEngine;

namespace Player
{
    public class PlayerRenderer : MonoBehaviour
    {
    

        private Animator _animator;
        private int _lastDirection;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetDirection(Vector2 direction)
        {
            string[] directionArray = null;
            if (direction.magnitude < .01f) directionArray = Statics.StaticDirections;
            else
            {
                directionArray = Statics.RunDirections;
                _lastDirection = DirectionToIndex(direction, 8);
            }

            _animator.Play(directionArray[_lastDirection]);
        }

        private static int DirectionToIndex(Vector2 direction, int sliceCount){
            var angle = Vector2.SignedAngle(Vector2.up, direction.normalized) + 360f / sliceCount / 2;
        
            return Mathf.FloorToInt((angle < 0? angle + 360 : angle) / 360f / sliceCount);
        }

        public static int[] AnimatorStringArrayToHashArray(string[] animationArray)
        {
            var hashArray = new int[animationArray.Length];
            for (var i = 0; i < animationArray.Length; i++) hashArray[i] = Animator.StringToHash(animationArray[i]);
        
            return hashArray;
        }
    }
}
