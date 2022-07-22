using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBall : MonoBehaviour
{
    public float speed = 0.0f;

    private Rigidbody rBall;
    Vector3 startP;


    void Start() /// Start is called before the first frame update
    {
        rBall = GetComponent<Rigidbody>();
        rBall.AddForce(Random.Range(-500.0f, 500.0f), 0f, speed * 0.7f);

        startP = new Vector3(0, 0, 0);
    }

    void Update() /// Update is called once per frame
    {

    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("WALL") || col.gameObject.CompareTag("RACKET"))   /// BlockBall script가 WALL tag 또는 RACKET tag에 충돌하면
        {
            Vector3 currP = transform.position;

            Vector3 incomVec = currP - startP;
            Vector3 normalVec = col.contacts[0].normal;
            Vector3 reflectVec = Vector3.Reflect(incomVec, normalVec);
            reflectVec = reflectVec.normalized;

            rBall.AddForce(reflectVec * speed);
        }

        if (col.gameObject.CompareTag("BLOCK"))                                        /// BlockBall script가 BLOCK tag object에 충돌하면
        {
            Vector3 currP = transform.position;

            Vector3 incomVec = currP - startP;
            Vector3 normalVec = col.contacts[0].normal;
            Vector3 reflectVec = Vector3.Reflect(incomVec, normalVec);
            reflectVec = reflectVec.normalized;

            rBall.AddForce(reflectVec * speed);

            Destroy(col.gameObject);                                                 /// Destroy(이 script와 충돌한 object)
        }

        startP = transform.position;
    }
}
