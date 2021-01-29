using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Action OnGameOver;

    private void Awake()
    {
        OnGameOver += () => Time.timeScale = 0;
    }
}