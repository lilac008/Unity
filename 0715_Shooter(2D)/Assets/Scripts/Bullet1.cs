using System.Collections;
using System.Collections.Generic;
using UnityEngine;    ///  ���� MonoBehaviour�� ������� ���� ��� �� ������ ���ܵȴ�.


public interface IWeapon 
{
    void Shoot(GameObject obj, GameObject player);
}




public class Bullet1 : MonoBehaviour, IWeapon    /// 2�� �Ѿ� skript  /  IWeapon ��� : start(), update()�� ������ �� public void Shoot() �����ϸ� ������ �������.
{

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