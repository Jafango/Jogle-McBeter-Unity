using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private Transform pointC;
    [SerializeField] private Transform pointD;
    private Transform currentPoint;

    private float gapRange;
    public float speed;
    //[SerializeField] private float spottedRange = 15f;

    void Update()
    {
        gapRange = Vector2.Distance(transform.position, target.transform.position);

        Debug.Log(gapRange);

        if (gapRange > 5)
        {
            speed = 4;
            EnemyMovePoint(pointA);
        }
        else if (gapRange < 5)
        {
            EnemyMove();
            speed = 5.5f;
        }
    }

    void EnemyMove()
    {
        gapRange = Vector2.Distance(transform.position, target.transform.position);

        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }


    void EnemyMovePoint(Transform firstTarget)
    {
        transform.position = Vector2.MoveTowards(transform.position, firstTarget.transform.position, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            speed = 0;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        speed = 3;
    }
}
