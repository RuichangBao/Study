using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform target;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(target.position); //每帧更新目标位
    }
}
