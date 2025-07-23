using UnityEngine;
using StarterAssets;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    int health = 100;
    [SerializeField] TMP_Text healthText;

    void Awake()
    {
        healthText.text = $"{health}";
    }

    public void Damage(int damage)
    {
        health -= damage;
        healthText.text = $"{health}";

        if (health <= 0)
        {
            GetComponentInChildren<FirstPersonController>().enabled = false;
        }
    }
}
