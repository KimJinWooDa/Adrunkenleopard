using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMusic : MonoBehaviour
{
    public AudioSource _audioSource;
    public AudioClip clip;
    public Rigidbody[] rb;

    // Start is called before the first frame update
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.playOnAwake = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Player")) return;
        _audioSource.PlayOneShot(clip);
    }


}
