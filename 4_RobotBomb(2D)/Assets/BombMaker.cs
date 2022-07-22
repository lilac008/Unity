using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMaker : MonoBehaviour
{
    public GameObject bombPrefab;
    public float interval = 1.0f;

    float delta = 0;


    void Start()/// Start is called before the first frame update
    {

    }

    void Update()/// Update is called once per frame
    {
        delta += Time.deltaTime;

        if (delta > interval)                               ///1초마다 실행
        {
            delta = 0;

            GameObject bomb = Instantiate(bombPrefab);
            int x = Random.Range(-8, 9);                     ///화면범위 좌측 -8~ 우측 -8
            bomb.transform.position = new Vector2(x, 5);     ///x축, y축
        }




    }
}
