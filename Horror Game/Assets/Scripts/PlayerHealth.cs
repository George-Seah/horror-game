using UnityEngine;
using StarterAssets;

public class PlayerHealth : MonoBehaviour
{
    int health = 100;

    public void Damage(int damage)
    {
        health -= damage;

        if (health <= 0) {
            GetComponentInChildren<FirstPersonController>().enabled = false;
        }
    }
}
