using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Doors : MonoBehaviour
{
    //Animation anim;
    public Animator animator;
    Explosion explosionScript;
    CharacterManager characterManagerScript;
    GameObject Character;

    private GameObject _InGameCanvas;
    private GameObject _hammerImg;
    void Start()
    {

        //_InGameCanvas = GameObject.Find("UICanvas");
        //_hammerImg = _InGameCanvas.transform.GetChild(3).gameObject;
        explosionScript = GetComponent<Explosion>();
        animator = GetComponentInParent<Animator>();
        Character = GameObject.Find("Character");
        characterManagerScript = Character.GetComponent<CharacterManager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (gameObject.tag == "FalseDoor")
            {

                if (characterManagerScript.isHammer)
                {
                    explosionScript.explode();
                    characterManagerScript.isHammer = false;
                   // _hammerImg.SetActive(false);

                }
                else
                {
                    other.attachedRigidbody.velocity = new Vector3(0, 0, -3);
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
