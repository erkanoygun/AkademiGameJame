using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CharacterManager : MonoBehaviour
{
    CharacterController controllerScript;
    //[SerializeField] private List<GameObject> spawnGameObjects;
    public bool isHammer = false;
    public bool isAtil;
    public bool isFinish = false;
    public float forceback;

    private int Cpoint = 0;
    private int Spoint = 0;
    Rigidbody _rigidbody;

    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI _cpointtext;
    [SerializeField] private TextMeshProUGUI _spointtext;
    
    void Start()
    {
        controllerScript = GetComponent<CharacterController>();
        _rigidbody= GetComponent<Rigidbody>();
        isAtil = true;
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.CompareTag("FalseDoor"))
        {
            if (!isHammer)
            {
                _rigidbody.AddForce(transform.forward * -1 * forceback);
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
    }

    

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Finish"))
        {
            isFinish = true;
        }
        if (other.gameObject.CompareTag("Coursera"))
        {
            Cpoint += 1;
            _cpointtext.text = Cpoint.ToString() + "/6";
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Slack"))
        {
            Spoint += 1;
            _spointtext.text = Spoint.ToString() + "/10";
            Destroy(other.gameObject);
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
