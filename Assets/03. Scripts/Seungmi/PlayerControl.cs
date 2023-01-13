using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControl : MonoBehaviour
{
    public Rigidbody rb;

    Vector3 moveDir;
    bool isGrounded;
    [SerializeField] private float speed = 5f;
    [SerializeField] float jumph = 3f;

    public Transform checkBox;
    public Transform eye;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.Raycast(checkBox.position + Vector3.up * .5f, -transform.up, 3.0f);

        if (isGrounded && OVRInput.GetDown(OVRInput.Button.One))
		{
            jump();
        }

        
    }

    private void FixedUpdate()
    {
        var thumbstick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

        moveDir = transform.right * thumbstick.x + transform.forward * (thumbstick.y);
        transform.TransformDirection(eye.position);
        rb.MovePosition(rb.position + moveDir.normalized * (Time.fixedDeltaTime * speed));
    }

    void jump()
	{
        rb.AddForce(transform.up * jumph, ForceMode.Impulse);
    }
}
