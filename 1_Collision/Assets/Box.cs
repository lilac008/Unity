using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    void Start()/// Start is called before the first frame update
    {
        
    }

    void Update()/// Update is called once per frame
    {
        
    }

    /// OnCollisionEnter  -  isTrigger가 켜져 있지 않을 때 콜라이더끼리 충돌하면 반응하는 함수
    /// OnTrigger         -  한 쪽 이상이 isTrigger가 켜져 있을 때 반응하며 인자로는 Collider를 사용합니다.
    public void OnCollisionEnter(Collision coll)   
    {
        print("충돌발생 Enter!" + coll.gameObject.name);
    }


    public void OnCollisionExit(Collision coll)
    {
        print("충돌발생 Exit!");
    }


}
