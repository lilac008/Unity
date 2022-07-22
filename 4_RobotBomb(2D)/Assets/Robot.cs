using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    Rigidbody2D robotRD;
    public float walkSpeed = 10.0f;
    public float jumpSpeed = 10.0f;

    Animator ani;           /// �ִϸ��̼� ����
    private bool isMoving;  /// int/bool

    void Start()
    {
        robotRD = GetComponent<Rigidbody2D>();  ///�ʱ�ȭ
        ani = GetComponent<Animator>();         ///�ʱ�ȭ
    }

    void Update()
    {
        isMoving = false;

        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x >= -8.0f)    /// &&���� : ĳ���Ͱ� ȭ�鿡�� ����� �� ����
        {
            isMoving = true;

            ani.SetBool("isWalking", true);                      ///Walk Animation ����


            transform.Translate(Vector2.left * walkSpeed * Time.deltaTime);    /// �� �̵�
            transform.localScale = new Vector2(-2.0f, 2.0f);                   /// �ڷε���
        }


        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x <= 8.0f)
        {
            isMoving = true;

            ani.SetBool("isWalking", true);                      ///Walk Animation ����


            transform.Translate(Vector2.right * walkSpeed * Time.deltaTime);   /// �� �̵�  
            transform.localScale = new Vector2(+2.0f, 2.0f);                   /// �ڷε���

        }


        if (Input.GetKeyDown(KeyCode.Space))                    ///getkeydown 
        {
            ani.SetTrigger("jumpTrigger");                      ///Jump Animation ����

            robotRD.AddForce(transform.up * jumpSpeed, ForceMode2D.Impulse); ///Jump
        }


        if (!isMoving) 
        {
            ani.SetBool("isWalking", false);                   ///walk Animation ����
        }





    }
}