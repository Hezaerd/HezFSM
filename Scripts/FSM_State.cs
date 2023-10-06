using System.Collections.Generic;
using UnityEngine;

namespace HezFSM.FSM
{
    [CreateAssetMenu(menuName = "FSM/State")]
    public class FSM_State : BaseState
    {
        public List<FSM_Action> Actions = new List<FSM_Action>();
        public List<FSM_Transition> Transitions = new List<FSM_Transition>();

        public override void OnEnter(BaseStateMachine pMachine)
        {
            foreach (var action in Actions)
                action.OnEnter(pMachine);
        }

        public override void Execute(BaseStateMachine pMachine)
        {
            foreach (var action in Actions)
                action.Execute(pMachine);

            foreach (var transition in Transitions)
                transition.Execute(pMachine);
        }
    }
}