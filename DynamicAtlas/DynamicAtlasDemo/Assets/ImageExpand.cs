using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageExpand : Image
{
    private DynamicAtlas dynamicAtlas;


    private void Start()
    {
        this.dynamicAtlas = GameObject.Find("Main Camera").GetComponent<DynamicAtlas>();
        base.Start();
        Sprite sprite = this.sprite;
        this.sprite = dynamicAtlas.GetOrLoadSprite(sprite);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
