using UnityEngine;
using UnityEngine.Playables;
/// <summary>
/// �Զ���ű��������ͽ�����������ͬһ��������
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
            Debug.LogError("�Զ����źŽ�����Ϊ��");
        }
    }
}