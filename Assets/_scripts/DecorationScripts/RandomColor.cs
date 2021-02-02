using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    private SpriteRenderer _renderer;
    private Color _color;
    [SerializeField] private bool fade = true;
    private static List<Color> availableColors = new List<Color>();

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _color = availableColors.Count != 0
            ? availableColors[Random.Range(0, availableColors.Count)]
            : Random.ColorHSV();

        if (fade)
        {
            var randomAlpha = (float) 1 / Random.Range(1, 4);
            _color = new Color(_color.r, _color.b, _color.g, randomAlpha);
        }

        _renderer.color = _color;
    }


    public static void SetColors(List<Color> colors)
    {
        availableColors.Clear();
        foreach (var color in colors)
        {
            availableColors.Add(color);
        }
    }
}