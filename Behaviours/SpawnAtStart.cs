using UnityEngine;

namespace Assets.Utility.Behaviours
{
    public class SpawnAtStart : CustomMonoBehaviour
    {
        [SerializeField] private GameObject _spawn;

        private void Start()
        {
            Instantiate(_spawn);
        }
    }
}