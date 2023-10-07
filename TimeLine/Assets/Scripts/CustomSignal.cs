using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
/// <summary>
/// 自定义信号发射类
/// </summary>
public class CustomSignal : SignalEmitter
{
    public string eventName;
    public int param;


    public override string ToString()
    {
        return "eventName:" + eventName + "    param:" + param;
    }
}
