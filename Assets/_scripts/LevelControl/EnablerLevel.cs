using UnityEngine;

public class EnablerLevel : MonoBehaviour
{
    [SerializeField] private SceneLoader loader;

    [SerializeField] private int levelToUnlock;


    private void Awake()
    {
        if (LevelManager.SingleInstance.GetLvlsCompleted() >= levelToUnlock)
        {
            loader.CanPlayLvl();
        }
    }
}