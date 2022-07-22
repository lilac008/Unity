using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator2 : MonoBehaviour
{
    public GameObject bulletPrefab;
    private float time = 0.0f;

    void Start()/// Start is called before the first frame update
    {

    }

    void Update()/// Update is called once per frame
    {

        /// 0.5초마다 실행
        this.time += Time.deltaTime; 

        if (this.time > 0.5f)
        {

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);   ///Prefab을 사용하여 총알 object 생성
            bullet.GetComponent<Bullet>().ShootToPlayer();                                           ///bullet prefab에서 Bullet script componet에서 Shoot()호출

            this.time = 0.0f;
        }

    }


}


