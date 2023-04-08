using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;


    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position = new Vector3(1.3f, transform.position.y, transform.position.z);
            
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position = new Vector3(-1.3f, transform.position.y, transform.position.z);
        }
    }

    void FixedUpdate()
    {
        transform.position += transform.forward * _speed * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("FalseDoor"))
        {
            Destroy(collision.gameObject);
            _speed = 0.01f;
            StartCoroutine("BackSpeed");
        }

    }

    /*private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Here");
    }*/

    IEnumerator BackSpeed()
    {
        yield return new WaitForSeconds(3f);
        _speed = 1f;
    }
}
