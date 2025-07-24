using UnityEngine;

public class CreatureDamagePlayer : MonoBehaviour
{
    [SerializeField] int collideDamage;
    //[SerializeField] Collider collider;

    void HandleCollision(Collision collision)
    {
        PlayerHealth player = collision.gameObject.GetComponentInParent<PlayerHealth>();
        Debug.Log(collision.gameObject.name);
        player?.Damage(collideDamage);
    }

    void OnCollisionEnter(Collision collision)
    {
        PlayerHealth player = collision.gameObject.GetComponentInParent<PlayerHealth>();
        Debug.Log(collision.gameObject.name);
        player?.Damage(collideDamage);
    }

    void OnCollisionStay(Collision collision)
    {
        PlayerHealth player = collision.gameObject.GetComponentInParent<PlayerHealth>();
        Debug.Log(collision.gameObject.name);
        player?.Damage(collideDamage);
    }
}
