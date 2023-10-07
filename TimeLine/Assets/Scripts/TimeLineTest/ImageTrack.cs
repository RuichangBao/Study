using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

namespace TimeLineTest
{
    /// <summary>
    /// 自定义 Timeline 轨道 ImageTrack （名字随意定）
    /// 在 Timeline 添加轨道位置右键，新加 TimeTest->ImageTrack
    /// </summary>
    [TrackColor(0.13f, 0.18f, 0.9f)]     // 轨道颜色
    [TrackBindingType(typeof(Image))]    // 绑定对象类型为 UnityEngine.UI.Image
    [TrackClipType(typeof(ImageAsset))]  // 轨道帧类型为 ImageAsset (也需要自定义)
    public class ImageTrack : TrackAsset
    {
        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            return ScriptPlayable<ImageMixerBehavior>.Create(graph, inputCount);
        }
    }
}
