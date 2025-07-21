using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;

public class PlayerShoot : MonoBehaviour
{
    bool isShooting;
    [SerializeField] GameObject bullet;
    [SerializeField] int damage;
    [SerializeField] GameObject dustFX;
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
        if (isShooting) return;
        isShooting = true;
        /*
        Transform newBullet = Instantiate(bullet).transform;
        newBullet.position = transform.position;
        //newBullet.eulerAngles = currentEulerAngles;
        Bullet newBulletScript = newBullet.GetComponent<Bullet>();
        newBulletScript.SetDamage(damage);
        */
        animation.Play();
        cinemachineImpulseSource.GenerateImpulse();

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.parent.forward, out hit, Mathf.Infinity))

        {
            Debug.DrawRay(transform.position, transform.parent.forward * hit.distance, Color.yellow);
            hit.transform.GetComponentInParent<CreatureHealth>()?.Damage(damage);
            //Instantiate(dustFX, transform.position);
            Instantiate(dustFX, hit.point, transform.rotation);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }

    }
}
