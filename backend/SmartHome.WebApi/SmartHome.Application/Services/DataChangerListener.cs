using SmartHome.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Application.Services
{
    public class DataChangerListener : IDataChangerListener
    {
        private readonly Dictionary<string, List<Action<string>>> _listeners = new();

        public void RegisterListener(Action<string> callback, string smartHomeId)
        {
            if (!_listeners.ContainsKey(smartHomeId))
            {
                _listeners[smartHomeId] = new List<Action<string>>();
            }
            _listeners[smartHomeId].Add(callback);
        }

        public void UnregisterListener(Action<string> callback, string smartHomeId)
        {
            if (!_listeners.ContainsKey(smartHomeId)) return;
            _listeners[smartHomeId].Remove(callback);
            if (_listeners[smartHomeId].Count == 0)
            {
                _listeners.Remove(smartHomeId);
            }
        }

        public void HandleDataChange(string smartHomeId)
        {
            // give me all listeners keys
            var keys = _listeners.Keys.ToList();
            var filteredKeys = keys.Where(key => key.Contains(smartHomeId)).ToList();
            if (filteredKeys.Count == 0) return;
            foreach (var key in filteredKeys)
            {
                foreach (var listener in _listeners[key])
                {
                    listener.Invoke(key);
                }
            }
        }
    }
}
