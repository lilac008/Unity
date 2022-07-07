using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 10.0f;

    void Start() /// Start is called before the first frame update
    {
        ///print("Start!");
        ///transform.Translate(Vector3.left * speed);   ///MonoBehaviour 객체 멤버, 시작할때 왼쪽으로 이동.
    }

    void Update() /// Update is called once per frame
    {
        ///Debug.Log("Update!"); 


        ///Vector3 타입 : 벡터의 방향과 속도로 오브젝트 이동
        ///deltaTime : 컴퓨터 성능에 따라 속도가 일정하도록 프레임 시간 간격을 동기화하는 값
        if (Input.GetKey(KeyCode.LeftArrow) == true) { transform.Translate(Vector3.left * speed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.RightArrow) == true){ transform.Translate(Vector3.right * speed * Time.deltaTime);}
        if (Input.GetKey(KeyCode.UpArrow) == true)   { transform.Translate(Vector3.forward * speed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.DownArrow) == true) { transform.Translate(Vector3.back * speed * Time.deltaTime); }
    }





}
