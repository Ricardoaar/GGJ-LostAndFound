using System;
using UnityEngine;

public class BounceStats : MonoBehaviour
{
    [SerializeField] private int initialPlayerLifes;
    public int currentPlayerLife { get; private set; }
    public static BounceStats SingleInstance;


    public static Action OnDoorExit;
    public static Action OnDoorEnter;
    public int keys { get; private set; }

    public static Action OnKeyCollect;

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

        currentPlayerLife = initialPlayerLifes;
    }

    private void LostLife(float time)
    {
        currentPlayerLife--;

        if (currentPlayerLife > 0) return;
        Debug.Log("You lost");

        GameManager.OnGameOver.Invoke();
    }


    private void CollectKey()
    {
        keys++;
        OnKeyCollect?.Invoke();
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

        if (other.CompareTag("Mask"))
        {
            LevelManager.SingleInstance.PassLvl(other.GetComponent<MaskIdentifier>().getId);
            UIInGame.SingleInstance.ChangeMaskImage();
            other.gameObject.SetActive(false);
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