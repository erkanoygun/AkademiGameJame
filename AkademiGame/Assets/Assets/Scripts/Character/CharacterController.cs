using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class CharacterController : MonoBehaviour
{
    public float runingspeed;
    public float xspeed = 1f;
    bool keyD;
    bool keyA;
    public float limitx;
    //platformdan çýkmasýný engelleyen limit
    float deltax;
    //limit deðerleri girdikten sonra x düzlemindeki yeri

    void Update()
    {
        keyD = Input.GetKey(KeyCode.D);
        keyA = Input.GetKey(KeyCode.A);
        
    }

    void FixedUpdate()
    {
        if (keyD)
        {
            transform.position = new Vector3(transform.position.x + xspeed * Time.fixedDeltaTime, transform.position.y, transform.position.z);

        }
        if (keyA)
        {
            transform.position = new Vector3(transform.position.x - xspeed * Time.fixedDeltaTime, transform.position.y, transform.position.z);
        }
        deltax = Mathf.Clamp(transform.position.x, -limitx, limitx);
        Vector3 newPosition = new Vector3(deltax, transform.position.y, transform.position.z + runingspeed * Time.fixedDeltaTime);
        //transform.position += transform.forward * runingspeed * Time.fixedDeltaTime;
        transform.position = newPosition;
    }

    
}
