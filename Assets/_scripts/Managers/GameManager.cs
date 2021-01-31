using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Action OnGameOver;
    private bool _isInGame;


    private void Start()
    {
        var lvl = FindObjectOfType<MaskCollectable>().getId;
        SfxManager.SingleInstance.PlayMusicLevel(lvl);
    }
}