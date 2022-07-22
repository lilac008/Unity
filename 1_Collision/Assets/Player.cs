using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 10.0f;

    void Start() /// Start is called before the first frame update
    {
        ///print("Start!");
        ///transform.Translate(Vector3.left * speed);      ///시작할때 왼쪽으로 이동.
    }

    void Update() /// Update is called once per frame
    {
        ///Debug.Log("Update!"); 


        ///Vector3 타입 : 벡터의 방향과 속도로 object 이동   /    Time.deltaTime : 1FPS  1초에 1개 그림, 100FPS 1초에 100개 그림, Time.deltaTime을 이용해 두 유저가 같은 결과값을 얻도록 함.
        if (Input.GetKey(KeyCode.LeftArrow) == true) { transform.Translate(Vector3.left * speed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.RightArrow) == true){ transform.Translate(Vector3.right * speed * Time.deltaTime);}
        if (Input.GetKey(KeyCode.UpArrow) == true)   { transform.Translate(Vector3.forward * speed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.DownArrow) == true) { transform.Translate(Vector3.back * speed * Time.deltaTime); }
    }





}
