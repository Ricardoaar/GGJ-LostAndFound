using UnityEngine;

public class MoveOneDirection : MonoBehaviour
{
    [SerializeField] private Vector3 direction;
    [SerializeField] private float speed;

    private void FixedUpdate()
    {
        transform.Translate(direction * (Time.fixedDeltaTime * speed));
    }
}