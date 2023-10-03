using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private GameObject detectionZone;
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
        }
        else if (gapRange < 5)
        {
            EnemyMove();
            speed = 5.5f;
        }
    }

    void EnemyMove()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);


        float AngleTarget = Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x);
        float AngleRotate = (180 / Mathf.PI) * AngleTarget;

        this.transform.rotation = Quaternion.Euler(0, 0, AngleRotate);
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
