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

        if(col.gameObject.tag == "ROBOT")                                                         /// bomb skript가 robot tag와 충돌할 경우
        {
            GameObject hp = GameObject.Find("HpController");                                      /// 변수 hp = HpController object를 찾아라.
            if (col.gameObject.tag == "ROBOT") 
            { hp.GetComponent<HpController>().HpControl();  }  


            Destroy(gameObject);                                                                  /// 사라지게
        }

    }





}
