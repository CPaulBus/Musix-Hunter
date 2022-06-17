using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public abstract class ATimelineManager : MonoBehaviour, ITimelineManager
{
    [SerializeField] private PlayableDirector _playDirector;

    private void Start()
    {
        _playDirector = GetComponent<PlayableDirector>();
    }

    public virtual void TimelinePlay(TimelineAsset timelineAsset)
    {
        _playDirector.Play(timelineAsset);
    }

    public virtual void TimelinePause()
    {
        _playDirector.Pause();
    }

    public virtual void TimelineStop()
    {
        _playDirector.Stop();
    }

    public virtual void TimelinePlay()
    {
        _playDirector.Play();
    }
}