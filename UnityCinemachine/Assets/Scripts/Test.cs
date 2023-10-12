using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachineVirtualCamera;
    public CinemachineSmoothPath cinemachineSmoothPath;
    void Start()
    {
        cinemachineVirtualCamera.enabled = true;

    }
}