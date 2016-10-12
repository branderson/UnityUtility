using Assets.Utility.Static;
using UnityEngine;

namespace Assets.Utility.Behaviours
{
    /// <summary>
    /// Defines an initial z-axis position
    /// </summary>
    public class SetInitialZ : MonoBehaviour
    {
        [SerializeField] private float _z = 0;

        private void Awake()
        {
            transform.SetAxisPosition(Axis.Z, _z);
        }
    }
}