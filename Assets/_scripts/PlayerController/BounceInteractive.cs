using System.Collections;
using UnityEngine;

public class BounceInteractive : MonoBehaviour
{
    private SpriteRenderer _sprite;
    private Coroutine _cToggle;
    [SerializeField] private ParticleSystem dieParticle;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }


    private void OnEnable()
    {
        GameManager.OnGameOver += OnGameOver;
        BounceController.OnPlayerDamage += OnPlayerDamageEvent;
    }

    private void OnGameOver()
    {
        Instantiate(dieParticle, transform.position, Quaternion.Euler(Vector3.zero));
    }

    private void OnDisable()
    {
        BounceController.OnPlayerDamage -= OnPlayerDamageEvent;
        GameManager.OnGameOver -= OnGameOver;
    }

    private void OnPlayerDamageEvent(float time)
    {
        if (BounceStats.SingleInstance.GetPlayerLife() > 0 && _cToggle == null)
        {
            _cToggle = StartCoroutine(ToggleColor(time));
        }
    }

    private IEnumerator ToggleColor(float time)
    {
        for (float i = 0; i < time; i += 0.1f)
        {
            _sprite.color = new Color(_sprite.color.r, _sprite.color.g, _sprite.color.b,
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                _sprite.color.a == 1 ? 0 : 1);

            yield return new WaitForSeconds(0.1f);
        }

        _sprite.color = new Color(_sprite.color.r, _sprite.color.g, _sprite.color.b, 255);
        _cToggle = null;
    }
}