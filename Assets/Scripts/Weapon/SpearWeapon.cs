using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class SpearWeapon : Weapon
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    private GameObject bulletInHand;

    public override void Attack()
    {
        if (!bulletInHand)
        {
            print("No bullet");
            return;
        }
        // fire
        // Animator animator = bulletInHand.GetComponent<Animator>();
        // animator.SetTrigger("ready");
        // bulletInHand.transform.SetParent(null);
        print("forward: " + transform.forward);
        bulletInHand.transform.SetParent(null);
        bulletInHand.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
        print("velocity: " + bulletInHand.GetComponent<Rigidbody>().velocity);

        bulletInHand = null;
        Invoke("NewBulletInHand", 2.0f);
    }

    void NewBulletInHand()
    {
        if (bulletInHand)
        {
            throw new Exception("Already exists a bullet");
        }
        print("New bullet");
        bulletInHand = Instantiate(bulletPrefab, transform); // create as child
        bulletInHand.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        NewBulletInHand();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
