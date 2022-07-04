using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody ballRd;
    public float speed = 10.0f;                         ///150

    Vector3 startPos;                                   ///

    // Start is called before the first frame update
    void Start()
    {
        ballRd = GetComponent<Rigidbody>();
        ballRd.AddForce(-speed, 0f, speed * 0.7f);

        startPos = new Vector3(0, 0, 0);                ///Vector3 startPos; 초기화
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision collision)   ///collision = 벽
    {
        ///print(collision.gameObject.name);

        // 공이 벽에 충돌하면
        if (collision.gameObject.CompareTag("WALL"))
        {
            Vector3 currPos = transform.position;                       /// 공위치
            Vector3 incomVec = currPos - startPos;                      /// 입사각
            Vector3 normalVec = collision.contacts[0].normal;           /// 수직벡터
            Vector3 reflectVec = Vector3.Reflect(incomVec, normalVec);  /// 반사각

            reflectVec = reflectVec.normalized;                         /// 반사각 정규화

            ballRd.AddForce(reflectVec * speed);
        }

        startPos = transform.position;
    }
}
