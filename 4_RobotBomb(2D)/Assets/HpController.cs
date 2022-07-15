using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               // 선언
using UnityEngine.SceneManagement;  // 선언

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

        if (hp.GetComponent<Image>().fillAmount <= 0) ///==0이면  
        {
            ///Death 애니메이션 실행


            ///장면 전환
            SceneManager.LoadScene("GameOverScene");
        }

    }

}
