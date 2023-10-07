using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

namespace TimeLineTest
{
    /// <summary>
    /// 继承自 PlayableBehaviour，定义 Playable 的行为
    /// </summary>
    public class ImageMixerBehavior : PlayableBehaviour
    {
        private Image img;

        public Color imageColor;
        public int param;
        /// <summary>
        /// 重写 OnBehaviourPlay 函数，第一次执行到轨道帧开始的时间
        /// </summary>
        /// <param name="playable"></param>
        /// <param name="info"></param>
        public override void OnBehaviourPlay(Playable playable, FrameData info)
        {
            base.OnBehaviourPlay(playable, info);
            Debug.LogError("AAAAAAAAAAAAAA");
        }

        /// <summary>
        /// 重写 ProcessFrame 函数，Timeline 开始执行，直到所有轨道结束，每帧都会调用这个方法
        /// </summary>
        /// <param name="playable"></param>
        /// <param name="info"></param>
        /// <param name="playerData">绑定对象 类型为：ImageTrack 类设置的 TrackBindingType 类型 Image</param>
        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            Color blendColor = Color.clear;

            // 转换为绑定对象 Image
            img = playerData as Image;
            int inputCount = playable.GetInputCount();
            Debug.LogError("inputCount"+inputCount);
            if (null != img && inputCount > 0)
            {
                for (int i = 0; i < inputCount; i++)
                {
                    float weight = playable.GetInputWeight(i);
                    ImageMixerBehavior imageMixerBehavior = ((ScriptPlayable<ImageMixerBehavior>)playable.GetInput(i)).GetBehaviour();

                    // 获取颜色值
                    blendColor += imageMixerBehavior.imageColor * weight;
                }

                // 给绑定的 Image 对象设置颜色
                img.color = blendColor;
            }
            Debug.LogError("CCCCCCCCCCCCCCCCCCC");
        }

        /// <summary>
        /// 执行到当前轨道帧 End Time
        /// </summary>
        /// <param name="playable"></param>
        /// <param name="info"></param>
        public override void OnBehaviourPause(Playable playable, FrameData info)
        {
            base.OnBehaviourPause(playable, info);
            if (null != img)
            {
                img.color = Color.clear;
            }
            Debug.LogError("BBBBBBBBBBBBBBBBBBBBB");
        }
    }
}
