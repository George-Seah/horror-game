using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    CharacterController controller;
    [SerializeField] GameObject bullet;
    [SerializeField] int damage;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Shoot"))
        {
            Bullet newBullet = Instantiate(bullet).GetComponent<Bullet>();
            newBullet.SetDamage(damage);
        }
    }
}
