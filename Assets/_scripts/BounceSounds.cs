using UnityEngine;

public class BounceSounds : MonoBehaviour
{
    [SerializeField] private AudioClip hitClip;
    [SerializeField] private AudioClip jumpClip;
    [SerializeReference] private AudioClip dieSound;

    private void OnEnable()
    {
        BounceController.OnJump += OnJumpClip;
        BounceController.OnPlayerDamage += OnPlayerDamageSound;
        GameManager.OnGameOver += OnGameOver;
    }

    private void OnGameOver()
    {
        SfxManager.SingleInstance.PlaySound(dieSound);
    }

    private void OnJumpClip()
    {
        SfxManager.SingleInstance.PlaySound(jumpClip);
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= OnGameOver;
        BounceController.OnJump -= OnJumpClip;
        BounceController.OnPlayerDamage -= OnPlayerDamageSound;
    }

    private void OnPlayerDamageSound(float time)
    {
        SfxManager.SingleInstance.PlaySound(hitClip);
    }
}