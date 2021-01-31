using System.Collections;
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
            Transport(rb);
        }
    }


    private void Transport(Rigidbody2D rb)
    {
        rb.gameObject.transform.position =
            destiny.transform.position +
            new Vector3(0, direction.y > 0 ? _collider.bounds.size.y : -_collider.bounds.size.y);
        _collider.enabled = false;
        StartCoroutine(RestartCollider());
        if (getImpulse)
        {
            AddForce(rb);
        }
    }

    private void AddForce(Rigidbody2D rb)
    {
        rb.velocity = direction * impulseForce;
    }

    private IEnumerator RestartCollider()
    {
        yield return new WaitForSeconds(1.0f);
        _collider.enabled = true;
    }
}