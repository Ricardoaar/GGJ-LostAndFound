using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class SceneLoader : MonoBehaviour
{
    [SerializeField] private SceneAsset lvlToPlay;

    /// <summary>
    /// Drag and drop the next lvl from assets
    /// </summary>
    private void OnMouseDown()
    {
        SceneManager.LoadScene(lvlToPlay.name);
    }
}