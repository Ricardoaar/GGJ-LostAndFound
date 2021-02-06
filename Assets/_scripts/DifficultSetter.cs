using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class DifficultSetter : MonoBehaviour, ISceneLoad
{
    private int _immortal;
    [SerializeField] private Image image;

    private void Awake()
    {
        _immortal = PlayerPrefs.HasKey("Immortal") ? PlayerPrefs.GetInt("Immortal") : 0;
        UpdateStateImg();
    }

    private void OnEnable()
    {
        OnSceneLoadEvent.AddNotifier(this);
    }

    private void OnDisable()
    {
        OnSceneLoadEvent.RemoveNotifier(this);
    }

    public void ChangeState()
    {
        _immortal = _immortal == 0 ? 1 : 0;
        UpdateStateImg();
    }

    private void UpdateStateImg()
    {
        image.color = _immortal == 0 ? Color.white : Color.red;
    }

    public void NotifySceneLoad()
    {
        PlayerPrefs.SetInt("Immortal", _immortal);
    }
}