using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class MovingObject : MonoBehaviour    //상속
{
    public float moveTime = 0.1f;
    public LayerMask blockingLayer;                 //Layer - blockingLayer 

    private BoxCollider2D boxCollider;              //오브젝트 움직이는 함수 : translate(죽 날라감), addforce(가속도), Movetowards(지정한 위치까지만 날라감, 키보드 움직일때마다 몹도 정해진 위치까지만 움직임)를 사용  
    private Rigidbody2D rb2D;

    private float inverseMoveTime;
    private bool isMoving;


    protected virtual void Start()// Start is called before the first frame update
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();

        inverseMoveTime = 1f / moveTime;   // inverseMoveTimes 1/60, 한 프레임당 쪼갠다,


    }

    protected bool Move(int xDir, int yDir, out RaycastHit2D hit)     //Raycast(구체적), ignore Raycast, Linecast(hit안에)
    {
        Vector2 start = transform.position;

        Vector2 end = start + new Vector2(xDir, yDir);

        boxCollider.enabled = false;

        hit = Physics2D.Linecast(start, end, blockingLayer);

        boxCollider.enabled = true;

        if (hit.transform == null && !isMoving) //앞에 걸리는 게 있으면 false, 걸리는 게 없으면 가자.
        {
            StartCoroutine(SmoothMovement(end)); //StartCoroutine 한 프레임 뒤에 호출

            return true;
        }
        return false;


    }

    protected IEnumerator SmoothMovement(Vector3 end) //프레임을 부드럽게 연결?
    {
        isMoving = true;

        float sqrRemainingDistance = (transform.position - end).sqrMagnitude; //오브젝트간 거리 체크 : Vector3.Distance/magnitude/sqrMagnitude : 정확한 거리보다 거리간 비교용으로 사용, 특정거리보다 작거나 큰지 비교만
        while (sqrRemainingDistance > float.Epsilon)
        {
            Vector3 newPosition = Vector3.MoveTowards(rb2D.position, end, inverseMoveTime * Time.deltaTime);
            rb2D.MovePosition(newPosition);

            sqrRemainingDistance = (transform.position - end).sqrMagnitude;

            yield return null;
        }
                                     // RigidBody.MovePosition()과  transform.position의 차이점 (선생님 자료 참조)
        rb2D.MovePosition(end);      // rigidbody가 달린 object를 이동하는 방법 : transform.position, RigidBody.position, RigidBody.MovePosition() 
                                     // transform.position, RigidBody.position는 순간이동식으로 위치를 이동, 성능은 후자가 더 좋음
                                     // RigidBody.MovePosition()은 이동지점과 끝지점을 직선으로 연결한 경로를 매우 빠르게 이동한다. 중간에 다른 rigidbody가 있을경우 밀어내는등의 물리처리.

        isMoving = false;
    }

    protected virtual void AttemptMove<T>(int xDir, int yDir) where T : Component
    {
        RaycastHit2D hit;

        bool canMove = Move(xDir, yDir, out hit);

        if (hit.transform == null)
            return;

        T hitComponent = hit.transform.GetComponent<T>();

        if (!canMove && hitComponent != null)
        {
            OnCantMove(hitComponent);
        }

    }

    protected abstract void OnCantMove<T>(T component) where T : Component;




}
