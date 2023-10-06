using UnityEngine;

namespace HezFSM.FSM
{
    public abstract class FSM_Decision : ScriptableObject
    {
        public abstract bool Decide(BaseStateMachine pMachine);
    }
}