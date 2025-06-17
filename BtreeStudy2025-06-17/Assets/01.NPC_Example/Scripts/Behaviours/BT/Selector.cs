namespace NPC_Example.Behaviours.BT
{
    /// <summary>
    /// 자식들을 일련의 과정으로 처리하기위한 컴포넌트
    /// 자식 하나라도 성공하면 탐색종료후 성공 반환
    /// </summary>
    public class Seletor : Composite
    {
        public Seletor(BehaviourTree tree) : base(tree)
        {
        }

        public override Result Invoke()
        {
            Result result = Result.Failure;

            for (int i = currentChildIndex; i < children.Count; i++)
            {
                result = children[i].Invoke();

                switch (result)
                {
                    case Result.Failure:
                        {
                            currentChildIndex++;
                        }
                        break;
                    case Result.Success:
                        {
                            currentChildIndex = 0;
                            return result;
                        }
                    case Result.Running:
                        {
                            return result;
                        }
                    default:
                        throw new System.Exception("Invalid result code" + result);
                }
            }

            currentChildIndex = 0;
            return result;
        }
    }
}
