using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TrapFall : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField] private TrapMaster master;
    private Vector3 _initialPosition;

    private void Awake()
    {
        _initialPosition = transform.position;
        master.OnInteractiveActive += ChangeState;
        master.OnTrapUp += EnableObject;
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.isKinematic = true;
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        gameObject.SetActive(false);
        transform.position = _initialPosition;
    }

    public void ChangeState()
    {
        _rigidbody.isKinematic = false;
    }

    private void OnDisable()
    {
        _rigidbody.isKinematic = true;
    }

    private void OnDestroy()
    {
        master.OnInteractiveActive -= ChangeState;
        master.OnTrapUp -= EnableObject;
    }


    private void EnableObject()
    {
        gameObject.SetActive(true);
    }
}