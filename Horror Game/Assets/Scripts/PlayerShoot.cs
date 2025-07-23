using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;

public class PlayerShoot : MonoBehaviour
{

    [SerializeField] List<Bullet> bullets = new List<Bullet>();

    //[SerializeField] int damage;
    //[SerializeField] GameObject dustFX;
    bool isShooting;
    Animation animation;
    CinemachineImpulseSource cinemachineImpulseSource;

    void Awake()
    {
        animation = GetComponent<Animation>();
        cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
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
            bullets.RemoveAt(0);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }

    }
}
