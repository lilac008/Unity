using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    float mvSpeed = 10.0f;          /// move
    float roSpeed = 150.0f;         /// rotate 

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
        ///float mv = Input.GetAxis("Vertical1") * mvSpeed * Time.deltaTime;
        ///float ro = Input.GetAxis("Horizontal1") * roSpeed * Time.deltaTime;

        float mv = Input.GetAxis(mvAxisName) * mvSpeed * Time.deltaTime;
        float ro = Input.GetAxis(roAxisName) * roSpeed * Time.deltaTime;

        transform.Translate(0, 0, mv);
        transform.Rotate(0, ro, 0);


    }
}