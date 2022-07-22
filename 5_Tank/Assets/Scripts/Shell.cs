using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public ParticleSystem shellExplosion;


    void Start() /// Start is called before the first frame update
    {
        
    }

    void Update() /// Update is called once per frame
    {
        
    }

    public void OnCollisionEnter(Collision col)
    {
        ParticleSystem fire = Instantiate(shellExplosion, transform.position, transform.rotation);
        fire.Play();                         /// 이펙트 재생

        Destroy(gameObject);                 /// shell skript 충돌시 gameObject 사라지게 함
        Destroy(fire.gameObject, 2.0f);

    }


}
