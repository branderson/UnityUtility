using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Utility
{
    public class SelectRandomSpriteOnStart : MonoBehaviour
    {
        [SerializeField] private List<Sprite> _sprites; 

        private void Start ()
        {
            GetComponent<SpriteRenderer>().sprite = _sprites[Random.Range(0, _sprites.Count)];
        }
    }
}
