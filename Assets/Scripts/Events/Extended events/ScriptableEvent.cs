using UnityEngine;
using System;

namespace SOPatterns.Events
{
    public class ScriptableEvent<T> : ScriptableObject 
    where T : struct
    {
        private event Action<T> Ev;

        public void AddListener(Action<T> listener) {
            Ev += listener;
        }

        public void RemoveListener(Action<T> listener) {
            Ev -= listener;
        }

        public void RaiseEvent(T eventParam) {
            Ev?.Invoke(eventParam);
        }
    }
}
