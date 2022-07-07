using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public GameObject bulletPrefab; /// ������Ÿ�� GameObject

    void Start()/// Start is called before the first frame update
    {

    }

    void Update()/// Update is called once per frame
    {


        if (Input.GetMouseButtonDown(0))  ///���콺 Ŭ����
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);  ///Prefab�� ����Ͽ� �Ѿ� object ����
            bullet.GetComponent<BulletController>().ShootToEnemy();                                 ///Bulletcontroller���� Shoot() ȣ�� (�Ѿ� �߻�) - bullet prefab���� BulletController componet���� Shoot()ȣ��
        }


    }
}