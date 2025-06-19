using UnityEngine;

namespace NPC_Example.FSM
{
    public enum State
    {
        None,
        Move = 1,
        Attack = 10,
    }

    public class BehaniourBase : StateMachineBehaviour
    {
        readonly int IS_DIRTY_HASH = Animator.StringToHash("IsDirty");

        [SerializeField] State _state;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.GetComponent<MotionController>().currnet = _state;
            animator.SetBool(IS_DIRTY_HASH, false);
        }
    }
}
