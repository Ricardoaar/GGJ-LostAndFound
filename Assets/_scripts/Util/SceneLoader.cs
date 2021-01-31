using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class SceneLoader : MonoBehaviour
{
    [SerializeField] private int lvlToPlay;
    [SerializeField] private bool canPlayLvl;


    private void Start()
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
        if (!canPlayLvl) return;

        SceneManager.LoadScene(lvlToPlay);
        OnSceneLoadEvent.OnSceneLoad();
    }

    public void CanPlayLvl()
    {
        canPlayLvl = true;
    }
}