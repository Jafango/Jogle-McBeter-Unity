using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    private float gapRange;
    public float speed;
    //[SerializeField] private float spottedRange = 15f;

    void Update()
    {
        gapRange = Vector2.Distance(transform.position, target.transform.position);

        Debug.Log(gapRange);
        if (gapRange > 15)
        {
            speed = 4;
        }
        else if (gapRange <= 15)
        {
            EnemyMove();
            speed = 5.5f;
        }
    }



    void EnemyMove()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
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
