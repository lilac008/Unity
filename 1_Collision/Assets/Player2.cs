using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    private Rigidbody rPlayer;
    public float speed = 10.0f;                      ///public선언시 script에서 조정 가능

    // Start is called before the first frame update
    void Start()
    {
        rPlayer = GetComponent<Rigidbody>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) == true) { rPlayer.AddForce(-speed, 0f, 0f);} ///x,y,z
        if (Input.GetKey(KeyCode.RightArrow) == true){ rPlayer.AddForce(speed, 0f, 0f); }
        if (Input.GetKey(KeyCode.UpArrow) == true)   { rPlayer.AddForce(0f, 0f, speed);}
        if (Input.GetKey(KeyCode.DownArrow) == true) { rPlayer.AddForce(0f, 0f, -speed);}
        if (Input.GetKey(KeyCode.Space) == true)     { rPlayer.AddForce(0f, speed, 0f);}




    }
}
