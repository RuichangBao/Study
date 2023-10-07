using UnityEngine;
using UnityEngine.Timeline;

public class SignalReceive : MonoBehaviour
{
    public void OnTimelineSignal()
    {
        Debug.LogError("收到信号了");
    }
}
