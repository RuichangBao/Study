using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnumCtrl : MonoBehaviour
{
    enum TestEnum
    {
        Enum1,
        Enum2,
    }

    void Start()
    {
        Dictionary<TestEnum, int> keyValuePairs = new Dictionary<TestEnum, int>();
        keyValuePairs.Add(TestEnum.Enum1, 1);
        keyValuePairs.Add(TestEnum.Enum2, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }
    [ContextMenu("设置变量")]
    public void OnEditorAssignVarible()
    {

    }
}