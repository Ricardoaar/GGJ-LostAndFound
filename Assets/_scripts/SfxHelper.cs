using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxHelper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SfxManager.SingleInstance.PlayMusicLevel(0);
    }
}