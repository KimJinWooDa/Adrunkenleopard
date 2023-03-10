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
    public GameObject ui;
    private bool ReadyToSnapTurn;
    public bool RotationEitherThumbstick = false;
    public OVRCameraRig CameraRig;
    public float RotationAngle = 45.0f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            ui.SetActive(!ui.activeSelf);
        }

        //if (!ui.activeSelf) return;

        isGrounded = Physics.Raycast(checkBox.position + Vector3.up * .5f, -transform.up, 3.0f);

        if (isGrounded && OVRInput.GetDown(OVRInput.Button.One))
		{
            jump();
        }

        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickLeft) ||
            (RotationEitherThumbstick && OVRInput.Get(OVRInput.Button.PrimaryThumbstickLeft)))
        {
            if (ReadyToSnapTurn)
            {
                ReadyToSnapTurn = false;
                transform.RotateAround(CameraRig.centerEyeAnchor.position, Vector3.up, -RotationAngle);
            }
        }
        else if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickRight) ||
                 (RotationEitherThumbstick && OVRInput.Get(OVRInput.Button.PrimaryThumbstickRight)))
        {
            if (ReadyToSnapTurn)
            {
                ReadyToSnapTurn = false;
                transform.RotateAround(CameraRig.centerEyeAnchor.position, Vector3.up, RotationAngle);
            }
        }
        else
        {
            ReadyToSnapTurn = true;
        }
        
    }

    private void FixedUpdate()
    {
        //if (!ui.activeSelf) return;

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
