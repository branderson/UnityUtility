using UnityEngine;

namespace Assets.Utility.Behaviours
{
    public class DampedFollow : CustomMonoBehaviour
    {
        [SerializeField] private GameObject _follow;
        [SerializeField] private float _bufferDistanceSquared = 3f;
        [SerializeField] private float _speed = 1f;

        private Vector3 _velocity;
        private Vector3 _goalPos;

        private void Awake()
        {
            _goalPos = transform.position;
        }

        private void Update()
        {
            float moveDistance = SquaredDistance2(_follow.transform.position) - _bufferDistanceSquared;
            if (moveDistance > 0)
            {
                Vector2 moveDirection = Direction2(_follow.transform.position);
                _goalPos = new Vector3(transform.position.x + moveDistance * moveDirection.x, 
                    transform.position.y + moveDistance * moveDirection.y, 
                    transform.position.z);
            }

            transform.position = Vector3.SmoothDamp(transform.position, _goalPos, ref _velocity, _speed);
        }
    }
}