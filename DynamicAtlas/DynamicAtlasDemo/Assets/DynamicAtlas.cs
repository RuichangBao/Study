using System.Collections.Generic;
using UnityEngine;
[SerializeField]
public class DynamicAtlas : MonoBehaviour
{
    private const int atlasSize = 2048;
    private const int imgWidth = 275;
    private const int imgHeight = 607;
    //列数
    private const int numsX = atlasSize / imgWidth;
    //行数
    private const int numsY = atlasSize / imgHeight;


    [SerializeField]
    private Texture2D _dynamicAtlasTex;
    // 策略 分成格子
    private List<NxSpriteInfo> _spriteCacheList;
    private Dictionary<int, int> _spriteRedirectMap = new Dictionary<int, int>();

    private void Awake()
    {
        _dynamicAtlasTex = new Texture2D(atlasSize, atlasSize, TextureFormat.RGBA32, false);
        _initCacheSprite();
    }

    private void _initCacheSprite()
    {
        _spriteCacheList = new List<NxSpriteInfo>();
        for (int i = 0; i < numsX; ++i)
        {
            for (int j = 0; j < numsY; ++j)
            {
                _spriteCacheList.Add(new NxSpriteInfo(i, j, _dynamicAtlasTex, i * imgWidth, j * imgHeight, imgWidth, imgHeight));
            }
        }
    }


    public Sprite GetOrLoadSprite(Sprite sprite)
    {
        // 拿缓存
        int spriteInstanceID = sprite.GetInstanceID();
        Debug.LogError(string.Format(" name: {0} instanceid: {1}", sprite.name, spriteInstanceID));
        int index = -1;
        if (_spriteRedirectMap.TryGetValue(spriteInstanceID, out index))
        {
            NxSpriteInfo newSprite = _spriteCacheList[index];
            newSprite.AddReference();
            return newSprite.sprite;
        }

        // 检查是不是本身就是动态生成的 如果是的话 什么都不用做
        for (int i = 0; i < _spriteCacheList.Count; ++i)
        {
            NxSpriteInfo sp = _spriteCacheList[i];
            if (sp.sprite == sprite)
            {
                return sprite;
            }
        }

        // 拿不到缓存就找个空格子新增
        NxSpriteInfo emptySprite = GetEmptySprite();
        if (emptySprite != null)
        {
            // GPU上直接操作 速度快 兼容性差
            Graphics.CopyTexture(sprite.texture, 0, 0, (int)sprite.rect.x, (int)sprite.rect.y, (int)sprite.rect.width, (int)sprite.rect.height,
                                _dynamicAtlasTex, 0, 0, (int)emptySprite.sprite.rect.x, (int)emptySprite.sprite.rect.y);

            // 这里要先删除上一个的
            index = GetIndex(emptySprite);
            foreach (var redirect in _spriteRedirectMap)
            {
                if (redirect.Value == index)
                {
                    _spriteRedirectMap.Remove(redirect.Key);
                    break;
                }
            }
            _spriteRedirectMap.Add(spriteInstanceID, GetIndex(emptySprite));
            emptySprite.AddReference();
            emptySprite.sprite.name = sprite.name + "(Dynamic)";
            return emptySprite.sprite;
        }

        // 找不到空格子就直接返回sprite
        return sprite;
    }

    public void ReleaseSprite(Sprite sprite)
    {
        for (int i = 0; i < _spriteCacheList.Count; ++i)
        {
            NxSpriteInfo sp = _spriteCacheList[i];
            if (sp.sprite == sprite)
            {
                sp.RemoveReference();
                break;
            }
        }
    }

    private NxSpriteInfo GetEmptySprite()
    {
        for (int i = 0; i < _spriteCacheList.Count; ++i)
        {
            NxSpriteInfo sp = _spriteCacheList[i];
            if (sp.IsEmpty())
                return sp;
        }
        return null;
    }

    private int GetIndex(NxSpriteInfo sprite)
    {
        return sprite.x * imgWidth + sprite.y;
    }
}