using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    CharacterController controllerScript;
    //[SerializeField] private List<GameObject> spawnGameObjects;
    public bool isHammer = false;
    public bool isAtil = false;
    int selectObjectIndex = 0;
    public float forceback;
    Rigidbody _rigidbody;
    void Start()
    {
        controllerScript = GetComponent<CharacterController>();
        _rigidbody= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        //if (collision.gameObject.CompareTag("Slack"))
        //{
        //    Destroy(collision.gameObject);
        //    TotalScores.TotalSlack ++;
        //}

        if (collision.gameObject.CompareTag("FalseDoor"))
        {
            //Destroy(collision.gameObject);
            if (!isHammer)
            {
                _rigidbody.AddForce(transform.forward * -1 * forceback);
                
                //StartCoroutine("BackSpeed");
                //bu kýsmý force ile yapmýþ oldum
            }
            
        }
        if (collision.gameObject.CompareTag("Hammer"))
        {
            isHammer = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("RightDoor"))
        {
            //StartCoroutine("SpawnObject");

        }
        if (collision.gameObject.CompareTag("Atýl"))
        {
            isAtil = true;
            StartCoroutine("SpawnObject");

        }
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Light"))
        {
            Debug.Log("Here");
        }
    }

    //IEnumerator BackSpeed()
    //{
    //    yield return new WaitForSeconds(1f);
    //    controllerScript.runingspeed = 2f;
    //}
    IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(1f);
        //spawnGameObjects[selectObjectIndex].SetActive(true);
        //selectObjectIndex += 1;
    }
}
