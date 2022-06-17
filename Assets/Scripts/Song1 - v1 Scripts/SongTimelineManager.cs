using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class SongTimelineManager : ATimelineManager, ISongTimelineManager<TimelineAsset>
{
    private bool isClicked;

    public static SongTimelineManager instance;

    private void Start()
    {
        instance = this;
        isClicked = false;
    }

    public void Update()
    {
        if (Input.anyKey && !isClicked)
        {
            TimelinePlay();
            isClicked = true;
        }
    }

    public void SetisClicked()
    {
        isClicked = false;
    }

    public override void TimelinePause()
    {
        base.TimelinePause();
    }

    public override void TimelinePlay()
    {
        base.TimelinePlay();
    }

    public override void TimelinePlay(TimelineAsset timelineAsset)
    {
        base.TimelinePlay(timelineAsset);
    }

    public override void TimelineStop()
    {
        base.TimelineStop();
    }
}