using System;
using UnityEngine;
using UnityEngine.Playables;

namespace TimeLineTest
{    
    /// <summary>
     /// ���������Դ
     /// </summary>
    [Serializable]
    public class ImageAsset : PlayableAsset
    { 
        // ���õ���ɫ
        public Color imageColor;
        // ����
        public int param;
        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            // ����һ���µ� Playable(Script����)
            // ScriptPlayable<ImageMixerBehavior>.Create ʵ�ʽ�����������
            // ��һ�������� Graph
            // �ڶ��������� ���Ǵ��������Playable���ռ���������Ĭ�ϲ���д��ô����0������
            var playable = ScriptPlayable<ImageMixerBehavior>.Create(graph);

            // ͨ�� GetBehaviour ��ȡ���洴���� ImageMixerBehavior ����ʵ��
            var imageMixerBehavior = playable.GetBehaviour();
            // �������Դ������ֵ�� imageMixerBehavior
            imageMixerBehavior.imageColor = imageColor;
            imageMixerBehavior.param = param;

            // ���� Playable ����ʵ����Unity��������Զ�����
            return playable;
        }
    }
}