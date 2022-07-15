using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun2Controller : MonoBehaviour
{
    GameObject player;
    Vector3 dir;

    void Start()/// Start is called before the first frame update
    {
        player = GameObject.Find("Player");
    }

    void Update()/// Update is called once per frame
    {

        ///적의 총구를 player 방향으로 조준하기 위해 rotation 변경
        dir = player.transform.position - this.transform.position;         
        this.transform.rotation = Quaternion.LookRotation(dir);
    }



}
