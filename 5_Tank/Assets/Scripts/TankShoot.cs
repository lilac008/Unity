using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShoot : MonoBehaviour
{

    ///1
    public Rigidbody prefabShell;
    public Transform fireTransform;

    ///2
    public int playerNum = 1;
    string fireName;


    void Start()/// Start is called before the first frame update
    {
        fireName = "Fire" + playerNum;
    }


    void Update()/// Update is called once per frame
    {

        ///2
        if (Input.GetButtonDown(fireName))    ///1.if (Input.GetButtonDown("Fire1"))
        {
            /// ??ź prefab ??ü ????
            Rigidbody shellInstance = Instantiate(prefabShell, fireTransform.position, fireTransform.rotation) as Rigidbody;

            /// ??ź ?߻?
            shellInstance.velocity = 20.0f * fireTransform.forward;
        }

    }
}
