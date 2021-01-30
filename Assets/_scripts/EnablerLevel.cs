using UnityEngine;

public class EnablerLevel : MonoBehaviour
{
    [SerializeField] private SceneLoader _loader;

    [SerializeField] private int levelToUnlock;


    private void Awake()
    {
        if (LevelManager.SingleInstance.GetLvlsCompleted() >= levelToUnlock)
        {
            _loader.CanPlayLvl();
        }
    }
}