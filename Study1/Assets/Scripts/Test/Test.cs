using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Test : MonoBehaviour
{
    public Button btn1;
    public Button btn2;
  
    class TestClass1
    {
        public TestClass1(int a)
        {
        }
        ~TestClass1()
        {
            Debug.LogError("TestClass1 析构函数");
        }
        public TestClass2 testClass2;
        public string a = "sdfsdaf";
        public string b = "sdafdsafsdf";
        public string c = "1000";
    }
    class TestClass2
    {
        public TestClass2()
        {

        }
        ~TestClass2()
        {
            Debug.LogError("TestClass2 析构函数");
        }
        public TestClass1 testClass1;
        public string a = "sdfsdaf";
        public string b = "sdafdsafsdf";
        public string c = "1000";
    }
    void Start()
    {
        btn1.onClick.AddListener(OnBtn1Click);
        btn2.onClick.AddListener(OnBtn2Click);
    }

    private void OnBtn1Click()
    {
        for (int i = 0; i < 10; i++)
        {
            string str = i.ToString();
            TestClass1 testClass1 = new TestClass1(1);
            TestClass2 testClass2 = new TestClass2();
            testClass1.testClass2 = testClass2;
            testClass2.testClass1 = testClass1;
        }
    }

    private void OnBtn2Click()
    {
        GC.Collect();
        //GC.WaitForPendingFinalizers();
        //GC.Collect();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [ContextMenu("设置变量")]
    public void OnEditorAssignVarible()
    {
        btn1 = GameObject.Find("Canvas/btn1").GetComponent<Button>();
        btn2 = GameObject.Find("Canvas/btn2").GetComponent<Button>();
    }
}
