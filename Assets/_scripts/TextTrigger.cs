using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    [SerializeField] private TextInGame text;

    public void ShowText()
    {
        TextWriter.SingleInstance.StartWriting(text);
        gameObject.SetActive(false);
    }
}