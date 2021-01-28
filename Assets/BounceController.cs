using System;
using System.Collections;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public delegate void VoidEvent(float time);

[RequireComponent(typeof(Rigidbody2D))]
public class BounceController : MonoBehaviour
{
    public static event VoidEvent OnPlayerDamage;
    private Rigidbody2D _rigidbody2D;

    [SerializeField] private float velocity;
    private float _horizontal, _vertical;
    private bool _jumping;
    [SerializeField] private float jumpForce;
    [SerializeField] private float maxDistanceGround;
    public LayerMask groundLayer;
    private bool _canGetDamage = true;
    private bool _canMove = true;
    [SerializeField] private float immuneTime;


    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");


        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround())
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        if (_canMove)
        {
            _rigidbody2D.velocity = new Vector2(_horizontal * velocity, _rigidbody2D.velocity.y);
        }
    }

    private void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }


    private bool IsOnGround()
    {
        var hit = Physics2D.Raycast(transform.position, Vector2.down, maxDistanceGround,
            groundLayer);

        return hit;
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Jumpers"))
        {
            if (_rigidbody2D.velocity.y != 0)
            {
                _rigidbody2D.velocity = Vector2.zero;
                _rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Damage") && _canGetDamage)
        {
            GetDamage(other.gameObject);
        }
    }


    private void GetDamage(GameObject other)
    {
        _rigidbody2D.velocity = Vector2.zero;
        _canMove = false;
        _canGetDamage = false;
        if (other.CompareTag("DamageLeft"))
        {
            _rigidbody2D.AddForce(Vector2.left * velocity + Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        else if (other.CompareTag("DamageRight"))
        {
            _rigidbody2D.AddForce(Vector2.left * -velocity + Vector2.up * jumpForce, ForceMode2D.Impulse);
        }


        StopAllCoroutines();
        StartCoroutine(RestartNoImmune());
        OnPlayerDamage?.Invoke(immuneTime);
    }

    private IEnumerator RestartNoImmune()
    {
        yield return new WaitForSeconds(0.5f);
        _canMove = true;
        yield return new WaitForSeconds(immuneTime - 0.5f);
        _canGetDamage = true;
    }
}