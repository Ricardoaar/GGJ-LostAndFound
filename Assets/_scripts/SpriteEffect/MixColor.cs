using System;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

[DisallowMultipleComponent]
public class MixColor : MonoBehaviour
{
    [SerializeField] private Color[] colors;
    private int _currentColorIdx;
    [SerializeField] private SpriteRenderer[] sprites;
    [SerializeField] private float changeSpeed;

    private void Awake()
    {
        Effect();
    }

    private void Update()
    {
        var currentColor = sprites[0].color;

        if (currentColor.r == _newColor.r)
        {
            Effect();
        }
        else
        {
            var r = Math.Abs(currentColor.r - _newColor.r) > 0.01f
                ? Mathf.Lerp(currentColor.r, _newColor.r, changeSpeed * Time.deltaTime)
                : _newColor.r;
            var g = Math.Abs(currentColor.g - _newColor.g) > 0.01f
                ? Mathf.Lerp(currentColor.g, _newColor.g, changeSpeed * Time.deltaTime)
                : _newColor.g;

            var b = Math.Abs(currentColor.b - _newColor.b) > 0.01f
                ? Mathf.Lerp(currentColor.b, _newColor.b, changeSpeed * Time.deltaTime)
                : _newColor.b;

            foreach (var sprite in sprites)
            {
                sprite.color = new Color(r, g, b, 255);
            }
        }
    }

    private void Effect()
    {
        while (true)
        {
            _currentColorIdx = Random.Range(0, colors.Length);
            _newColor = colors[_currentColorIdx];
            if (_newColor == sprites[0].color) continue;
            break;
        }
    }

    private Color _newColor;
}