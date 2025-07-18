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
        transform.localPosition += transform.forward * 100;
    }
    
    void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponentInParent<CreatureHealth>().Damage(damage);
    }
}
