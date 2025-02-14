using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearWeapon : Weapon
{
    public GameObject bulletPrefab;

    public override void Attack()
    {
        GameObject bullet = GameObject.Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = transform.forward;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
