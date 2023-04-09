using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RayCastTrigger : MonoBehaviour
{
    public float range = 5.0f;
    private Doors doorsScript;
    CharacterManager CharacterManagerScript;
    GameObject rightDoor;

    public GameObject atilHocaImage;
    void Start()
    {
        CharacterManagerScript = GetComponent<CharacterManager>();
    }

    
    void Update()
    {

        Vector3 direction = Vector3.forward;
        Ray theRay = new Ray(transform.position, transform.TransformDirection(direction * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(direction * range));

        if(Physics.Raycast(theRay, out RaycastHit hit, range))
        {
            
            if (hit.collider.tag == "Doors")
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    if (CharacterManagerScript.isAtil)
                    {
                        doorsScript = GetRightDoor().gameObject.GetComponentInChildren<Doors>();
                        doorsScript.animator.SetTrigger("Open");
                        CharacterManagerScript.isAtil = false;
                        atilHocaImage.SetActive(false);
                    }
                    
                }
                
            }
        }

        GameObject GetRightDoor()
        {
            if (hit.collider.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.CompareTag("RightDoor"))
            {
                rightDoor = hit.collider.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
            }
            else
            {
                rightDoor = hit.collider.gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject;
            }

            return rightDoor;
        }
    }
}
