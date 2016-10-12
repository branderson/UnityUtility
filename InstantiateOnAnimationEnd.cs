using UnityEngine;

namespace Assets.Scripts.Utility
{
    public class InstantiateOnAnimationEnd : StateMachineBehaviour
    {
        [SerializeField] private GameObject _prefab;

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            GameObject instance = Instantiate(_prefab, animator.transform.position, animator.transform.rotation) as GameObject;
            instance.transform.parent = animator.transform.parent;
        }
    }
}
