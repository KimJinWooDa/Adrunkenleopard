using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Grabbable))]
[RequireComponent(typeof(GrabInteractable))]
[RequireComponent(typeof(PhysicsGrabbable))]
[RequireComponent(typeof(HandGrabInteractable))]
public class GrabSetting : MonoBehaviour
{
    private Rigidbody rb;
    private LayerMask grabbableMask;
    private void Start()
    {
        grabbableMask = LayerMask.NameToLayer("Grabbable");
        this.gameObject.layer = grabbableMask;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = true;
    }
}
