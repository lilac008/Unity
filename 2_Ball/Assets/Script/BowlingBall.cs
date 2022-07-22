using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : MonoBehaviour
{
    public float speed = 10.0f;

    private Rigidbody ballR;

    Vector3 startP;                                       ///������ġ                                      


    void Start()/// Start is called before the first frame update
    {
        ballR = GetComponent<Rigidbody>();
        ballR.AddForce(Random.Range(-400.0f, 400.0f), 0, speed);

        startP = new Vector3(0, 0, 0);                   /// startP �ʱ�ȭ
    }


    void Update()/// Update is called once per frame
    {

    }


    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("WALL"))                          ///BowlingBall script�� WALL tag�� ���� game object�� �浹�ϸ�
        {
            Vector3 currP = transform.position;                         /// ���� ball script ��ġ
            Vector3 incomVec = currP - startP;                          /// �Ի簢
            Vector3 normalVec = col.contacts[0].normal;                 /// ��������
            Vector3 reflectVec = Vector3.Reflect(incomVec, normalVec);  /// �ݻ簢

            reflectVec = reflectVec.normalized;                         /// �ݻ簢 ����ȭ

            ballR.AddForce(reflectVec * speed);
        }
        startP = transform.position;

    }

}