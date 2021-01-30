using System;
using System.Security.Cryptography;
using UnityEngine;

public class BounceStats : MonoBehaviour
{
    [SerializeField] private int initialPlayerLifes;
    private int _currentPlayerLife;
    public static BounceStats SingleInstance;


    public Action OnDoorExit;
    public Action OnDoorEnter;
    public int keys { get; private set; }

    private void OnEnable()
    {
        keys = 0;
        BounceController.OnPlayerDamage += LostLife;
    }

    private void Awake()
    {
        if (SingleInstance == null)
        {
            SingleInstance = this;
        }

        _currentPlayerLife = initialPlayerLifes;
    }

    private void LostLife(float time)
    {
        _currentPlayerLife--;

        if (_currentPlayerLife > 0) return;
        Debug.Log("You lost");

        GameManager.OnGameOver.Invoke();
    }


    private void CollectKey()
    {
        keys++;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Door"))
        {
            OnDoorEnter?.Invoke();
        }

        if (other.CompareTag("Key"))
        {
            other.gameObject.SetActive(false);
            CollectKey();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Door"))
        {
            OnDoorExit?.Invoke();
        }
    }
}