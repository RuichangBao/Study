using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NxSpriteInfo
{
    private int _x;
    private int _y;
    private Sprite _sprite;
    private int _referenceCount;

    private int _width;
    private int _height;

    public int x { get { return _x; } }
    public int y { get { return _y; } }

    public Sprite sprite
    {
        get { return _sprite; }
    }

    public NxSpriteInfo(int x, int y, Texture2D mainTexture, int startX, int startY, int width, int height)
    {
        _x = x;
        _y = y;
        _referenceCount = 0;

        _width = width;
        _height = height;

        _sprite = Sprite.Create(mainTexture, new Rect(startX, startY, width, height), Vector2.one / 2f);
    }

    public bool IsEmpty()
    {
        return _referenceCount == 0;
    }

    public void AddReference()
    {
        ++_referenceCount;
        Debug.Log(string.Format("[AddReference]Sprite:[{0},{1}] ref:{2}", x, y, _referenceCount));
    }

    public void RemoveReference()
    {
        if (_referenceCount == 0) return;
        --_referenceCount;

        Debug.Log(string.Format("[RemoveReference]Sprite:[{0},{1}] ref:{2}", x, y, _referenceCount));
    }
}