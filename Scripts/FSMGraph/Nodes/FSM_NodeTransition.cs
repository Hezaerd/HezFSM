namespace HezFSM.FSM.Graph.Nodes
{
    [CreateNodeMenu("Transition")]
    public sealed class FSM_NodeTransition : FSM_NodeBase
    {
        public FSM_Decision decision;
        [Output] public FSM_NodeBaseState TrueState;
        [Output] public FSM_NodeBaseState FalseState;

        public void Execute(BaseStateMachineGraph pMachineGraph)
        {
            var trueState = GetFirst<FSM_NodeBaseState>(nameof(TrueState));
            var falseState = GetFirst<FSM_NodeBaseState>(nameof(FalseState));

            if (decision.Decide(pMachineGraph) && trueState is not FSM_NodeStayInState)
                pMachineGraph.currentState = trueState;
            else if (falseState is not FSM_NodeStayInState)
                pMachineGraph.currentState = falseState;
        }
    }
}