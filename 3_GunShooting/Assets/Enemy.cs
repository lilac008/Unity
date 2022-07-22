using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 1.0f;             

    private float x;
    private float length = 2.0f;
    private float timeAfterMove;

    void Start()/// Start is called before the first frame update
    {

    }

    void Update()/// Update is called once per frame
    {
        timeAfterMove += Time.deltaTime;
        x = Mathf.Sin(timeAfterMove) * length;

        transform.position = new Vector3(x * speed, transform.position.y, transform.position.z);       

    }
}
