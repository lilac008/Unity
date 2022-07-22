using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;       //Serializable 선언하기 위해


[Serializable]      ///선언시 클래스 변수가 보임
public class Man
{
    public string name;
    public int age;
    
}


public class Serialized : MonoBehaviour
{
    public Man man;




    [HideInInspector] //선언 바로 첫아랫줄만 hide됨
    public float speed = 5.0f;
    
    [SerializeField]  //선언시 나타나게함.
    private float timestamp = 1.0f;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
