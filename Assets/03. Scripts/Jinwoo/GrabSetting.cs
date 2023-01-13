using System;
using Oculus.Interaction;
using UnityEngine;

[RequireComponent(typeof(Grabbable))]
[RequireComponent(typeof(GrabInteractable))]
[RequireComponent(typeof(PhysicsGrabbable))]
public class GrabSetting : MonoBehaviour
{
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = true;
    }
}
