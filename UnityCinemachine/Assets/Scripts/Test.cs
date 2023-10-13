using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Button Btn;
    public CinemachineImpulseSource cinemachineImpulse;

    void Start()
    {
        //Debug.LogError
        Btn.onClick.AddListener(BtnOnClick);
    }

 

    private void BtnOnClick()
    {
        cinemachineImpulse.GenerateImpulse();
    }
}