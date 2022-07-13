using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public ParticleSystem tankExplosion;

    void Start() /// Start is called before the first frame update
    {
        
    }


    void Update() /// Update is called once per frame
    {
        
    }

    public void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "SHELL")
        {
            ParticleSystem fire = Instantiate(tankExplosion, transform.position, transform.rotation);
            fire.Play();                        ///ÀÌÆåÆ® Àç»ý

            Destroy(gameObject);
            Destroy(fire.gameObject, 2.0f);
        }
    }


}
