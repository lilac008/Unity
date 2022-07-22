using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deltatime : MonoBehaviour
{
    float speed = 20.0f;

    float startTime;
    float startDeltaTime;



    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;  ///초기 값
        startDeltaTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        float t = Time.time - startTime;
        startDeltaTime += Time.deltaTime * 1.0f;
        Debug.Log("" + t);
        Debug.Log("" + startDeltaTime);

        
        /*
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        h = h * speed * Time.deltaTime;
        v = v * speed * Time.deltaTime;

        transform.Translate(Vector2.right * h);
        transform.Translate(Vector2.up * v);
        */



    }




}
