using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    Animation anim;
    Animator animator;
    void Start()
    {
        animator = GetComponentInParent<Animator>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameObject.tag == "FalseDoor")
            {
                collision.rigidbody.velocity = new Vector3(0, 0, -3);
            }
            else
            {
                animator.SetTrigger("Open");
            }
        }
    }
}
