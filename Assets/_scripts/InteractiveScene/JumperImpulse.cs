using System;
using UnityEngine;


public enum VectorDirection
{
    Up,
    Down,
    left,
    right
}


public class JumperImpulse : InteractiveObject
{
    [SerializeField] private float force;

    [SerializeField] private VectorDirection direction;

    public void ApplyImpulse(Rigidbody2D rb)
    {
        rb.velocity = Vector2.zero;

        switch (direction)
        {
            case VectorDirection.Up:
                rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
                break;
            case VectorDirection.Down:
                rb.AddForce(Vector2.down * force, ForceMode2D.Impulse);
                break;
            case VectorDirection.left:
                rb.AddForce(Vector2.left * force + Vector2.up * 2, ForceMode2D.Impulse);
                break;
            case VectorDirection.right:
                rb.AddForce(Vector2.right * force + Vector2.up * 2, ForceMode2D.Impulse);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        OnInteractiveActive?.Invoke();
    }
}