using UnityEngine;

namespace Assets.Scripts.Utility
{
    public class TimedDestroy : MonoBehaviour
    {
        [SerializeField] private int _countDown;

        private void Update()
        {
            _countDown -= 1;
            if (_countDown <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
