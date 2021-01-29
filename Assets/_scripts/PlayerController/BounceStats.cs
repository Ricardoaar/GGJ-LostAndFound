using UnityEngine;

public class BounceStats : MonoBehaviour
{
    [SerializeField] private int initialPlayerLifes;
    private int _currentPlayerLife;

    private void OnEnable()
    {
        BounceController.OnPlayerDamage += LostLife;
    }

    private void Awake()
    {
        _currentPlayerLife = initialPlayerLifes;
    }

    private void LostLife(float time)
    {
        _currentPlayerLife--;

        if (_currentPlayerLife > 0) return;
        Debug.Log("You lost");

        GameManager.OnGameOver.Invoke();
    }


    private void WinLife(float time)
    {
        initialPlayerLifes++;
    }
}