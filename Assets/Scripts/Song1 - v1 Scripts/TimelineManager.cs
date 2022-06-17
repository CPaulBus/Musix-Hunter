using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class TimelineManager : ATimelineManager
{
    public override void TimelinePlay(TimelineAsset timelineAsset)
    {
        base.TimelinePlay(timelineAsset);
    }

    public override void TimelinePause()
    {
        base.TimelinePause();
    }

    public override void TimelineStop()
    {
        base.TimelineStop();
    }

    public override void TimelinePlay()
    {
        base.TimelinePlay();
    }
}