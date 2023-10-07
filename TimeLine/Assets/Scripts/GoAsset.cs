using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
/// <summary>
/// 自定义资源
/// </summary>
public class GoAsset : PlayableAsset
{
    public int myInt;
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        return Playable.Create(graph);
    }
}