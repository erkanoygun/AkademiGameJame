using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CharacterController : MonoBehaviour
{
    public float speed = 2.0f;
    bool keyD;
    bool keyA;

    
    void Update()
    {
        keyD = Input.GetKey(KeyCode.D);
        keyA = Input.GetKey(KeyCode.A);
        
    }

    void FixedUpdate()
    {
        if (keyD)
        {
            transform.position = new Vector3(1.3f, transform.position.y, transform.position.z);

        }
        if (keyA)
        {
            transform.position = new Vector3(-1.3f, transform.position.y, transform.position.z);
        }

        transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }

    
}
