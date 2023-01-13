using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTool : MonoBehaviour
{
    private Vector3 oldPosition;
    private Vector3 currentPosition;
    private double velocity;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        oldPosition = transform.position;
        
    }

    void Update()
    {
        currentPosition = transform.position;
        var dis = (currentPosition - oldPosition);
        var distance = Math.Sqrt(Math.Pow(dis.x,2)+Math.Pow(dis.y,2)+Math.Pow(dis.z,2));
        velocity = distance / Time.deltaTime;
        oldPosition = currentPosition;        
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        var obj = collision.collider;
        if (!obj.CompareTag("Music") && !obj.GetComponent<ObjectToMusic>()) return;
        obj.GetComponent<ObjectToMusic>().MusicQ((float)velocity);

        var strength = (float)velocity;
        strength *= 0.1f;
        strength = Mathf.Clamp(strength, 0.1f, 1f);
        _audioSource.volume = strength;
        _audioSource.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Music") && !other.GetComponent<ObjectToMusic>()) return;
        other.GetComponent<ObjectToMusic>().MusicQ((float)velocity);
        
        var strength = (float)velocity;
        strength *= 0.1f;
        strength = Mathf.Clamp(strength, 0.1f, 1f);
        _audioSource.volume = strength;
        _audioSource.Play();
    }
}
