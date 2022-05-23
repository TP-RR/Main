using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public static class LocalizedData
{
    public static void SaveString(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
    }

    public static string GetString(string key)
    {
        var value = PlayerPrefs.GetString(key);
        return value;
    }

    public static string GetString(string key, string defaultValue)
    {
        var value = PlayerPrefs.GetString(key, defaultValue);
        return value;
    }

    public static void SaveFloat(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
    }

    public static float GetFloat(string key)
    {
        var value = PlayerPrefs.GetFloat(key);
        return value;
    }

    public static float GetFloat(string key, float defaultValue)
    {
        var value = PlayerPrefs.GetFloat(key, defaultValue);
        return value;
    }

    public static void SaveInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

    public static int GetInt(string key)
    {
        var value = PlayerPrefs.GetInt(key);
        return value;
    }

    public static int GetInt(string key, int defaultValue)
    {
        var value = PlayerPrefs.GetInt(key, defaultValue);
        return value;
    }

    public static void SaveObject(string key, object userInfo)
    {
        string jsonInfo = JsonUtility.ToJson(userInfo);
        PlayerPrefs.SetString(key, jsonInfo);
    }

    //public static void SaveObject<T>(string key, T userInfo)
    //{
    //    string jsonInfo = JsonUtility.ToJson<T>(userInfo);
    //    PlayerPrefs.SetString(key, jsonInfo);
    //}

    public static T GetObject<T>(string key)
    {
        string jsonInfo = PlayerPrefs.GetString(key);
        T obj = JsonUtility.FromJson<T>(jsonInfo);
        return obj;
    }

    public static T GetObject<T>(string key, T defaultValue)
    {
        string jsonInfo = PlayerPrefs.GetString(key);
        T obj = jsonInfo == "" ? JsonUtility.FromJson<T>(jsonInfo) : defaultValue;
        return obj;
    }
}
