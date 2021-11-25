using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EditorScript
{

	[MenuItem("Editor/修改图片格式")]
	private static void ModifyTextureFormat()
	{
		string[] guids = AssetDatabase.FindAssets("", new string[] { "Assets/Resources/AssetBundle" });
		List<string> listFilePath = new List<string>();
		for (int i = 0; i < guids.Length; i++)
		{
			string assetPath = AssetDatabase.GUIDToAssetPath(guids[i]);

			if (AssetDatabase.IsValidFolder(assetPath))
			{   //文件夹排除
				continue;
			}
			listFilePath.Add(assetPath);
		}
		for (int i = 0; i < listFilePath.Count; i++)
		{
			TextureImporter textureImporter = AssetImporter.GetAtPath(listFilePath[i]) as TextureImporter;
			TextureImporterPlatformSettings textureImporterPlatformSettings = textureImporter.GetDefaultPlatformTextureSettings();
			textureImporterPlatformSettings.format = TextureImporterFormat.ARGB32;
			textureImporter.SetPlatformTextureSettings(textureImporterPlatformSettings);
			textureImporter.SaveAndReimport();   // 应用并重新导入
			AssetDatabase.ImportAsset(listFilePath[i]);
		}
	}
}