using UnityEngine;

namespace HezFSM.FSM
{
    public class BaseState : ScriptableObject
    {
        public virtual void OnEnter(BaseStateMachine machine)
        { }

        public virtual void Execute(BaseStateMachine machine)
        { }

        public virtual void OnExit(BaseStateMachine machine)
        { }
    }
}