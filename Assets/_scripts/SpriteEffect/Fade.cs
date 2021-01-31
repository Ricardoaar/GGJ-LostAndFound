using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Fade : MonoBehaviour
{
    [Header("Alpha Behavior")] [SerializeField, Range(0, 1)]
    private float maxAlpha;

    [SerializeField, Range(0, 1)] private float minAlpha;
    [SerializeField, Range(0, 0.1f)] private float alphaGrow;
    [SerializeField] private List<SpriteRenderer> sprites = new List<SpriteRenderer>();

    private float _currentAlpha;
    private bool _goOn;

    private void Awake()
    {
        _currentAlpha = 1;
        _goOn = false;
    }

    private void Effect()
    {
        _currentAlpha += _goOn ? alphaGrow : -alphaGrow;

        foreach (var sprite in sprites)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, _currentAlpha);
        }

        if (_currentAlpha <= minAlpha)
        {
            _goOn = true;
        }
        else if (_currentAlpha >= maxAlpha)
        {
            _goOn = false;
        }
    }
}