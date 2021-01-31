using System.Collections;
using UnityEngine;

public class BounceInteractive : MonoBehaviour
{
    private SpriteRenderer _sprite;
    private Coroutine _cToggle;
    [SerializeField] private ParticleSystem dieParticle;
    [SerializeField] private BounceController controller;

    #region Animator

    private bool _isOnGround;
    private float _lastHorizontal;
    private float _verticalForce;
    private bool _moving;

    private static readonly int AnimationMoving = Animator.StringToHash("Moving");
    private static readonly int AnimationJump = Animator.StringToHash("Jump");
    private static readonly int AnimationRbForceY = Animator.StringToHash("RbForceY");
    private static readonly int AnimationIsOnGround = Animator.StringToHash("IsOnGround");
    private static readonly int AnimationHit = Animator.StringToHash("Hit");

    private Animator _animator;

    #endregion


    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void LateUpdate()
    {
        controller.GetPlayerState(out _isOnGround, out _lastHorizontal, out _moving, out _verticalForce);

        _sprite.flipX = _lastHorizontal < 0;

        _animator.SetBool(AnimationIsOnGround, _isOnGround);
        _animator.SetBool(AnimationMoving, _moving);
        _animator.SetFloat(AnimationRbForceY, _verticalForce);
        if (_verticalForce > 0)
        {
            _animator.SetTrigger(AnimationJump);
        }
    }


    private void OnEnable()
    {
        GameManager.OnGameOver += OnGameOver;
        BounceController.OnPlayerDamage += OnPlayerDamageEvent;
    }

    private void OnDisable()
    {
        BounceController.OnPlayerDamage -= OnPlayerDamageEvent;
        GameManager.OnGameOver -= OnGameOver;
    }

    private void OnPlayerDamageEvent(float time)
    {
        if (BounceStats.SingleInstance.GetPlayerLife() > 0 && _cToggle == null)
        {
            _cToggle = StartCoroutine(ToggleColor(time));
            _animator.SetTrigger(AnimationHit);
        }
    }

    private void OnGameOver()
    {
        Instantiate(dieParticle, transform.position, Quaternion.Euler(Vector3.zero));
    }

    private IEnumerator ToggleColor(float time)
    {
        for (float i = 0; i < time; i += 0.1f)
        {
            _sprite.color = new Color(_sprite.color.r, _sprite.color.g, _sprite.color.b,
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                _sprite.color.a == 1 ? 0 : 1);

            yield return new WaitForSeconds(0.1f);
        }

        _sprite.color = new Color(_sprite.color.r, _sprite.color.g, _sprite.color.b, 255);
        _cToggle = null;
    }
}