using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 10.0f;

    private Rigidbody ballRd;

    Vector3 startPos;                                   


    void Start()/// Start is called before the first frame update
    {
        ballRd = GetComponent<Rigidbody>();
        ballRd.AddForce(-speed, 0f, speed * 0.7f);

        startPos = new Vector3(0, 0, 0);                ///Vector3 startPos; �ʱ�ȭ
    }

    void Update()/// Update is called once per frame
    {

    }

    public void OnCollisionEnter(Collision other)   
    {
        ///print(collision.gameObject.name);

        if (other.gameObject.CompareTag("WALL"))        ///���� WALL�� �浹�ϸ�
        {
            Vector3 currPos = transform.position;                       /// ����ġ
            Vector3 incomVec = currPos - startPos;                      /// �Ի簢
            Vector3 normalVec = other.contacts[0].normal;               /// ��������
            Vector3 reflectVec = Vector3.Reflect(incomVec, normalVec);  /// �ݻ簢

            reflectVec = reflectVec.normalized;                         /// �ݻ簢 ����ȭ

            ballRd.AddForce(reflectVec * speed);
        }

        startPos = transform.position;
    }
}