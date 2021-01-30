using Fluent;

public abstract class MyFluentDialogue : FluentScript
{
    public override void OnFinish() { ExamplePlayer.Instance.CanMove = true; }
    public override void OnStart() { ExamplePlayer.Instance.CanMove = false; }
}
