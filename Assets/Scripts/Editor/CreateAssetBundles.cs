using UnityEditor;
using System.IO;
using UnityEngine;
using UnityEditor.Build.Reporting;


public class CreateAssetBundles 
{
    [MenuItem("Test/Build AsssetBundles")]
    static void BuildAssetBundles()
    {   
        #if UNITY_EDITOR
        string assetBundleDirectory = "Assets/AssetBundles";

        if(!Directory.Exists(assetBundleDirectory))
            Directory.CreateDirectory(assetBundleDirectory);
        
        // 타겟 플랫폼에 맞춰 빌드 (Windows/Android/iOS 등)
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
        #endif
    }
}
