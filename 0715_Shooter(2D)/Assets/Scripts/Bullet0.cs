using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet0 : MonoBehaviour, IWeapon 
{ 
    void Start() { }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BORDER")
        {
            Destroy(gameObject);
        }

    }

    public void Shoot(GameObject obj, GameObject player)                   ///  IWeapon ��� : start(), update()�� ������ �� public void Shoot() �����ϸ� ������ �������.
    {

        GameObject goBullet0 = Instantiate(obj);
        goBullet0.transform.position = player.transform.position;

        Rigidbody2D rigid = goBullet0.GetComponent<Rigidbody2D>();
        rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);///���ſ���� �ӵ��� ������ ���ӵ��� ������ ������, impulse ������ ���� ����� ���� �ʰڴ�

    }
}