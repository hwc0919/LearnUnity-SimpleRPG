using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearBullet : MonoBehaviour
{
    private Rigidbody rigidBody;
    private Collider col;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnableCollider()
    {
        col.enabled = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            return;
        }

        rigidBody.velocity = Vector3.zero;
        rigidBody.isKinematic = true;
        rigidBody.useGravity = false;
        col.enabled = false;

        Destroy(gameObject, 5.0f);
    }
}
