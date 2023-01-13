using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ShotToSoundObject : MonoBehaviour
{
    private float shotClickTimer;
    private bool isPressState;
    [SerializeField] private float pressTime = 2f;

    private bool isChange;

    public Transform exitPosition;
    private AudioSource _audioSource;
    public GameObject streamObject;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            isPressState = true;
            var obj = Pooling.Instance.GetObject();
            obj.GetComponent<Bubble>().forwardDirection = transform.TransformDirection(exitPosition.position);
            obj.transform.position = exitPosition.position;
            _audioSource.Play();
        }
        else if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
        {
            isPressState = false;
            shotClickTimer = 0f;
            isChange = false;
            if(streamObject.activeSelf) streamObject.SetActive(false);
        }
            
        if (isPressState)
        {
            shotClickTimer += Time.deltaTime;

            if (shotClickTimer > pressTime)
            {
                isChange = true;
            }
        }

        if (isChange)
        {
            streamObject.SetActive(true);
            streamObject.GetComponent<ParticleSystem>().Play();
            isChange = false;
        }
    }
}
