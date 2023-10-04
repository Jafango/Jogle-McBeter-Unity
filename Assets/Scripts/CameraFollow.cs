using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var vcam = GetComponent<CinemachineVirtualCamera>();
        vcam.LookAt = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
        vcam.Follow = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
    }
}
