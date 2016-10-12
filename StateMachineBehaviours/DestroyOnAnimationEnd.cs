using UnityEngine;

namespace Assets.Utility.StateMachineBehaviours
{
    public class DestroyOnAnimationEnd : StateMachineBehaviour
    {
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        { 
            Destroy(animator.gameObject);
        }
    }
}
