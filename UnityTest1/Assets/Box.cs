using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision coll) /// 
    {
        print("�浹�߻� Enter!" + coll.gameObject.name);
    }



    public void OnCollisionExit(Collision coll)
    {
        print("�浹�߻� Exit!");
    }
}