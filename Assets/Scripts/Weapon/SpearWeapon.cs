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
    private Animator animator;

    public override void Attack()
    {
        if (!bulletInHand)
        {
            print("No bullet");
            return;
        }
        // fire
        animator.SetTrigger("ready"); // will trigger Shoot method
    }

    public void Shoot() // animation triggered
    {
        bulletInHand.transform.SetParent(null);
        Rigidbody rigidbody = bulletInHand.GetComponent<Rigidbody>();
        // set properties
        rigidbody.velocity = transform.forward * bulletSpeed;
        rigidbody.useGravity = true;

        SpearBullet bullet = bulletInHand.GetComponent<SpearBullet>();
        bullet.EnableCollider();

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
        animator = GetComponent<Animator>();

        // Destroy original
        var obj = transform.Find("SpearBullet");
        if (obj != null)
        {
            Destroy(obj.gameObject);
        }
        // create new
        NewBulletInHand();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
