using UnityEngine;

namespace HezFSM.FSM
{
    public abstract class FSM_Action : ScriptableObject
    {
        public abstract void OnEnter(BaseStateMachine pMachine);

        public abstract void Execute(BaseStateMachine pMachine);

        public abstract void OnExit(BaseStateMachine pMachine);
    }
}