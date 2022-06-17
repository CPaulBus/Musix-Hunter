public interface IGameEventListener
{
    public void OnEventRaised();
}

public interface IGameEventListener<T>
{
    public void IntOnEventRaised(T value);
}