using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody rRacket;
    Vector3 startP;                                   /// ������ġ


    void Start() /// Start is called before the first frame update
    {
        rRacket = GetComponent<Rigidbody>();

        startP = new Vector3(0, 0, 0);                ///startP �ʱ�ȭ
    }


    void Update() /// Update is called once per frame
    {
        if (Input.GetKey(KeyCode.LeftArrow) == true) {transform.Translate(Vector3.left * speed * Time.deltaTime);}
        if (Input.GetKey(KeyCode.RightArrow) == true) {transform.Translate(Vector3.right * speed * Time.deltaTime);}

        /// Rigidbody ���������� �̿��� �̵�
        ///if (Input.GetKey(KeyCode.LeftArrow) == true)  {racketRd.AddForce(-speed, 0, 0);}
        ///if (Input.GetKey(KeyCode.RightArrow) == true)  {racketRd.AddForce(+speed, 0, 0);}

    }




}