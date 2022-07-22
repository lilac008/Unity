using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;


    void Start()// Start is called before the first frame update
    {
        
    }

    void Update()// Update is called once per frame
    {
        //둘다 물리엔진x, position위치만 바뀜
        ///transform.Translate(Vector3.right * Time.deltaTime);   /// 앞으로 가기(2D) : forward가 아니라 right
        ///transform.position = Vector3.MoveTowards(transform.position, new Vector3(10, 0, 0), Time.deltaTime);

        //물리엔진?
        ///gameObject.GetComponent<Rigidbody2D>().MovePosition(transform.position + transform.right * Time.deltaTime);  ///forward가 아니라 right
        ///gameObject.GetComponent<Rigidbody2D>().Position = Vector3.MoveTowards(transform.position, new Vector3(10, 0, 0), Time.deltaTime);

        ///gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * Time.deltaTime);  ///가속도
        ///gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right;
    }

}
