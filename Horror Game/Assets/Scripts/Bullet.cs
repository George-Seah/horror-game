using UnityEngine;

public class Bullet : MonoBehaviour
{
    int damage;

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }
    void FixedUpdate()
    {
        transform.position += transform.forward * 50;
    }
    
    void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponentInParent<CreatureHealth>().Damage(damage);
    }
}
