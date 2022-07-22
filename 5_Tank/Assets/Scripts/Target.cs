using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public ParticleSystem tankExplosion;


    void Start() /// Start is called before the first frame update
    {
        
    }


    void Update() /// Update is called once per frame
    {
        
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "SHELL")                 ///Target skript가 SHELL tag와 충돌할 때
        {
            ParticleSystem fire = Instantiate(tankExplosion, transform.position, transform.rotation);
            fire.Play();                                ///이펙트 재생

            Destroy(gameObject);
            Destroy(fire.gameObject, 2.0f);
        }
    }


}
