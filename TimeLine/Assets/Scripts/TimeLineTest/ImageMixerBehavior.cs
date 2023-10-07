using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

namespace TimeLineTest
{
    /// <summary>
    /// �̳��� PlayableBehaviour������ Playable ����Ϊ
    /// </summary>
    public class ImageMixerBehavior : PlayableBehaviour
    {
        private Image img;

        public Color imageColor;
        public int param;
        /// <summary>
        /// ��д OnBehaviourPlay ��������һ��ִ�е����֡��ʼ��ʱ��
        /// </summary>
        /// <param name="playable"></param>
        /// <param name="info"></param>
        public override void OnBehaviourPlay(Playable playable, FrameData info)
        {
            base.OnBehaviourPlay(playable, info);
            Debug.LogError("AAAAAAAAAAAAAA");
        }

        /// <summary>
        /// ��д ProcessFrame ������Timeline ��ʼִ�У�ֱ�����й��������ÿ֡��������������
        /// </summary>
        /// <param name="playable"></param>
        /// <param name="info"></param>
        /// <param name="playerData">�󶨶��� ����Ϊ��ImageTrack �����õ� TrackBindingType ���� Image</param>
        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            Color blendColor = Color.clear;

            // ת��Ϊ�󶨶��� Image
            img = playerData as Image;
            int inputCount = playable.GetInputCount();
            Debug.LogError("inputCount"+inputCount);
            if (null != img && inputCount > 0)
            {
                for (int i = 0; i < inputCount; i++)
                {
                    float weight = playable.GetInputWeight(i);
                    ImageMixerBehavior imageMixerBehavior = ((ScriptPlayable<ImageMixerBehavior>)playable.GetInput(i)).GetBehaviour();

                    // ��ȡ��ɫֵ
                    blendColor += imageMixerBehavior.imageColor * weight;
                }

                // ���󶨵� Image ����������ɫ
                img.color = blendColor;
            }
            Debug.LogError("CCCCCCCCCCCCCCCCCCC");
        }

        /// <summary>
        /// ִ�е���ǰ���֡ End Time
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
