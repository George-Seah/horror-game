using UnityEngine;

public class CreatureDamagePlayer : MonoBehaviour
{
    [SerializeField] int collideDamage = 5;
    //[SerializeField] Collider collider;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        PlayerHealth player = collision.gameObject.GetComponentInParent<PlayerHealth>();
        player?.Damage(collideDamage);
    }

}
