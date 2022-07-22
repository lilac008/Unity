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

    public void Shoot(GameObject obj, GameObject player)                   ///  IWeapon 상속 : start(), update()를 삭제한 후 public void Shoot() 정의하면 빗금이 사라진다.
    {

        GameObject goBullet0 = Instantiate(obj);
        goBullet0.transform.position = player.transform.position;

        Rigidbody2D rigid = goBullet0.GetComponent<Rigidbody2D>();
        rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);///무거울수록 속도가 늦지만 가속도가 붙으면 빠른데, impulse 질량에 대한 계산을 하지 않겠다

    }
}
