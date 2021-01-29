namespace Events
{
    public interface IEvent
    {
        public void Trigger();
        public string GetActionName();
        public string GetEventName();
    }
}