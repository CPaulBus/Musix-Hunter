using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SongManager : MonoBehaviour, ISongManager, ISongManagerSub<bool>
{
    [SerializeField] private AudioSource theMusic;
    [SerializeField] private GameObject loadingScreen;

    #region Variables
    private bool startPlaying;
    private bool letStart = false;
    private bool isDone;
    private bool check;
    //public float timePlaying;
    private float clipLength;
    #endregion

    #region Interface
    bool ISongManagerSub<bool>.letStart
    {
        get { return letStart; }
    }    
    private IScoreManager scoreManager;
    private IMultiplierHandler multiplierHandler;
    private INoteScroller<bool> noteScroll;
    #endregion

    public static SongManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        scoreManager = GetComponent<ScoreManager>();
        multiplierHandler = GetComponent<MultiplierHandlerV2>();
        noteScroll = GameObject.Find("Note Holder").GetComponent<NoteScroller>();

        Application.targetFrameRate = 120;      //Sets the application to 120 frame rate
    }

    // Update is called once per frame
    void Update()
    {
        HealthChecker();        //Player health check

        GameStarter();      //Checks if the loading screen is gone.

        ClipChecker();      //SongManager will keep checking the song for
                            //transition to GameOver Screen.
    }

    private void GameStarter()
    {
        if (!startPlaying && letStart)
        {
            startPlaying = true;
            noteScroll.hasStarted = true;
            clipLength = theMusic.clip.length;
            StartCoroutine(DelayTime());
        }
    }

    private void ClipChecker()
    {
        if (check)
            clipLength -= Time.deltaTime;

        if (clipLength < 0f)                    //This will check the song if it is finished.
        {
            check = false;
            scoreManager.SaveScore();
            SceneManager.LoadScene("GameOver");
        }
    }

    private void HealthChecker()
    {
        if (PlayerHealth.instance.isDead)
        {
            scoreManager.SaveScore();
            SceneManager.LoadScene("GameOver");
        }

    }
    public void SignalReceived()        //This is for the Timeline Signal...
    {
        letStart = true;
    }

    public void NoteHit()
    {
        scoreManager.SetNoteHit(1);
        scoreManager.AddCombo(1);

        multiplierHandler.MultiplierChecker();

        scoreManager.ComboChecker();
        scoreManager.ComboGameObjectActivator(true);

        scoreManager.SetCurrScore();
    }

    public void MissNote()
    {
        HealthDecrease(10f);
        multiplierHandler.SetMultiplier(1);
        scoreManager.SetCombo(0);
        scoreManager.ComboGameObjectActivator(false);
    }

    public void HealthDecrease(float minus)
    {
        PlayerHealth.instance.HealthDecrease(minus);
    }

    #region IEnumerator
    IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(0.83f);
        GameObject.Destroy(loadingScreen);
        theMusic.Play();
        check = true;
    }
    #endregion
}