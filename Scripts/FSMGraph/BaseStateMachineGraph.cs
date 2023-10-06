using UnityEngine;
using HezFSM.FSM.Graph.Nodes;

namespace HezFSM.FSM.Graph
{
    public class BaseStateMachineGraph : BaseStateMachine
    {
        [SerializeField] private FSM_Graph _graph;

        private new FSM_NodeBaseState _currentState;

        public new FSM_NodeBaseState currentState
        {
            get => _currentState;
            set => ChangeState(value);
        }

        public override void Init()
        {
            currentState = _graph.InitialState;
        }

        public override void Execute()
        {
            ((FSM_NodeState)currentState).Execute(this);
        }

        public void ChangeState(FSM_NodeBaseState newState)
        {
            if (_currentState != null)
                ((FSM_NodeState)_currentState).OnExit(this);

            _currentState = newState;
            ((FSM_NodeState)_currentState).OnEnter(this);
        }
    }
}