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

    private GameObject _UICanvas;
    private GameObject _InGameCanvas;
    private GameObject _HamerImage;
    void Start()
    {

        _UICanvas = GameObject.Find("UICanvas");
        _InGameCanvas = _UICanvas.transform.GetChild(3).gameObject;
        _HamerImage = _InGameCanvas.transform.GetChild(9).gameObject;

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
                    _HamerImage.SetActive(false);

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
