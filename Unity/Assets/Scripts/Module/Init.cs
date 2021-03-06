using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Module
{
    public class Init : MonoBehaviour
    {
        ILRuntime.Runtime.Enviorment.AppDomain appdomain;
        void Start()
        {
            LocalizedData.SaveObject<Dictionary<string,string>>("a",new Dictionary<string, string>(){ { "a", "a" } , { "b", "b" } });
            var a = LocalizedData.GetObject<Dictionary<string, string>>("a");
            Debug.Log(a);

            StartCoroutine(LoadILRuntime());
        }

        IEnumerator LoadILRuntime()
        {
            appdomain = new ILRuntime.Runtime.Enviorment.AppDomain();
#if UNITY_ANDROID
    WWW www = new WWW(Application.streamingAssetsPath + "/Hotfix.dll");
#else
            WWW www = new WWW("file:///" + Application.streamingAssetsPath + "/Hotfix.dll");
#endif
            while (!www.isDone)
                yield return null;
            if (!string.IsNullOrEmpty(www.error))
                Debug.LogError(www.error);
            byte[] dll = www.bytes;
            www.Dispose();
#if UNITY_ANDROID
    www = new WWW(Application.streamingAssetsPath + "/Hotfix.pdb");
#else
            www = new WWW("file:///" + Application.streamingAssetsPath + "/Hotfix.pdb");
#endif
            while (!www.isDone)
                yield return null;
            if (!string.IsNullOrEmpty(www.error))
                Debug.LogError(www.error);
            byte[] pdb = www.bytes;
            System.IO.MemoryStream fs = new MemoryStream(dll);
            System.IO.MemoryStream p = new MemoryStream(pdb);
            appdomain.LoadAssembly(fs, p, new ILRuntime.Mono.Cecil.Pdb.PdbReaderProvider());

            OnILRuntimeInitialized();
        }

        void OnILRuntimeInitialized()
        {
            appdomain.Invoke("Hotfix.Init", "Start", null, null);
        }
    }
}
