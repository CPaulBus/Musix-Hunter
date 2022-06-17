public interface ISongManagerSub<T>
{
    bool letStart { get;}
    void HealthDecrease(float minus);
    void MissNote();
    void NoteHit();
    void SignalReceived();
}