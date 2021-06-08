using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class ClearPrefs
{
    [MenuItem("Tools/Clear Prefs")]
    public static void Clear() {
        PlayerPrefs.DeleteAll();
    }
}
