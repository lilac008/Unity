using System.Collections;
using System.Collections.Generic;
using UnityEngine;      
using System;                           // serializable 직렬화
using Random = UnityEngine.Random;      // using System; 을 선언하면 랜덤함수를 못쓰므로

//BoardManager : 화면에 나오는 오브젝트 생성
//GameManager  : 로직이 필요한 움직이는 몹 리스트 움직임 처리, (나타마자 움직이는 건 자체스크립트로 처리)



public class BoardManager : MonoBehaviour
{

    [Serializable]
    public class Count 
    {
        public int minimum;
        public int maximum;

        public Count(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }

    public int colums = 8;  //8 * 8 = 64개의 판
    public int rows = 8;
    
    public Count wallCount = new Count(5, 9); //new Count(colums, rows);  최소 5~9개
    public Count foodCount = new Count(1, 5); //new Count(colums, rows);  최소 1~5개

    public GameObject exit;
    public GameObject[] floorTiles;
    public GameObject[] wallTiles;  //
    public GameObject[] foodTiles;  //
    public GameObject[] enemyTiles; //
    public GameObject[] outerWallTiles;

    private Transform boardHolder;
    private List<Vector3> gridPosition = new List<Vector3> ();  //8 * 8 = 64개의 판에 정보를 담는 리스트

    void InitailiseList() 
    {
        gridPosition.Clear();

        for (int x = 1; x < colums - 1; x++) 
        {
            for (int y = 1; y < rows - 1; y++) 
            {
                gridPosition.Add (new Vector3 (x, y, 0f));  
            }
        }
    }

    void BoardSetup() 
    {
        boardHolder = new GameObject("Board").transform;    //게임오브젝트 Board를 만들면 항상 transform이 따라온다

        for (int x = -1;  x < colums + 1;  x++)
        {
            for (int y = -1; y < rows + 1; y++) 
            {
                GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];  //floor1~8까지 타일을 랜덤하게 배열

                if (x == -1 || x == colums || y == -1 || y == rows)
                    toInstantiate = outerWallTiles[Random.Range(0, wallTiles.Length)];  //outerWall1~3까지 타일을 랜덤하게 배열

                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0), Quaternion.identity);
                instance.transform.SetParent(boardHolder);



            }

        }
    }

    Vector3 RandomPosition() //랜덤하게 올려놓는다
    {
        Vector3 randomPosition = Vector3.zero;

        int randomIdx = Random.Range(0, gridPosition.Count);

        randomPosition = gridPosition[randomIdx];

        gridPosition.RemoveAt(randomIdx);

        return randomPosition;
    }

    void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum) 
    {
        int objectCount = Random.Range(minimum, maximum+1);

        for (int i = 0; i < objectCount; i++) 
        {
            Vector3 randomPosition = RandomPosition();

            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];

            Instantiate(tileChoice, randomPosition, Quaternion.identity);
        }
        
    }

    public void SetupScene(int level) //배경
    {
        BoardSetup();
        InitailiseList();
        LayoutObjectAtRandom(wallTiles, wallCount.minimum, wallCount.maximum);//public Count wallCount = new Count(5, 9); //new Count(colums, rows);  최소 5~9개
        LayoutObjectAtRandom(foodTiles, foodCount.minimum, foodCount.maximum);//public Count foodCount = new Count(1, 5); //new Count(colums, rows);  최소 1~5개

        int enemyCount = (int)Mathf.Log(level, 2f); //레벨이 따라서 enemycount가 

        
        LayoutObjectAtRandom(enemyTiles, enemyCount, enemyCount);

        Instantiate(exit, new Vector3(colums-1, rows-1, 0f), Quaternion.identity);




    }



    void Start()/// Start is called before the first frame update
    {

    }

    /// Update is called once per frame
    void Update()
    {
        
    }
}
