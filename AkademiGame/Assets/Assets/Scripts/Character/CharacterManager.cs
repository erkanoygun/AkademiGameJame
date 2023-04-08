using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    CharacterController controllerScript;
    [SerializeField] private List<GameObject> spawnGameObjects;
    public bool isHammer = false;
    int selectObjectIndex = 0;
    void Start()
    {
        controllerScript = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("FalseDoor"))
        {
            //Destroy(collision.gameObject);
            if (!isHammer)
            {
                controllerScript.speed = 0.05f;
                StartCoroutine("BackSpeed");
            }
            
        }
        if (collision.gameObject.CompareTag("Hammer"))
        {
            isHammer = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("RightDoor"))
        {
            Debug.Log("Here");
            StartCoroutine("SpawnObject");

        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Here");
    }*/

    IEnumerator BackSpeed()
    {
        yield return new WaitForSeconds(3f);
        controllerScript.speed = 2f;
    }
    IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(1f);
        spawnGameObjects[selectObjectIndex].SetActive(true);
        selectObjectIndex += 1;
    }
}
