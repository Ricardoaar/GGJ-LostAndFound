using UnityEngine;
using Random = UnityEngine.Random;

public class RandomColor : MonoBehaviour
{
    private SpriteRenderer _renderer;
    private Color _color;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _renderer.color = _color;
    }

    private void OnEnable()
    {
        var randomAlpha = (float) 1 / Random.Range(1, 4);
        _color = Random.ColorHSV();
        _color = new Color(_color.r, _color.b, _color.g, randomAlpha);
    }
}