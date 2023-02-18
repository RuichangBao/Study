using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public DynamicAtlas dynamicAtlas;
    public Image image;

    void Start()
    {
        this.image = this.GetComponent<Image>();
        Sprite sprite = this.image.sprite;
        dynamicAtlas.GetOrLoadSprite(sprite);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
