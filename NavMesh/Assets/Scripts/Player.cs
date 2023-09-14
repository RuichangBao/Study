using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public Transform target;
    public Transform samplePos;
    private NavMeshAgent navMeshAgent;
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        if (NavMesh.SamplePosition(samplePos.position,out NavMeshHit hit,5,1))
        {
            Debug.LogError("找到最近的点");
            navMeshAgent.SetDestination(hit.position); 
        }
        else
        {
            Debug.LogError("未找到最近的点");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //navMeshAgent.SetDestination(target.position); //每帧更新目标位
    }
}
