using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bubble : MonoBehaviour
{
    [SerializeField] private float throwingPower = 2f;
    private Rigidbody rb;
    public Vector3 forwardDirection;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
         rb.AddForce(forwardDirection * throwingPower, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Music"))
        {
            Pooling.Instance.ReturnObject(this.gameObject);
        }
    }
}
