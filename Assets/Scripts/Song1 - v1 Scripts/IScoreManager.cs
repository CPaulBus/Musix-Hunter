public interface IScoreManager
{
    void ComboChecker();
    void ComboGameObjectActivator(bool activate);
    void SaveScore();
    void SetCombo(int v);
    void SetCurrScore();
    void SetNoteHit(int hit);
    void AddCombo(int v);
}