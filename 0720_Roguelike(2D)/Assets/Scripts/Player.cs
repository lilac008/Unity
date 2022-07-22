using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //

public class Player : MovingObject
{
    public int pointsPerFood = 10;
    public int pointsPerSoda = 20;
    public int wallDamage = 1;

    private Animator animator;
    private int food;

    SpriteRenderer spriteRenderer;

    public AudioClip moveSound1;
    public AudioClip moveSound2;
    public AudioClip eatSound1;
    public AudioClip eatSound2;
    public AudioClip drinkSound1;
    public AudioClip drinkSound2;
    public AudioClip gameOverSound;

    public float restartLevelDelay = 1.0f;


    protected override void Start()// Start is called before the first frame update
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        animator = GetComponent<Animator>();
        food = GameManager.instance.playerFoodPoints;

        base.Start();
        
    }

    private void OnDisable()
    {
        GameManager.instance.playerFoodPoints = food;   //게임매니저에 푸드값을 넘겨줌?

    }


    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.playersTurn) return;

        int horizontal = 0;
        int vertical = 0;

        horizontal = (int)(Input.GetAxisRaw("Horizontal"));
        vertical = (int)(Input.GetAxisRaw("Vertical"));

        if (horizontal != 0)
            vertical = 0;

        if (horizontal != 0 || vertical != 0) 
        {
            if (horizontal == 1)      //캐릭터 방향 전환
            {
                spriteRenderer.flipX = false;
            }
            else if (horizontal == -1) //캐릭터 방향 전환
            {
                spriteRenderer.flipX = true;
            }
            AttemptMove<Wall>(horizontal, vertical);
        }

        
    }

    protected override void AttemptMove<T>(int xDir, int yDir)
    {
        food--;

        base.AttemptMove<T>(xDir, yDir);

        RaycastHit2D hit;

        Move(xDir, yDir, out hit);

        if (Move(xDir, yDir, out hit)) 
        {
            SoundManager.instance.RandomizeSfx(moveSound1, moveSound2);
        }


        CheckIfGameOver();

        GameManager.instance.playersTurn = false;
    }


    protected override void OnCantMove<T>(T component)
    {
        Wall hitWall = component as Wall;

        hitWall.DamageWall(wallDamage);

        animator.SetTrigger("playerAttack");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Exit")
        {
            Invoke("Restart", restartLevelDelay);
            enabled = false;
        }
        else if (collision.tag == "Food")
        {
            food += pointsPerFood;

            SoundManager.instance.RandomizeSfx(eatSound1, eatSound2);//
            collision.gameObject.SetActive(false);  //SetActive : disable 시킴 보이지도 작용시키지도 않음

        }
        else if (collision.tag == "Soda")
        {
            food += pointsPerSoda;

            SoundManager.instance.RandomizeSfx(drinkSound1, drinkSound2);//
            collision.gameObject.SetActive(false);

        }
    }

    private void Restart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }


    private void CheckIfGameOver()
    {
        if (food <= 0)
        {
            GameManager.instance.GameOver();

            SoundManager.instance.PlaySingle(gameOverSound);
            SoundManager.instance.musicSource.Stop();

        }
    }


    public void LoseFood(int loss) 
    {
        animator.SetTrigger("PlayerHit");

        food -= loss;

        CheckIfGameOver();
    }

    



}
