using UnityEngine.Timeline;

public interface ISongTimelineManager<T>
{
    void SetisClicked();
    void TimelinePause();
    void TimelinePlay();
    void TimelinePlay(TimelineAsset timelineAsset);
    void TimelineStop();
    void Update();
}