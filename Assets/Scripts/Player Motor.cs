using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMotor : MonoBehaviour
{
    //NavMeshAgent를 통한 이동 또는 변화를 관리.
    NavMeshAgent agent;
    Transform target;

    public void MoveToTarget(Vector3 position)
    {
        agent.SetDestination(position);
    }

}
