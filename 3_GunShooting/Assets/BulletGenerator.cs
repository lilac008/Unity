using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public GameObject bulletPrefab; /// 데이터타입 GameObject

    void Start()/// Start is called before the first frame update
    {

    }

    void Update()/// Update is called once per frame
    {


        if (Input.GetMouseButtonDown(0))  ///마우스 클릭시
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);  ///Prefab을 사용하여 총알 object 생성
            bullet.GetComponent<BulletController>().ShootToEnemy();                                 ///Bulletcontroller에서 Shoot() 호출 (총알 발사) - bullet prefab에서 BulletController componet에서 Shoot()호출
        }


    }
}
