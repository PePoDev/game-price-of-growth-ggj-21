using UnityEngine;

namespace Events
{
    public class EventPlayAnimation : MonoBehaviour, IEvent
    {
        public string actionName;
        public string eventName;
        public Animator targetAnimator;

        public void Trigger()
        {
        }

        public string GetActionName() => actionName;
        public string GetEventName() => eventName;
    }
}