using System;
using UnityEngine;

public class BounceStats : MonoBehaviour
{
    [SerializeField] private int initialPlayerLifes;
    private int _currentPlayerLife;
    public static BounceStats SingleInstance;


    public static Action OnDoorExit;
    public static Action OnDoorEnter;
    public int keys { get; private set; }

    public static Action OnKeyCollect;
    public static Action OnMaskCollect;

    public int GetPlayerLife()
    {
        return _currentPlayerLife;
    }

    private void OnEnable()
    {
        keys = 0;
        BounceController.OnPlayerDamage += LostLife;
        _currentPlayerLife = initialPlayerLifes;
    }

    private void OnDisable()
    {
        BounceController.OnPlayerDamage -= LostLife;
    }

    private void OnDestroy()
    {
        SingleInstance = null;
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

        GameManager.OnGameOver?.Invoke();
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
            LevelManager.SingleInstance.PassLvl(other.GetComponent<MaskCollectable>().getId);
            //  UIInGame.SingleInstance.ChangeMaskImage();
            OnMaskCollect?.Invoke();
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("OpenText"))
        {
            other.GetComponent<TextTrigger>().ShowText();
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