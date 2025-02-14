using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheWeapon : Weapon
{
    public const string ANIMATION_PARAM_ISATTACKING = "isAttacking";

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public override void Attack()
    {
        animator.SetTrigger(ANIMATION_PARAM_ISATTACKING);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            print("Trigger with enemy " + other.name);
        }
    }

    void Update()
    {
    }
}
