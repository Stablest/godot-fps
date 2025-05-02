namespace Components.StateMachine;

public interface IState
{
    public void PreExecution();
    public void PostExecution();
    public void Execute(float delta);
}