namespace NPC_Example.Behaviours.BT
{
    [ExcludeFromBuilder]
    public class Root : Node, IParentOfChild
    {
        public Root(BehaviourTree tree) : base(tree)
        {
        }

        public Node child { get; set; }


        public void AttachChild(Node node)
        {
            child = node;
        }

        public override Result Invoke()
        {
            tree.stack.Push(child); // <- stack public 하게 바꾸고 stack 에 푸쉬해줘야함
            return Result.Success;
        }
    }
}
