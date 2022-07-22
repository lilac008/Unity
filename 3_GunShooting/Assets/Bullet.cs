using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public float speed = 10.0f;
    GameObject player;


    public void Start()/// Start is called before the first frame update
    {

    }

    void Update()/// Update is called once per frame
    {

    }


    public void ShootToEnemy() ///player�� Enemy���� ���� �� �� 
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, speed));
    }


    public void ShootToPlayer() ///Enemy�� player���� ���� �� �� 
    {
        player = GameObject.Find("PLAYER");

        Vector3 dir = player.transform.position - this.transform.position;
        GetComponent<Rigidbody>().AddForce(dir * speed / 10);
    }


    public void OnCollisionEnter(Collision coll)
    {
        print("name : " + coll.collider.name);


        if (coll.collider.tag == "ENEMY")   ///bullet script�� Enemy�� �浹�ϸ�
        {
            /// UI ī���� +1
            GameObject manager = GameObject.Find("ScoreManager");
            manager.GetComponent<ScoreScript>().IncScore();

            Destroy(gameObject);///�Ѿ��ı�
        }



        if (coll.collider.name == "Target1")    ///bullet script�� Target1�� �浹�ϸ�
        {
            /// UI ī���� +1
            GameObject manager = GameObject.Find("ScoreManager");
            manager.GetComponent<ScoreScript>().IncScore(5);

            Destroy(gameObject, 0.0f);
        }

        if (coll.collider.name == "Target2")
        {
            /// UI ī���� +1
            GameObject manager = GameObject.Find("ScoreManager");
            manager.GetComponent<ScoreScript>().IncScore(2);

            Destroy(gameObject, 0.0f);
        }

        if (coll.collider.name == "Target3")
        {
            /// UI ī���� +1
            GameObject manager = GameObject.Find("ScoreManager");
            manager.GetComponent<ScoreScript>().IncScore(3);

            Destroy(gameObject, 0.0f);
        }

    }


}