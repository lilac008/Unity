using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    float mSpeed = 10.0f;          /// move
    float rSpeed = 150.0f;         /// rotate 

    public int playerNum = 1;       /// ��ũ ��ȣ
    private string mvAxisName;      /// �̵��� �̸�(Vertical1, Vertical2)
    private string roAxisName;      /// ȸ���� �̸�(Horizontal1, Horizontal2)


    void Start() /// Start is called before the first frame update
    {
        mvAxisName = "Vertical" + playerNum;
        roAxisName = "Horizontal" + playerNum;
    }

    void Update() /// Update is called once per frame
    {

        ///Ű���� ���� : Vertical1(ws), Horizontal1(ad)
        ///float mv = Input.GetAxis("Vertical1") * mSpeed * Time.deltaTime;
        ///float ro = Input.GetAxis("Horizontal1") * rSpeed * Time.deltaTime;

        float mv = Input.GetAxis(mvAxisName) * mSpeed * Time.deltaTime;
        float ro = Input.GetAxis(roAxisName) * rSpeed * Time.deltaTime;

        transform.Translate(0, 0, mv);
        transform.Rotate(0, ro, 0);


    }
}