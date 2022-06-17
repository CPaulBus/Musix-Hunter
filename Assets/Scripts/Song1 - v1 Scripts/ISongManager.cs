public interface ISongManager
{
    void HealthDecrease(float minus);
    void MissNote();
    void NoteHit();
    void SignalReceived();
}