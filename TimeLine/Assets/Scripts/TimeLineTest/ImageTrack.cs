using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

namespace TimeLineTest
{
    /// <summary>
    /// �Զ��� Timeline ��� ImageTrack ���������ⶨ��
    /// �� Timeline ��ӹ��λ���Ҽ����¼� TimeTest->ImageTrack
    /// </summary>
    [TrackColor(0.13f, 0.18f, 0.9f)]     // �����ɫ
    [TrackBindingType(typeof(Image))]    // �󶨶�������Ϊ UnityEngine.UI.Image
    [TrackClipType(typeof(ImageAsset))]  // ���֡����Ϊ ImageAsset (Ҳ��Ҫ�Զ���)
    public class ImageTrack : TrackAsset
    {
        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            return ScriptPlayable<ImageMixerBehavior>.Create(graph, inputCount);
        }
    }
}
