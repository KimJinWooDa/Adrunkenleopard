
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(BoxCollider))]
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

    private void Start()
    {
        if (this.gameObject.GetComponent<HitTool>() && gameObject.name != "Weapon")
        {
            rb.isKinematic = false;
            rb.useGravity = true;
        }
    }

    public void OnPlay()
    {
        if (_audioSource.isPlaying) return;

        _audioSource.Play();
    }

    public void MusicQ(float power)
    {
        power *= 0.1f;
        power = Mathf.Clamp(power, 0.1f, 1f);
        _audioSource.volume = power;
        _audioSource.Play();
    }
}
