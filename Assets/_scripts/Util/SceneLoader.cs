using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class SceneLoader : MonoBehaviour
{
    [SerializeField] private SceneAsset lvlToPlay;
    [SerializeField] private bool canPlayLvl;

    private void Awake()
    {
        if (!canPlayLvl)
        {
            GetComponent<SpriteRenderer>().color = Color.black;
        }
    }

    /// <summary>
    /// Drag and drop the next lvl from assets
    /// </summary>
    private void OnMouseDown()
    {
        if (canPlayLvl)
        {
            SceneManager.LoadScene(lvlToPlay.name);
        }
    }

    public void CanPlayLvl()
    {
        canPlayLvl = true;
    }
}