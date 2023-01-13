using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeMusic : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    public AudioClip[] audioclip;
    AudioSource aud;



    Vector3 pos;
    void Awake()
	{
        aud = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update() {
        Vector3 s = pos - transform.position;
        print(s.magnitude);
        pos = transform.position;

		if (s.magnitude > 1.0f && !aud.isPlaying)
		{
            foreach (AudioClip clip in audioclip)
            {
                aud.pitch = 1f + Random.Range(-0.25f, 0.5f);
                aud.PlayOneShot(clip, s.magnitude);
            }
            
        }
    }
}
