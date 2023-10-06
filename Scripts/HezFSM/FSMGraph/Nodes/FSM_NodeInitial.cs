using XNode;

namespace HezFSM.FSM.Graph.Nodes
{
    [CreateNodeMenu("Initial Node"), NodeTint("#00ff52")]
    public class FSM_NodeInitial : Node
    {
        [Output] public FSM_NodeState InitialNode;

        public FSM_NodeState NextNode
        {
            get
            {
                var port = GetOutputPort("InitialNode");

                if (port == null || port.ConnectionCount == 0)
                    return null;

                return port.Connection.node as FSM_NodeState;
            }
        }
    }
}