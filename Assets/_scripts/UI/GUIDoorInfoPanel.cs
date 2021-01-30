using UnityEngine;

public class GUIDoorInfoPanel : MonoBehaviour
{
    private Animator _animator;
    private static readonly int PlayerIn = Animator.StringToHash("PlayerIn");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        BounceStats.OnDoorEnter += ActivePanel;
        BounceStats.OnDoorExit += DeactivatePanel;
    }


    private void OnDisable()
    {
        BounceStats.OnDoorEnter -= ActivePanel;
        BounceStats.OnDoorExit -= DeactivatePanel;
    }

    private void DeactivatePanel()
    {
        _animator.SetBool(PlayerIn, false);
    }

    private void ActivePanel()
    {
        _animator.SetBool(PlayerIn, true);
    }
}