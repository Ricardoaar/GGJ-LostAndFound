using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHelper : MonoBehaviour
{
    private void OnEnable()
    {
        BounceStats.OnMaskCollect += OnMaskCollect;
    }

    private void OnDisable()
    {
        BounceStats.OnMaskCollect -= OnMaskCollect;
    }

    private void OnMaskCollect()
    {
        StartCoroutine(LoadMenuOnMaskCollet());
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator LoadMenuOnMaskCollet()
    {
        yield return new WaitForSeconds(2f);
        LoadMenuScene();
    }
}