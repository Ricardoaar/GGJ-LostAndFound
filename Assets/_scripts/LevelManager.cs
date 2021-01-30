using UnityEngine;

[DefaultExecutionOrder(-3000)]
public class LevelManager : MonoBehaviour
{
    [SerializeField] private int lvlsCompleted = 0;
    public static LevelManager SingleInstance;

    private void Awake()
    {
        if (SingleInstance == null)
        {
            SingleInstance = this;
        }
    }

    public void PassLvl()
    {
        lvlsCompleted++;
    }

    public int GetLvlsCompleted()
    {
        return lvlsCompleted;
    }
}