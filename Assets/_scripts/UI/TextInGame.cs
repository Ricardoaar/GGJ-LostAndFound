using UnityEngine;

[CreateAssetMenu(fileName = "TextContainer", menuName = "CustomUI/TextContainer", order = 0)]
public class TextInGame : ScriptableObject
{
    [TextArea(1, 10)] public string text;
}