using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  //¼±¾ð

public class SceneController : MonoBehaviour
{
    void Start()/// Start is called before the first frame update
    {
        
    }

    void Update()/// Update is called once per frame
    {
        if (Input.GetKey(KeyCode.Return)) { SceneManager.LoadScene("GameMainScene"); }

    }







}
