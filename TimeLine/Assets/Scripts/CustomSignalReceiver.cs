using UnityEngine;
using UnityEngine.Playables;
/// <summary>
/// 自定义脚本发射器和接收器必须在同一个物体上
/// </summary>
public class CustomSignalReceiver : MonoBehaviour, INotificationReceiver
{

    public void OnNotify(Playable origin, INotification notification, object context)
    {
        CustomSignal customSignal = notification as CustomSignal;
        if (customSignal != null)
        {
            Debug.LogError(customSignal.ToString());
        }
        else
        {
            Debug.LogError("自定义信号接收器为空");
        }
    }
}