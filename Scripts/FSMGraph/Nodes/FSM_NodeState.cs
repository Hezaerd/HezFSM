using System.Collections.Generic;

namespace HezFSM.FSM.Graph.Nodes
{
    [CreateNodeMenu("State")]
    public sealed class FSM_NodeState : FSM_NodeBaseState
    {
        public List<FSM_Action> actions;
        [Output] public List<FSM_NodeTransition> transitions;

        public void OnEnter(BaseStateMachineGraph pMachineGraph)
        {
            foreach (var action in actions)
                action.OnEnter(pMachineGraph);
        }

        public void Execute(BaseStateMachineGraph pMachineGraph)
        {
            foreach (var action in actions)
                action.Execute(pMachineGraph);

            foreach (var transition in GetAllOnPort<FSM_NodeTransition>(nameof(transitions)))
                transition.Execute(pMachineGraph);
        }

        public void OnExit(BaseStateMachineGraph pMachineGraph)
        {
            foreach (var action in actions)
                action.OnExit(pMachineGraph);
        }
    }
}