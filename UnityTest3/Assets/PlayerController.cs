using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;

    void Start()/// Start is called before the first frame update
    {

    }

    void Update()/// Update is called once per frame
    {
        if (Input.GetKey(KeyCode.LeftArrow)) {transform.Translate(Vector3.left * speed * Time.deltaTime);}
        if (Input.GetKey(KeyCode.RightArrow)){transform.Translate(Vector3.right * speed * Time.deltaTime);}
    }
}
