using NPC_Example.FSM;

namespace NPC_Example.Behaviours.BT
{
    public class Attack : Node
    {
        private bool _isRunning = false;

        public Attack(BehaviourTree tree) : base(tree)
        {
        }

        public override Result Invoke()
        {
            // 1. 현제 상태가 Attack 이면
            // Runnig
            // 아니면
            // Attack 명령 이후라면 -> Attack 진입 성공 했는지 확인
            // Attack 진입 성공한 이후라면 -> 애니메이션 종료되었으므로 success
            // 그렇지 않으면 아직 attack 전환 안함 -> 상태를 Attack으로 전환 , running

            MotionController motionController = blackboard.motionController;

            if (_isRunning)
            {
                if (motionController.currnet == State.Move)
                {
                    _isRunning = false;
                    return Result.Success;
                }

                return Result.Running;
            }
            else
            {
                motionController.ChangeState(State.Attack);
                _isRunning = true;
                return Result.Running;
            }

            return Result.Success;
        }
    }
}
