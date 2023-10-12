using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public CinemachineBrain cinemachineBrain;
    public Button Btn;
    public CinemachineVirtualCamera[] cinemachineVirtualCameras;
    private int index = 0;


    void Start()
    {
        Btn.onClick.AddListener(BtnOnClick);
        cinemachineBrain.m_CameraCutEvent = TestAAA();
    }

 

    private void BtnOnClick()
    {
        index++;
        index %= 2;
        cinemachineVirtualCameras[index].Priority += 20;
        //cinemachineBrain.re
    }
}