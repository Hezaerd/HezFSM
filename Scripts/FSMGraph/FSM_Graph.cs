using System.Linq;
using UnityEngine;
using XNode;

using HezFSM.FSM.Graph.Nodes;

namespace HezFSM.FSM.Graph
{
    [CreateAssetMenu(menuName = "FSM/FSM Graph")]
    public class FSM_Graph : NodeGraph
    {
        private FSM_NodeState _initialState;

        public FSM_NodeState InitialState
        {
            get
            {
                if (_initialState == null)
                    _initialState = FindInitialStateNode();

                return _initialState;
            }
        }

        private FSM_NodeState FindInitialStateNode()
        {
            var initialNode = nodes.FirstOrDefault(x => x is FSM_NodeInitial);

            if (initialNode == null)
                return null;

            return (initialNode as FSM_NodeInitial).NextNode;
        }
    }
}