using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    void Start()/// Start is called before the first frame update
    {
        
    }

    void Update()/// Update is called once per frame
    {
        
    }

    

    private void OnCollisionEnter2D(Collision2D col)
    {

        if(col.gameObject.tag == "ROBOT")                                                         /// bomb skript�� robot tag�� �浹�� ���
        {
            GameObject hp = GameObject.Find("HpController");                                      /// ���� hp = HpController object�� ã�ƶ�.
            if (col.gameObject.tag == "ROBOT") 
            { hp.GetComponent<HpController>().HpControl();  }  


            Destroy(gameObject);                                                                  /// �������
        }

    }





}