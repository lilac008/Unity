using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endscene : MonoBehaviour
{
    public TextMesh txtResult;


    // Start is called before the first frame update
    void Start()
    {
        int nScore = SingletoneManager.Instance.GetScore();
        //txtResult = nScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
