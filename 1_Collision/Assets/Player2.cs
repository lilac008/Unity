using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    private Rigidbody playerR;
    public float speed = 10.0f;                      ///public선언시 script에서 조정 가능

    // Start is called before the first frame update
    void Start()
    {
        playerR = GetComponent<Rigidbody>();        ///해당 스크립트가 적용된 오브젝트에서 Rigidbody Component 생성
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) == true) {playerR.AddForce(-speed, 0f, 0f);} ///x,y,z
        if (Input.GetKey(KeyCode.RightArrow) == true){playerR.AddForce(speed, 0f, 0f); }
        if (Input.GetKey(KeyCode.UpArrow) == true)   {playerR.AddForce(0f, 0f, speed);}
        if (Input.GetKey(KeyCode.DownArrow) == true) {playerR.AddForce(0f, 0f, -speed);}
        if (Input.GetKey(KeyCode.Space) == true)     {playerR.AddForce(0f, speed, 0f);}




    }
}
