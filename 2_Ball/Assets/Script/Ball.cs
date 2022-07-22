using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 10.0f;

    private Rigidbody rBall;

    Vector3 startP;                                      ///���� ��ġ                               


    void Start()/// Start is called before the first frame update
    {
        rBall = GetComponent<Rigidbody>();
        rBall.AddForce(-speed, 0f, speed * 0.7f);

        startP = new Vector3(0, 0, 0);                ///startP �ʱ�ȭ
    }

    void Update()/// Update is called once per frame
    {

    }

    public void OnCollisionEnter(Collision col)   
    {
        print(col.gameObject.name);

        if (col.gameObject.CompareTag("WALL"))                          ///ball script�� WALL tag�� ���� game object�� �浹�ϸ�
        {
            Vector3 currP = transform.position;                         /// ���� ball script ��ġ
            Vector3 incomVec = currP - startP;                          /// �Ի簢
            Vector3 normalVec = col.contacts[0].normal;                 /// ��������
            Vector3 reflectVec = Vector3.Reflect(incomVec, normalVec);  /// �ݻ簢

            reflectVec = reflectVec.normalized;                         /// �ݻ簢 ����ȭ

            rBall.AddForce(reflectVec * speed);
        }
        startP = transform.position;
    }
}