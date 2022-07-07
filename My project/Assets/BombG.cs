using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombG : MonoBehaviour
{
    public GameObject bombPrefab;
    public float interval = 1.0f;

    float delta = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;

        if (delta > interval)
        {
            delta = 0;

            GameObject bomb = Instantiate(bombPrefab);
            int x = Random.Range(-8, 9);  ///화면범위 좌측 -8~ 우측 -8
            bomb.transform.position = new Vector2(x, 5);    //x축, y축
        }
    }
}
