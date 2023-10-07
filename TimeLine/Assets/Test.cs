using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Test : MonoBehaviour
{
    public PlayableDirector playableDirector;
    // Start is called before the first frame update
    void Start()
    {
        IEnumerable<PlayableBinding> outputs = playableDirector.playableAsset.outputs;
        foreach (PlayableBinding playableBinding in outputs)
        {
            Debug.LogError(playableBinding.streamName);

            AnimationTrack animationTrack = playableBinding.sourceObject as AnimationTrack;
            if (animationTrack != null)
            {
                var timelineClip = animationTrack.GetClips();
                //for (int i = 0; i < timelineClip.Length; i++)
                //{
                //    Debug.LogError("b:" + timelineClip[i].animationClip.name);
                //}
            }
            //bindingDict[pb.streamName].sourceObject as TrackAsset
        }
        //playableDirector.GetClips
    }
    /// <summary>
    /// 初始化
    /// </summary>
    //private void InitAttributes()
    //{
    //    bindingDict.Clear();
    //    dicTimelineClips.Clear();
    //    foreach (PlayableBinding pb in playableDirector.playableAsset.outputs)
    //    {
    //        if (!bindingDict.ContainsKey(pb.streamName))
    //        {
    //            bindingDict.Add(pb.streamName, pb);
    //            Debug.Log(pb.streamName);
    //            var track = bindingDict[pb.streamName].sourceObject as TrackAsset;
    //            if (track != null)
    //            {
    //                List<double> timelineClips = new List<double>();
    //                foreach (TimelineClip clip in track.GetClips())
    //                {
    //                    timelineClips.Add(clip.duration);
    //                    Debug.Log("name:" + clip.displayName + "时间:" + clip.duration);
    //                }
    //                dicTimelineClips.Add(pb.streamName, timelineClips);
    //            }
    //        }
    //    }
    //}
}
