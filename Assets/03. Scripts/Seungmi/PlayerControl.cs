using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody rb;

    Vector3 moveDir;
    bool isGrounded;
    [SerializeField] private float speed = 5f;
    float jumph = 3f;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, -transform.up, 3.0f);

        if (isGrounded && OVRInput.GetDown(OVRInput.Button.One))
		{
            jump();
        }

        
    }

    private void FixedUpdate()
    {
        var thumbstick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

        moveDir = transform.right * thumbstick.x + transform.forward * (thumbstick.y);
        rb.MovePosition(rb.position + moveDir * (Time.fixedDeltaTime * speed));
    }

    void jump()
	{
        rb.AddForce(transform.up * jumph, ForceMode.Impulse);
    }
}
