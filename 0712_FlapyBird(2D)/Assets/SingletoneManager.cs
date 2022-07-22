using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletoneManager : MonoBehaviour
{
    public static SingletoneManager instance = null;
    public int nScore = 0;


    private void Awake() 
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else 
        { 
            Destroy(this.gameObject); 
        }
    }

    public static SingletoneManager Instance 
    { 
        get 
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }


    public int GetScore() 
    {
        return nScore;
        
    }

    public void SetScore(int num) 
    {
        nScore = num;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
