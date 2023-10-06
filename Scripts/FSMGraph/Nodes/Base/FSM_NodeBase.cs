using System.Collections.Generic;
using XNode;

namespace HezFSM.FSM.Graph
{
    public class FSM_NodeBase : Node
    {
        [Input(backingValue = ShowBackingValue.Never)] public FSM_NodeBase entry;

        protected IEnumerable<T> GetAllOnPort<T>(string pFieldName) where T : FSM_NodeBase
        {
            NodePort port = GetOutputPort(pFieldName);
            for (var portIndex = 0; portIndex < port.ConnectionCount; portIndex++)
                yield return port.GetConnection(portIndex).node as T;
        }

        protected T GetFirst<T>(string pFieldName) where T : FSM_NodeBase
        {
            NodePort port = GetOutputPort(pFieldName);
            if (port.ConnectionCount > 0)
                return port.GetConnection(0).node as T;

            return null;
        }
    }
}