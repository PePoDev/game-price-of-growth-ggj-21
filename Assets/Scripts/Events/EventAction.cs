using System.Collections;
using Objective;
using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    public class EventAction : MonoBehaviour, IEvent
    {
        public string actionName;
        public string eventName;
        public bool disableOnCompleted = false;
        
        public UnityEvent onAction;

        public void Trigger()
        {
            if (disableOnCompleted)
            {
                gameObject.tag = "Untagged";
            }
            
            onAction.Invoke();
        }
        
        public string GetActionName() => actionName;
        public string GetEventName() => eventName;
    }
}