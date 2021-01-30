using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

[DefaultExecutionOrder(-3000), DisallowMultipleComponent]
public class OnSceneLoadEvent : MonoBehaviour
{
    private static List<ISceneLoad> _notifiers = new List<ISceneLoad>();

    private static OnSceneLoadEvent _singleInstance;

    private void Awake()
    {
        if (_singleInstance == null)
        {
            _singleInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void AddNotifier(ISceneLoad notifier)
    {
        _notifiers.Add(notifier);
    }

    public static void RemoveNotifier(ISceneLoad notifier)
    {
        _notifiers.Remove(notifier);
    }


    public static void OnSceneLoad()
    {
        if (_notifiers.Count <= 0) return;

        foreach (var notifier in _notifiers)
        {
            notifier.NotifySceneLoad();
        }
    }
}