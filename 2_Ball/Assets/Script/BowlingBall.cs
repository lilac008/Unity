using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : MonoBehaviour
{
    public float speed = 10.0f;

    private Rigidbody ballR;

    Vector3 startP;                                       ///시작위치                                      


    void Start()/// Start is called before the first frame update
    {
        ballR = GetComponent<Rigidbody>();
        ballR.AddForce(Random.Range(-400.0f, 400.0f), 0, speed);

        startP = new Vector3(0, 0, 0);                   /// startP 초기화
    }


    void Update()/// Update is called once per frame
    {

    }


    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("WALL"))                          ///BowlingBall script가 WALL tag를 가진 game object에 충돌하면
        {
            Vector3 currP = transform.position;                         /// 현재 ball script 위치
            Vector3 incomVec = currP - startP;                          /// 입사각
            Vector3 normalVec = col.contacts[0].normal;                 /// 수직벡터
            Vector3 reflectVec = Vector3.Reflect(incomVec, normalVec);  /// 반사각

            reflectVec = reflectVec.normalized;                         /// 반사각 정규화

            ballR.AddForce(reflectVec * speed);
        }
        startP = transform.position;

    }

}
