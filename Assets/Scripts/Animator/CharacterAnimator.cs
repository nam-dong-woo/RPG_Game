using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{
    // 캐릭터들의 애니메이터 파라미터를 조절하는 부분.

    CharacterCombat combat;
    Animator animator;
    NavMeshAgent agent;

    private void Awake() 
    {
        combat = GetComponent<CharacterCombat>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        combat.OnAttack += OnAttack;
        combat.OnHitted += OnHitted;
        combat.OnDie += OnDie;        
    }

    private void Update() 
    {
        animator.SetFloat("Walk", agent.velocity.magnitude);
    }
    
    void OnAttack()
    {
        animator.SetTrigger("Attack");
    }

    void OnHitted()
    {
        animator.SetTrigger("Hitted");

    }

    void OnDie()
    {
        animator.SetTrigger("Die");

    }

    private void OnDisable()
    {
        combat.OnAttack -= OnAttack;
        combat.OnHitted -= OnHitted;
        combat.OnDie -= OnDie;        
    }
}
