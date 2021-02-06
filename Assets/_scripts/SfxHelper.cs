using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxHelper : MonoBehaviour
{
    [SerializeField, Min(0), Tooltip("0 main,1 random loop,2 finalLevel")]
    private int musicMode;

    // Start is called before the first frame update
    void Start()


    {
        SfxManager.SingleInstance.PlayMusicLevel(0);
    }
}