using System;
using System.Collections;
using UnityEngine;

public class BounceInteractive : MonoBehaviour
{
    private SpriteRenderer _sprite;

    private void Awake()
    {
        BounceController.OnPlayerDamage += OnPlayerDamageEvent;
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void OnPlayerDamageEvent(float time)
    {
        StartCoroutine(ToggleColor(time));
    }

    private IEnumerator ToggleColor(float time)
    {
        for (float i = 0; i < time; i += 0.1f)
        {
            _sprite.color = new Color(_sprite.color.r, _sprite.color.g, _sprite.color.b,
                _sprite.color.a == 1 ? 0 : 1);

            yield return new WaitForSeconds(0.1f);
        }

        _sprite.color = new Color(_sprite.color.r, _sprite.color.g, _sprite.color.b, 255);
    }
}