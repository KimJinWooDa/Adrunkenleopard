using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class ObjectToMusic : MonoBehaviour
{
    private AudioSource _audioSource;
    private Rigidbody rb;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();

        rb.useGravity = false;
        rb.isKinematic = true;
        _audioSource.playOnAwake = false;

        this.gameObject.tag = "Music";
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Music")) return;
        
        _audioSource.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Music")) return;
        
        _audioSource.Play();
        var rigidbody = other.GetComponent<Rigidbody>();
        //Debug.Log($"{other.name}, {rigidbody.velocity}");
    }

    public void OnPlay()
    {
        _audioSource.Play();
    }
}
