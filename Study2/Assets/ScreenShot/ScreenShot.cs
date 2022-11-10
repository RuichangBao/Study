using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenShot : MonoBehaviour
{
    public Button btnScreen;
    public RawImage image;
    public Camera uiCamera;
    private Texture2D texture2D;
    private void Start()
    {
        btnScreen.onClick.AddListener(BtnScreenOnClick);
    }

    private void BtnScreenOnClick()
    {
        texture2D = ScreenCapture.CaptureScreenshotAsTexture();
        image.texture = texture2D;
    }
}
