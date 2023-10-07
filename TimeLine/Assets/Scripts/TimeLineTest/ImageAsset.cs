using System;
using UnityEngine;
using UnityEngine.Playables;

namespace TimeLineTest
{
    /// <summary>
    /// 创建轨道资源
    /// </summary>
    [Serializable]
    public class ImageAsset : PlayableAsset
    {
        // 设置的颜色
        public Color imageColor;
        // 参数
        public int param;

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            // 创建一个新的 Playable(Script类型)
            // ScriptPlayable<ImageMixerBehavior>.Create 实际接收两个参数
            // 第一个参数是 Graph
            // 第二个参数是 我们创建的这个Playable接收几个参数，默认不填写那么就是0个输入
            ScriptPlayable<ImageMixerBehavior> playable = ScriptPlayable<ImageMixerBehavior>.Create(graph);

            // 通过 GetBehaviour 获取上面创建的 ImageMixerBehavior 类型实例
            ImageMixerBehavior imageMixerBehavior = playable.GetBehaviour();
            // 将轨道资源参数赋值给 imageMixerBehavior
            imageMixerBehavior.imageColor = imageColor;
            imageMixerBehavior.param = param;
            // 返回 Playable 类型实例，Unity会帮我们自动连接
            return playable;
        }
    }
}
