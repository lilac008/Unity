using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                //선언
using UnityEngine.SceneManagement;   //선언
using System.IO;                     //선언



public class GameManager : MonoBehaviour
{
    public Transform[] spawnPoints;

    public GameObject[] goEnemies;
    public GameObject goPlayer;

    public float curEnemySpawnDelay;

    public Image[] imgLifes;

    public Text scoreText;
    public GameObject goGameOver;           //public Button

    public ObjectManager objManager;        

    public List<Spawn> spawnList;

    public string[] enemyNames = { "A", "B" };

    public class Spawn
    {
        public float delay; // 나타나는 시간
        public string type; // 적기 타입
        public int point; // spawnpoint 중 하나
    };

    public int spawnIdx = 0;
    public bool spawnEnd;

    public float nextEnemySpawnDelay;


    void Awake()
    {
        spawnList = new List<Spawn>();  //초기화
        ReadSpawnFile();
    }

    void ReadSpawnFile()
    {
        spawnList.Clear();
        spawnIdx = 0;       //초기화
        spawnEnd = false;   //초기화

        TextAsset textFile = Resources.Load("stage") as TextAsset;  //resource 안의 파일을 가지고 옴
        StringReader stringReader = new StringReader(textFile.text);

        while(stringReader != null)
        {
            string txtLineData = stringReader.ReadLine();
            Debug.Log(txtLineData);
            if (txtLineData == null)
                break;

            Spawn data = new Spawn();
            data.delay = float.Parse(txtLineData.Split(',')[0]);
            data.type = txtLineData.Split(',')[1];
            data.point = int.Parse(txtLineData.Split(',')[2]);

            spawnList.Add(data);
        }
        stringReader.Close();

        if (spawnList.Count > 0)
        {
            nextEnemySpawnDelay = spawnList[0].delay;
        }

        return;
    }

    private void Update()/// Update is called once per frame
    {
        //SpawnEnemy();
        //ReloadEnemy();

        //Player playerLogic = goPlayer.GetComponent<Player>();
        //scoreText.text = string.Format("{0:n0}", playerLogic.nScore);

        curEnemySpawnDelay += Time.deltaTime;
        if (curEnemySpawnDelay > nextEnemySpawnDelay && !spawnEnd)
        {
            SpawnEnemy();
            //maxEnemySpawnDelay = Random.Range(0.5f, 3f);
            curEnemySpawnDelay = 0;
        }

        Player playerLogic = goPlayer.GetComponent<Player>();
        scoreText.text = string.Format("{0:n0}", playerLogic.nScore);
    }

    void SpawnFlight() 
    {


    }

    void SpawnEnemy()/// 적 랜덤 스폰
    {
        ///7.18
        if (spawnList.Count <= 0)
            return;

        int enemyIdx = 0; ///초기화
        switch(spawnList[spawnIdx].type)
        {
            case "A":
                {
                    enemyIdx = 0;
                }
                break;
            case "B":
                {
                    enemyIdx = 1;
                }
                break;

        }
        ///int randPoint = Random.Range(0, 3);
        //string enemyName = enemyNames[enemyIdx];
        ///int randEnemyType = Random.Range(0, 2);

        /*
        if (curEnemySpawnDelay < maxEnemySpawnDelay)
            return;

        int randEnemyType = Random.Range(0, 2);
        int randPoint = Random.Range(0, 3);
        */

        ///GameObject createEnemy = Instantiate(goEnemies[randEnemyType], spawnPoints[randPoint].position, spawnPoints[randPoint].rotation); ///적만듬

        int enemyPoint = spawnList[spawnIdx].point;
        string enemyName = enemyNames[enemyIdx];
        GameObject createEnemy = objManager.MakeObject(enemyName);
        createEnemy.transform.position = spawnPoints[enemyPoint].position;

        Rigidbody2D rd = createEnemy.GetComponent<Rigidbody2D>();
        Enemy enemy = createEnemy.GetComponent<Enemy>();   ///enemy클래스를 가져와서 
        enemy.objManager = objManager;

        rd.velocity = new Vector2(0, enemy.speed * (-1)); ///rd.velocity = Vector2.down * enemy.speed; 
        enemy.goPlayer = goPlayer;

        ///maxEnemySpawnDelay = Random.Range(0.5f, 3f);
        ///curEnemySpawnDelay = 0; ///초기화

        spawnIdx++;
        if (spawnIdx == spawnList.Count)
        {
            spawnEnd = true;
            return;
        }

        nextEnemySpawnDelay = spawnList[spawnIdx].delay;

    }


    public void RespawnPlayer()
    {
        Invoke("AlivePlayer", 1.0f);
    }

    void AlivePlayer()
    {
        goPlayer.transform.position = Vector3.down * 3.5f;
        goPlayer.SetActive(true);

        Player playerLogic = goPlayer.GetComponent<Player>();
        playerLogic.isHit = false;
    }

    public void UpdateLifeIcon(int life)
    {
        for (int idx = 0; idx < 3; idx++)
        {
            imgLifes[idx].color = new Color(1, 1, 1, 0);
        }

        for (int idx = 0; idx < life; idx++)
        {
            imgLifes[idx].color = new Color(1, 1, 1, 1);
        }
    }

    public void GameOver()
    {
        goGameOver.SetActive(true);
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(0);              ///SceneManager선언, Build setting, 
    }


}
