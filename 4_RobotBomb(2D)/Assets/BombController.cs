using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    void Start()/// Start is called before the first frame update
    {
        
    }

    void Update()/// Update is called once per frame
    {
        
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "ROBOT")  /// ��ź�� �κ��� �������
        {
            ///2 hp����
            GameObject hp = GameObject.Find("HpController");    ///HpController - object
            if (collision.gameObject.tag == "ROBOT") { hp.GetComponent<HpController>().HpControl();  } ///HpController - script

            //1 �����
            Destroy(gameObject);
        }

    }





}