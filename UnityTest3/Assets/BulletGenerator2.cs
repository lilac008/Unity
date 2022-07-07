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

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);   /// 프리팹을 이용해서 오브젝트(총알) 생성
            bullet.GetComponent<BulletController>().ShootToPlayer();                                 /// BulletController에서 Shoot 메서드 호출(총알 발사)

            this.time = 0.0f;
        }



       
        ///if (Input.GetMouseButtonDown(0))
        ///{
        ///    // 프리팹을 이용해서 오브젝트(총알) 생성
        ///    GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        ///    // BulletController에서 Shoot 메서드 호출(총알 발사)
        ///    bullet.GetComponent<BulletController>().ShootToPlayer();
        ///}
     

    }


}


