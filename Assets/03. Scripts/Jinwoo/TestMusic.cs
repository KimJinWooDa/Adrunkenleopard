using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMusic : MonoBehaviour
{
    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;

    void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other)
    {
        if (!other.CompareTag("Music")) return;
        other.GetComponent<ObjectToMusic>()?.OnPlay();
        var numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);

        var rb = other.GetComponent<Rigidbody>();
        var i = 0;

        while (i < numCollisionEvents)
        {
            if (rb)
            {
                var pos = collisionEvents[i].intersection;
                var force = collisionEvents[i].velocity * 10;
                rb.AddForce(force);
            }
            i++;
            
        }
    }
}
