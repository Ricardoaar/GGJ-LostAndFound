using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Action OnGameOver;
    private bool _isInGame;
    [SerializeField] private List<Color> _colors = new List<Color>();
    
    private void Awake()
    {
        RandomColor.SetColors(_colors);
    }

    private void Start()
    {
        var lvl = FindObjectOfType<MaskCollectable>().getId;
        SfxManager.SingleInstance.PlayMusicLevel(lvl);
    }
}