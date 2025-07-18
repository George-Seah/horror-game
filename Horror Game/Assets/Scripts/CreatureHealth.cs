using UnityEngine;

public class CreatureHealth : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] GameObject deathParticles;

    public void Damage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            if(deathParticles) Instantiate(deathParticles);
            Destroy(gameObject);
        }
    }
}
