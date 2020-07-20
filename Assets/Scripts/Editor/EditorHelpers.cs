using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public static class EditorHelpers
{
    [MenuItem("Tools/Clear Console 1st way")]
    static void Clear_FirstWay()
    {
        ClearConsole1();
    }

    [MenuItem("Tools/Clear Console 2nd way")]
    static void Clear_SecondWay()
    {
        ClearConsole2();
    }

    internal static void ClearConsole1()
    {
        var assembly = Assembly.GetAssembly(typeof(SceneView));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }

    internal static void ClearConsole2()
    {
        var type = System.Type.GetType("UnityEditor.LogEntries, UnityEditor.dll");
        var method = type.GetMethod("Clear", BindingFlags.Static | BindingFlags.Public);
        method.Invoke(null, null);
    }

    [MenuItem("Tools/Spam Console")]
    internal static void SpamConsole()
    {
        int numMsgs = Random.Range(1, 12);
        for (int i = 0; i < numMsgs; i++)
        {
            Debug.Log("Random Debug.Message #" + i);
        }

        int numWrngs = Random.Range(1, 12);
        for (int i = 0; i < numWrngs; i++)
        {
            Debug.LogWarning("Random Debug.Warning #" + i);
        }

        int numErrors = Random.Range(1, 12);
        for (int i = 0; i < numErrors; i++)
        {
            Debug.LogError("Random Debug.Error #" + i);
        }

    }
}
