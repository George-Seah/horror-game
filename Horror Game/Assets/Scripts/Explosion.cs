using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Explosion : MonoBehaviour
{
    [SerializeField] int damage = 15;
    SphereCollider sphereCollider;
    //ParticleSystem particleSystem;
    List<ParticleCollisionEvent> collisionEvents;

    void Awake()
    {
        //particleSystem = GetComponent<ParticleSystem>();
        //collisionEvents = new List<ParticleCollisionEvent>();
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    void OnTriggerEnter(Collider other)
    {
        var creature = other.GetComponentInParent<CreatureHealth>();
        var player = other.GetComponentInParent<PlayerHealth>();

        if (creature) creature.Damage(damage);
        if (player) player.Damage(damage);
    }

    /*
    void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = particleSystem.GetCollisionEvents(other, collisionEvents);

        for (int i = 0; i < numCollisionEvents; i++)
        {
            CreatureHealth creature = other.gameObject.GetComponentInParent<CreatureHealth>();
            PlayerHealth player = other.gameObject.GetComponentInParent<PlayerHealth>();

            if (creature)
            {
                Debug.Log(creature.name);
                creature.Damage(damage);
            }
            if (player)
            {
                Debug.Log(player.name);
                player.Damage(damage);
            }
        }

    }
    */

    /*
    void CollisionStuff(Collision collision)
    {
        CreatureHealth creature = collision.gameObject.GetComponentInParent<CreatureHealth>();
        PlayerHealth player = collision.gameObject.GetComponentInParent<PlayerHealth>();

        Debug.Log(collision.gameObject.name);

        if (creature)
        {
            Debug.Log(creature);
            creature.Damage(damage);
        }
        if (player)
        {
            Debug.Log(player);
            player.Damage(damage);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        CollisionStuff(collision);
    }
    void OnCollisionStay(Collision collision)
    {
        CollisionStuff(collision);
    }
    */
}
