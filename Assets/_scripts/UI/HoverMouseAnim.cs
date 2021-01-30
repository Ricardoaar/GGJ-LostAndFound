using UnityEngine;

public class HoverMouseAnim : MonoBehaviour
{
    [SerializeField] private string animationName = "MouseHover";

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnMouseOver()
    {
        _animator.SetBool(animationName, true);
    }

    private void OnMouseExit()
    {
        _animator.SetBool(animationName, false);
    }
}