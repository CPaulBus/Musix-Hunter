public interface IMenuManager<T>
{
    public int trackSelect { get; set; }
    void Back();
    void PlayGame();
    void playWithChosenSong();
    void QuitGame();
    void SetTrackSelect(int requestTrack);
}