using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  //선언

public class sceneManager : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        SingletoneManager.Instance.nScore = 777777;   ///SingletoneManager 스크립트에서 호출
        return;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Jump") == 1)     ///InputManager에 입력된 jump키(space) 누르면
        {
            
            SceneManager.LoadScene(1);       ///방법1. BuildSetting에서 Scene index 번호
            ///SceneManager.LoadScene("End");   ///방법2. BuildSetting에서 불러올 Scene이름
        }

        
    }
}
