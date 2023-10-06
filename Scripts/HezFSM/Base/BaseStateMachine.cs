using System;
using System.Collections.Generic;
using UnityEngine;

namespace HezFSM.FSM
{
    public class BaseStateMachine : MonoBehaviour
    {
        [SerializeField] private BaseState _initialState;

        private BaseState _currentState;

        public BaseState currentState

        {
            get => _currentState;
            set => ChangeState(value);
        }

        private Dictionary<Type, Component> _cachedComponents;

        private void Awake()
        {
            Init();
            _cachedComponents = new Dictionary<Type, Component>();
        }

        private void Update()
        {
            Execute();
        }

        public virtual void Init()
        {
            _currentState = _initialState;
        }

        public virtual void Execute()
        {
            _currentState.Execute(this);
        }

        public void ChangeState(BaseState newState)
        {
            if (_currentState != null)
                _currentState.OnExit(this);

            _currentState = newState;
            _currentState.OnEnter(this);
        }

        public new T GetComponent<T>() where T : Component
        {
            if (_cachedComponents.ContainsKey(typeof(T)))
                return _cachedComponents[typeof(T)] as T;

            var component = base.GetComponent<T>();
            if (component != null)
                _cachedComponents.Add(typeof(T), component);

            return component;
        }
    }
}