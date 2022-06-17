using UnityEngine.Timeline;

public interface ITimelineManager
{
    void TimelinePause();
    void TimelinePlay();
    void TimelinePlay(TimelineAsset timeline);
    void TimelineStop();
}