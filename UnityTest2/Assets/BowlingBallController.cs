using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBallController : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody ballRd;
    Vector3 startPos;                                      

    void Start()/// Start is called before the first frame update
    {
        ballRd = GetComponent<Rigidbody>();
        ballRd.AddForce(Random.Range(-400.0f, 400.0f), 0, speed);

        startPos = new Vector3(0, 0, 0);                   /// Vector3 startPos; 초기화
    }

    void Update()/// Update is called once per frame
    {

    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("WALL"))        ///공이 WALL에 충돌하면
        {
            Vector3 currPos = transform.position;                       /// 공위치
            Vector3 incomVec = currPos - startPos;                      /// 입사각
            Vector3 normalVec = other.contacts[0].normal;               /// 수직벡터
            Vector3 reflectVec = Vector3.Reflect(incomVec, normalVec);  /// 반사각

            reflectVec = reflectVec.normalized;                         /// 반사각 정규화

            ballRd.AddForce(reflectVec * speed);
        }

        startPos = transform.position;
    }

}
