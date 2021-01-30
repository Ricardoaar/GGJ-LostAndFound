using UnityEngine;
using Random = UnityEngine.Random;

public class RandomColor : MonoBehaviour
{
    private SpriteRenderer _renderer;
    private Color _color;

    [SerializeField] private bool fade = true;

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
        if (fade)
        {
            _color = new Color(_color.r, _color.b, _color.g, randomAlpha);
        }
    }
}