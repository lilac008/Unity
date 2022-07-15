using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //����


public class GameManager : MonoBehaviour
{
    public Transform[] spawnPoints;

    public GameObject goEnemy;
    public GameObject goPlayer;

    public float curEnemySpawnDelay;
    public float maxEnemySpawnDelay;

    public Image[] imgLifes;


    void Start()/// Start is called before the first frame update
    {
        
    }

    void Update()/// Update is called once per frame
    {
        SpawnEnemy();
        ReloadEnemy();
        
    }


    void ReloadEnemy() 
    {
        curEnemySpawnDelay += Time.deltaTime;
    }


    void SpawnEnemy() 
    {
        if (curEnemySpawnDelay < maxEnemySpawnDelay)
            return;

        int randPoint = Random.Range(0, 3);
        GameObject createEnemy = Instantiate(goEnemy, spawnPoints[randPoint].position, spawnPoints[randPoint].rotation);

        Rigidbody2D rd = createEnemy.GetComponent<Rigidbody2D>();
        Enemy enemy = createEnemy.GetComponent<Enemy>();

        rd.velocity = new Vector2(0, enemy.speed * (-1));  ///rd.velocity = Vector2.down * enemy.speed; 
        enemy.goPlayer = goPlayer;

        maxEnemySpawnDelay = Random.Range(0.5f, 3f);
        curEnemySpawnDelay = 0;     ///�ʱ�ȭ
    }

    public void RespawnPlayer() ///player���� ȣ���ҰŶ� public
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

    public void GameOver() 
    { }

    public void UpdateLifeIcon(int life) 
    {
        for (int idx = 0; idx < 3; idx++) 
        {
            imgLifes[idx].color = new Color(1, 1, 1, 0);
        }

        for (int idx = 0; idx < life; idx++) 
        {
            imgLifes[idx].color = new Color(1,1,1,1);
        }
    }
}