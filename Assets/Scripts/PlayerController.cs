using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour
{
      // 사용자의 인풋을 시스템에 적용하는 부분
    Camera cam;
    NavMeshAgent agent;
    Animator animator;
   

    PlayerMotor motor;
    CharacterCombat combat;

    public LayerMask movementMask;
    public LayerMask interactionMask;
    public Interactable focus;

    private void Awake() 
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();

        motor = GetComponent<PlayerMotor>();
    }
 
    private void Update()
    {
        float agentVelocity = agent.velocity.sqrMagnitude;
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, movementMask))
            {
                // agent.SetDestination(hit.point);
                motor.MoveToTarget(hit.point);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, interactionMask))
            {
                focus = hit.collider.GetComponent<Interactable>();
                SetFocus(focus);
            }
        }

        if (!agent.pathPending)
        {
            if ( agent.remainingDistance <= agent.stoppingDistance)
            {
                animator.SetFloat("Walk", 0.0f);
            }
        }

        animator.SetFloat("Walk", agentVelocity);
    }

    void SetFocus(Interactable newFocus)
    {
        if(focus)
        if (focus != newFocus)
                {
                    motor.MoveToTarget(focus.guideTransform.position);
                }
    }

    void DeFocus()
    {

    }
}
