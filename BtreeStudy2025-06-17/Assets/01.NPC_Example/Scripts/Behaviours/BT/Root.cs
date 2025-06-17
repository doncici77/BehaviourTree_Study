namespace NPC_Example.Behaviours.BT
{
    public class Root : Node, IParentOfChild
    {
        // 베이스 생성자?
        public Root(BehaviourTree tree) : base(tree)
        {

        }

        // 빽킹 필드?
        public Node child { get; set; }

        public void AttachChild(Node node)
        {
            child = node;
        }

        public override Result Invoke()
        {
            // 탐색 시작
            return child.Invoke();
        }
    }
}
