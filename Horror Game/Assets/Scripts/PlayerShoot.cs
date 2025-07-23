using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{

    public List<Bullet> bullets { get; private set; } = new List<Bullet>();
    public int maxBullets { get; private set; } = 10;
    [SerializeField] Image[] bulletBars;
    //[SerializeField] int damage;
    //[SerializeField] GameObject dustFX;
    bool isShooting;
    Animation animation;
    CinemachineImpulseSource cinemachineImpulseSource;

    void Awake()
    {
        animation = GetComponent<Animation>();
        cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
        AdjustBulletUI();
    }

    public void AddAmmo(Bullet bulletType, int ammoAmount)
    {
        for (int i = 0; i < ammoAmount; i++) bullets.Add(bulletType);
        while (bullets.Count > maxBullets) bullets.RemoveAt(maxBullets);
        AdjustBulletUI();
    }

    void AdjustBulletUI()
    {
        for (int i = 0; i < maxBullets; i++)
        {

            if (i < bullets.Count)
            {
                bulletBars[i].gameObject.SetActive(true);
                bulletBars[i].color = bullets[i].color;
            }
            else
            {
                bulletBars[i].gameObject.SetActive(false);
            }
        }
    }

    public void SetIsShootingFalse()
    {
        isShooting = false;
    }

    public void Shoot()
    {
        if (isShooting || bullets.Count <= 0) return;
        isShooting = true;

        animation.Play();
        cinemachineImpulseSource.GenerateImpulse();

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.parent.forward, out hit, Mathf.Infinity))

        {
            Debug.DrawRay(transform.position, transform.parent.forward * hit.distance, Color.yellow);
            hit.transform.GetComponentInParent<CreatureHealth>()?.Damage(bullets[0].damage);
            //Instantiate(dustFX, transform.position);
            Instantiate(bullets[0].particleFXPrefab, hit.point, transform.rotation);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }

        bullets.RemoveAt(0);
        AdjustBulletUI();
    }
}
