using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               // ����
using UnityEngine.SceneManagement;  // ����

public class HpController : MonoBehaviour
{
    GameObject hp;

    void Start() /// Start is called before the first frame update
    {
        hp = GameObject.Find("HpImage");
    }

    void Update() /// Update is called once per frame
    {
        
    }

    public void HpControl() 
    {
        hp.GetComponent<Image>().fillAmount -= 0.1f;

        if (hp.GetComponent<Image>().fillAmount <= 0) ///==0�̸�  
        {
            ///Death �ִϸ��̼� ����


            ///��� ��ȯ
            SceneManager.LoadScene("GameOverScene");
        }

    }

}