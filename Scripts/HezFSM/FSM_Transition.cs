using UnityEngine;

namespace HezFSM.FSM
{
    [CreateAssetMenu(menuName = "FSM/Transition")]
    public sealed class FSM_Transition : ScriptableObject
    {
        public FSM_Decision decision;
        public BaseState trueState;
        public BaseState falseState;

        public void Execute(BaseStateMachine pMachine)
        {
            if (decision.Decide(pMachine) && trueState is not FSM_StayInState)
                pMachine.currentState = trueState;
            else if (falseState is not FSM_StayInState)
                pMachine.currentState = falseState;
        }
    }
}