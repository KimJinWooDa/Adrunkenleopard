using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody rb;

    Vector3 moveDir;
    bool isGrounded;
    float speed = 5f;
    float jumph = 3f;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, -transform.up, 3.0f);

        if (isGrounded && OVRInput.GetDown(OVRInput.Button.One))
		{
            jump();
        }

        Vector2 thumbstick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

        moveDir += thumbstick.x * transform.right * speed + thumbstick.y * transform.forward * speed;
        rb.AddForce(moveDir);
    }

    void jump()
	{
        rb.AddForce(transform.up * jumph, ForceMode.Impulse);
    }
}
