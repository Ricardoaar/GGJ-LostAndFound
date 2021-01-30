using System;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-3000)]
public class LevelManager : MonoBehaviour
{
    [SerializeField] private int lvlsCompleted;
    public static LevelManager SingleInstance;
    private readonly List<int> _levelsCompleted = new List<int>();

    private void Awake()
    {
        if (SingleInstance == null)
        {
            SingleInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void PassLvl(int lvlComplete)
    {
        if (_levelsCompleted.Contains(lvlComplete)) return;
        _levelsCompleted.Add(lvlComplete);
        lvlsCompleted++;
    }

    public int GetLvlsCompleted()
    {
        return lvlsCompleted;
    }


    public List<int> GetLevelsSum()
    {
        return _levelsCompleted;
    }
}