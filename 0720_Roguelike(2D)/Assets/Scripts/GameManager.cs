using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//BoardManager : 화면에 나오는 오브젝트 생성
//GameManager  : 로직이 필요한 움직이는 몹 리스트 움직임 처리, (나타마자 움직이는 건 자체스크립트로 처리)


public class GameManager : MonoBehaviour
{
    public float levelStartDelay = 2f;  //게임 시작되는 시간?
    public float turnDelay = 0.1f;      //캐릭터가 움직일때마다 몹 움직이게하는 딜레이값
    public int playerFoodPoints = 100;  //음식값만큼 캐릭터가 움직일 수 있게함
    public static GameManager instance = null; //싱글톤으로 음식 섭취시 정보가 넘어감

    [HideInInspector] public bool playersTurn = true;   //player가 움직였는지 아닌지에 대한 판단

    private BoardManager boardManager;
    private int level = 1;
    private List<Enemy> enemies; //BoardManager enemy 생성 -> GameManager에서 움직임 관리
    private bool enemiesMoving;

    private void Awake()    //싱글톤?
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        enemies = new List<Enemy>(); //초기화

        boardManager = GetComponent<BoardManager>();    //게임매니저에 보드매니저라는 컴포넌트가짐

        InitGame(); //초기화

    }

    void InitGame() //레벨이 올라갈때마다 초기화
    {
        enemies.Clear();
        boardManager.SetupScene(level);

    }

    public void AddEnemyToList(Enemy script) 
    {
        enemies.Add(script);
        
    }





    // Update is called once per frame
    void Update()
    {
        if (playersTurn || enemiesMoving)
            return;

        StartCoroutine(MoveEnemies());

    }


    IEnumerator MoveEnemies() 
    {
        enemiesMoving = true;

        yield return new WaitForSeconds(turnDelay);

        if (enemies.Count == 0) 
        {
            yield return new WaitForSeconds(turnDelay);
        }

        for (int i =0; i < enemies.Count; i++) 
        {
            enemies[i].MoveEnemy();
            yield return new WaitForSeconds(enemies[i].moveTime);
        }

        playersTurn = false;
        enemiesMoving = false;
    }

    public void GameOver()
    {
        enabled = false;
    }

}
