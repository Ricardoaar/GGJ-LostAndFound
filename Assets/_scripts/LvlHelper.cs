using System;
using _scripts;
using UnityEngine;

public class LvlHelper : MonoBehaviour
{
    [SerializeField] private LvlConfigurator lvlSelected;
    public static LvlHelper SingleInstance;

    private void Awake()
    {
        if (SingleInstance == null)
        {
            SingleInstance = this;
        }
    }

    public LvlConfigurator GetNextLvl()
    {
        return lvlSelected;
    }

    public void SetNewLevel(LvlConfigurator newLvl)
    {
        lvlSelected = newLvl;
    }
}