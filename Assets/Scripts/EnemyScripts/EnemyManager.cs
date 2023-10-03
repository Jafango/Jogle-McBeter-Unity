using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager _instance;

    [System.Serializable]
    public enum State { FollowTarget, Attack, Retreat }
    public State currentState = State.FollowTarget;


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }


    void Update()
    {
        switch (currentState)
        {
            case State.FollowTarget:
                break;
            case State.Attack:
                Debug.Log("Attack");
                break;
            case State.Retreat:
                Debug.Log("Runaway");
                break;
        }
    }

}
