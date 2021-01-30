using UnityEngine;

public class HoleTransport : MonoBehaviour
{
    [SerializeField] private HoleTransport destiny;
    [SerializeField] private bool getImpulse;
    [SerializeField] private Vector2 direction;
    [SerializeField] private float impulseForce;
    private Collider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var rb = other.gameObject.GetComponent<Rigidbody2D>();
            Debug.Log(rb.velocity);
            Transport(rb);
        }
    }


    private void Transport(Rigidbody2D rb)
    {
        rb.gameObject.transform.position =
            destiny.transform.position + new Vector3(0, _collider.bounds.size.y * 1.5f);
        if (getImpulse)
        {
            AddForce(rb);
        }
    }

    private void AddForce(Rigidbody2D rb)
    {
        rb.velocity = direction * impulseForce;
    }
}