using UnityEngine;

namespace Assets.Scripts.Utility
{
    public class ConstrainPosition2D : MonoBehaviour
    {
        [SerializeField] private Vector2 _max;
        [SerializeField] private Vector2 _min;

        private void LateUpdate()
        {
            if (transform.position.x > _max.x)
            {
                transform.SetAxisPosition(Axis.X, _max.x);
            }
            if (transform.position.x < _min.x)
            {
                transform.SetAxisPosition(Axis.X, _min.x);
            }
            if (transform.position.y > _max.y)
            {
                transform.SetAxisPosition(Axis.Y, _max.y);
            }
            if (transform.position.y < _min.y)
            {
                transform.SetAxisPosition(Axis.Y, _min.y);
            }
        }
    }
}