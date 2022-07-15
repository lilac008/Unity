using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBallController : MonoBehaviour
{
    public float speed = 0.0f;

    private Rigidbody ballRd;
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        ballRd = GetComponent<Rigidbody>();
        ballRd.AddForce(Random.Range(-500.0f, 500.0f), 0f, speed * 0.7f);

        startPos = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("WALL") || other.gameObject.CompareTag("RACKET"))
        {
            Vector3 currPos = transform.position;

            Vector3 incomVec = currPos - startPos;
            Vector3 normalVec = other.contacts[0].normal;
            Vector3 reflectVec = Vector3.Reflect(incomVec, normalVec);
            reflectVec = reflectVec.normalized;

            ballRd.AddForce(reflectVec * speed);
        }

        if (other.gameObject.CompareTag("BLOCK"))
        {
            Vector3 currPos = transform.position;

            Vector3 incomVec = currPos - startPos;
            Vector3 normalVec = other.contacts[0].normal;
            Vector3 reflectVec = Vector3.Reflect(incomVec, normalVec);
            reflectVec = reflectVec.normalized;

            ballRd.AddForce(reflectVec * speed);

            //
            Destroy(other.gameObject);
        }

        startPos = transform.position;
    }
}
