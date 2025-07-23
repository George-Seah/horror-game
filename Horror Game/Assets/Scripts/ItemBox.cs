using UnityEngine;

public class ItemBox : MonoBehaviour
{
    [SerializeField] Bullet bulletType;
    [SerializeField] int bulletAmount;

    void OnTriggerEnter(Collider other)
    {
        PlayerShoot playerShoot = other.GetComponentInChildren<PlayerShoot>();
        if (!playerShoot || playerShoot.bullets.Count >= playerShoot.maxBullets) return;

        playerShoot.AddAmmo(bulletType, bulletAmount);
        Destroy(gameObject);
    }
}
