using Module;
using System.IO;
using UnityEditor;
using UnityEngine;

public class Build
{
    private const string ScriptAssembliesDir = "Library/ScriptAssemblies";
    private const string CodeDir = "Assets/Res/Text/";
    private const string StreamingAssetsDir = "Assets/StreamingAssets";
    private const string HotfixDll = "Hotfix.dll";
    private const string HotfixPdb = "Hotfix.pdb";

    [MenuItem("Tools/Build/Hotfix")]
    static void BuildHotfix()
    {
        if (EditorApplication.isPlayingOrWillChangePlaymode)
        {
            //AssetsConfigSettingsInspector.Export(UnityEditor.AssetDatabase.LoadAssetAtPath<AssetsConfigSettings>("Assets/Scripts/Editor/AssetBundle/Config/AssetsConfig/AssetsConfigSettings.asset"));
            //AssetsConfigSettingsInspector.Export(UnityEditor.AssetDatabase.LoadAssetAtPath<AssetsConfigSettings>("Assets/Scripts/Editor/AssetBundle/Config/AssetsConfig/NoBuildAssetsConfigSettings.asset"));
        }
        else
        {
            FileHelper.CreateDir(CodeDir);

            if (File.Exists($"{ScriptAssembliesDir}/{HotfixDll}") && File.Exists($"{ScriptAssembliesDir}/{HotfixDll}"))
            {
                File.Copy(Path.Combine(ScriptAssembliesDir, HotfixDll), Path.Combine(CodeDir, "Hotfix.dll.bytes"), true);
                File.Copy(Path.Combine(ScriptAssembliesDir, HotfixPdb), Path.Combine(CodeDir, "Hotfix.pdb.bytes"), true);
                Debug.Log($"复制Hotfix.dll、Hotfix.pdb到{CodeDir}，成功！");

                AssetDatabase.SaveAssets();
            }
            else
            {
                Debug.LogWarning($"复制Hotfix.dll、Hotfix.pdb到{CodeDir}，失败！");
            }
        }
    }


    [MenuItem("Tools/Build/Hotfix_StreamingAssetsDir")]
    static void BuildHotfix_StreamingAssetsDir()
    {
        if (EditorApplication.isPlayingOrWillChangePlaymode)
        {
            //AssetsConfigSettingsInspector.Export(UnityEditor.AssetDatabase.LoadAssetAtPath<AssetsConfigSettings>("Assets/Scripts/Editor/AssetBundle/Config/AssetsConfig/AssetsConfigSettings.asset"));
            //AssetsConfigSettingsInspector.Export(UnityEditor.AssetDatabase.LoadAssetAtPath<AssetsConfigSettings>("Assets/Scripts/Editor/AssetBundle/Config/AssetsConfig/NoBuildAssetsConfigSettings.asset"));
        }
        else
        {
            FileHelper.CreateDir(StreamingAssetsDir);

            if (File.Exists($"{ScriptAssembliesDir}/{HotfixDll}") && File.Exists($"{ScriptAssembliesDir}/{HotfixDll}"))
            {
                File.Copy(Path.Combine(ScriptAssembliesDir, HotfixDll), Path.Combine(StreamingAssetsDir, "Hotfix.dll.bytes"), true);
                File.Copy(Path.Combine(ScriptAssembliesDir, HotfixPdb), Path.Combine(StreamingAssetsDir, "Hotfix.pdb.bytes"), true);
                File.Copy(Path.Combine(ScriptAssembliesDir, HotfixDll), Path.Combine(StreamingAssetsDir, "Hotfix.dll"), true);
                File.Copy(Path.Combine(ScriptAssembliesDir, HotfixPdb), Path.Combine(StreamingAssetsDir, "Hotfix.pdb"), true);
                Debug.Log($"复制Hotfix.dll、Hotfix.pdb到{StreamingAssetsDir}，成功！");

                AssetDatabase.SaveAssets();
            }
            else
            {
                Debug.LogWarning($"复制Hotfix.dll、Hotfix.pdb到{StreamingAssetsDir}，失败！");
            }
        }
    }
}