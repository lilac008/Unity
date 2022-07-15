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

        /// 0.5�ʸ��� ����
        this.time += Time.deltaTime; 

        if (this.time > 0.5f)
        {

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);   /// �������� �̿��ؼ� ������Ʈ(�Ѿ�) ����
            bullet.GetComponent<BulletController>().ShootToPlayer();                                 /// BulletController���� Shoot �޼��� ȣ��(�Ѿ� �߻�)

            this.time = 0.0f;
        }



       
        ///if (Input.GetMouseButtonDown(0))
        ///{
        ///    // �������� �̿��ؼ� ������Ʈ(�Ѿ�) ����
        ///    GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        ///    // BulletController���� Shoot �޼��� ȣ��(�Ѿ� �߻�)
        ///    bullet.GetComponent<BulletController>().ShootToPlayer();
        ///}
     

    }


}

