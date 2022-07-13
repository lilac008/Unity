using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public GameObject objects;
    public TextMesh scoreText;


    void Start()/// Start is called before the first frame update
    {
        ///InvokeRepeating("CreateObjects", 1, 2);  ///객체가 사라져서 비활성화시에도 계속 호출?

        ///StartCoroutine("CreateObjects");
        ///StartCoroutine(MyCoroutine(2));
        ///StartCoroutine(RealCoroutine(2));

    }

    void Update() /// Update is called once per frame
    {

    }


    IEnumerator MyCoroutine(int num)
    {

        //Time.deltaTime - 프레임이 완료 초당 20fps 6발 빠름  deltatime 동일한 속도를 만들어준다?
        //               -               초당 10fps 3발 느림
        
        ///yield return null;
        ///yield return new WaitForFixedUpdate();
        ///yield return new WaitForSeconds(2.0f);       ///컴퓨터시간 2초 기다렸다가 실행
        
        ///Instantiate(objects, new Vector3(7.5f,Random.Range(-2f,2.1f),0), Quaternion.identity);

        while (true) 
        {
            yield return new WaitForSeconds(1.0f);
            Instantiate(objects, new Vector3(7.5f, Random.Range(-2f, 2.1f), 0), Quaternion.identity);
        }
    }


    IEnumerator RealCoroutine(int num)
    {
        //yield return new WaitForSeconds(2.0f);       ///2초 기다렸다가 실행       yield return new WaitForSecondsRealtime(2.0f);     ///실제시간 2초
        
        yield return new WaitForEndOfFrame();
        
        Instantiate(objects, new Vector3(7.5f, Random.Range(-2f, 2.1f), 0), Quaternion.identity);
    }



    public int Score
    {
        set
        {
            score = value;
            scoreText.text = Score.ToString();
        }
        get 
        { return score; }
    }


    void CreateObjects()
    {
        Instantiate(objects, new Vector3(7.5f, Random.Range(-2f, 2.1f), 0), Quaternion.identity);
    }




}
