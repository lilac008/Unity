using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellController : MonoBehaviour
{
    public ParticleSystem shellExplosion;


    void Start()/// Start is called before the first frame update
    {
        
    }

    void Update()/// Update is called once per frame
    {
        
    }

    public void OnCollisionEnter(Collision coll)
    {
        ParticleSystem fire = Instantiate(shellExplosion, transform.position, transform.rotation);
        fire.Play(); ///����Ʈ ���

        Destroy(gameObject);                /// ��ź �浹�� gameObject ������� ��
        Destroy(fire.gameObject, 2.0f);
        //Destroy();
    }


}