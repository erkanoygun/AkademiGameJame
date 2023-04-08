using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    //Animation anim;
    Animator animator;
    Explosion explosionScript;
    CharacterManager characterManagerScript;
    GameObject Character;
    void Start()
    {
        explosionScript = GetComponent<Explosion>();
        animator = GetComponentInParent<Animator>();
        Character = GameObject.Find("Character");
        characterManagerScript = Character.GetComponent<CharacterManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameObject.tag == "FalseDoor")
            {
                
                if (characterManagerScript.isHammer)
                {
                    explosionScript.explode();
                }
                else
                {
                    collision.rigidbody.velocity = new Vector3(0, 0, -3);
                    Destroy(gameObject);
                }
                
            }
            else
            {
                animator.SetTrigger("Open");
            }
        }
    }
}
