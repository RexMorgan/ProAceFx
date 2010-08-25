using System;
using System.Collections.Generic;
using ProAceFx.Infrastructure;

namespace ProAceFx.Core.Infrastructure
{
    public class StateManager : IStateManager
    {
        private readonly IStateProvider _stateProvider;
        private readonly List<Action> _actions;
        public StateManager(IStateProvider stateProvider)
        {
            _stateProvider = stateProvider;
            _actions = new List<Action>();
        }

        public void Update<T>(T instance) where T : class
        {
            _actions.Add(() => _stateProvider.Set(instance));
        }

        public void Remove<T>(T instance) where T : class
        {
            _actions.Add(() => _stateProvider.Remove<T>());
        }

        public void Commit()
        {
            _actions.ForEach(action => action());
            _actions.Clear();
        }
    }
}