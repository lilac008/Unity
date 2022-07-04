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

        startPos = new Vector3(0, 0, 0);                ///Vector3 startPos; �ʱ�ȭ
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision collision)   ///collision = ��
    {
        ///print(collision.gameObject.name);

        // ���� ���� �浹�ϸ�
        if (collision.gameObject.CompareTag("WALL"))
        {
            Vector3 currPos = transform.position;                       /// ����ġ
            Vector3 incomVec = currPos - startPos;                      /// �Ի簢
            Vector3 normalVec = collision.contacts[0].normal;           /// ��������
            Vector3 reflectVec = Vector3.Reflect(incomVec, normalVec);  /// �ݻ簢

            reflectVec = reflectVec.normalized;                         /// �ݻ簢 ����ȭ

            ballRd.AddForce(reflectVec * speed);
        }

        startPos = transform.position;
    }
}