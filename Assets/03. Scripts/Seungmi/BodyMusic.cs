using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMusic : MonoBehaviour
{
    public AudioSource _audioSource;
    public Rigidbody[] rb;

    // Start is called before the first frame update
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.playOnAwake = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.collider);
        if (!collision.collider.CompareTag("Player")) return;
        _audioSource.Play();
    }


}
