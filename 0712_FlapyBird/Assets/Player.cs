using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /// private int Score = 0; 대신 GameManager에서 선언




    void Start() /// Start is called before the first frame update
    {
        
    }


    void Update() /// Update is called once per frame
    {
        if (Input.GetMouseButtonDown(0))        ///마우스 누를때마다 
        {
            jump();     ///점프함수 호출   
        }
    }


    void jump() ///점프 함수 : 초당 프레임을 낮추기 위해 업데이트 내에 함수는 외부에서 작업
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * 200);     ///가속도
        ///transform.Translate();
        ///Vector3.MoveTowards();
        ///좌표이동방법
        ///유니티 시스템에서 호출되는 이벤트의 처리 과정에 대해 설명
        ///멀티thread
               
    }


    private void OnTriggerEnter2D(Collider2D col)  ///충돌감지 메서드 OnTrigger 물리연산 필요없음 / isTrigger 체크 / 문을 열때
    {
        if (col.tag == "score") 
        {
            /// 점수 + 1 (GameManager script에서 Score변수 불러오기 - 횟수 추가)
            /// GameObject.FindObjectOfType<GameManager>().Score++;
            /// Destroy(col.gameObject);    //object사라짐

            Debug.Log("부딪힘_트리거");
        }
    }

    /*
    private void OnCollisionEnter2D(Collision2D col) ///충돌감지 메서드 OnCollision 물리기반충돌처리 / isTrigger 체크해제 / 문을 감지해서 만질때
    {
        if (col.tag == "score")
        {
            Debug.Log("부딪힘_콜리젼");
        }
    }
    */


}
