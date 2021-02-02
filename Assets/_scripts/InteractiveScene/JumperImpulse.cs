using System;
using UnityEngine;


public enum DirectionVector
{
    Up,
    Down,
    left,
    right
}


public class JumperImpulse : InteractiveObject
{
    [SerializeField] private float force;

    [SerializeField] private DirectionVector direction;
    public DirectionVector GetDirection() => direction;

    public void ApplyImpulse(Rigidbody2D rb)
    {
        rb.velocity = Vector2.zero;

        switch (direction)
        {
            case DirectionVector.Up:
                rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
                break;
            case DirectionVector.Down:
                rb.AddForce(Vector2.down * force, ForceMode2D.Impulse);
                break;
            case DirectionVector.left:
                rb.AddForce(Vector2.left * force + Vector2.up * 2, ForceMode2D.Impulse);
                break;
            case DirectionVector.right:
                rb.AddForce(Vector2.right * force + Vector2.up * 2, ForceMode2D.Impulse);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        OnInteractiveActive?.Invoke();
    }
}