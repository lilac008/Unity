using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    Rigidbody2D robotRD;
    public float walkSpeed = 10.0f;
    public float jumpSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        robotRD = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * walkSpeed * Time.deltaTime);
        transform.Translate(Vector2.left * walkSpeed * Time.deltaTime);

        
    }


}
