using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMaker : MonoBehaviour
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

        if (delta > interval)  ///1�ʸ��� ����
        {
            delta = 0;

            GameObject bomb = Instantiate(bombPrefab);
            int x = Random.Range(-8, 9);  ///ȭ����� ���� -8~ ���� -8
            bomb.transform.position = new Vector2(x, 5);    //x��, y��
        }




    }
}