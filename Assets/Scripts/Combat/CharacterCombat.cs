using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    public event Action OnIdle;
    public event Action OnAttack;
    public event Action OnHitted;
    public event Action OnDie;

    #region COOLTIME
    const float cooltime = 1f;
    //public float attackSpeed = 1f;
    public float attackCooltime = 0f;
    //public float attackDelay = 1f;
    float lastAttackTime;
    #endregion

    public bool isInCombat = false;

    CharacterStat myStat;

    private void Awake()
    {
        myStat = GetComponent<CharacterStat>();
    }

    public void Idle()
    {
        OnIdle?.Invoke();
    }

    public void Attack(CharacterStat enemyStat)
    {
        if (attackCooltime <= 0f)
        {
            
            enemyStat.GetComponent<CharacterCombat>().Hitted();
            StartCoroutine(GetDamage(enemyStat, 0.5f));

            if (OnAttack != null)
                OnAttack();
            isInCombat = true;
            attackCooltime = cooltime;
            lastAttackTime = Time.time;
        }
    }

    IEnumerator GetDamage(CharacterStat enemyStat, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (enemyStat != null)
            enemyStat.Hitted(myStat.power);
        else
            Idle();
    }

    public void Hitted()
    {
        OnHitted?.Invoke();
    }

    private void Update()
    {
        attackCooltime -= Time.deltaTime;
        if (Time.time - lastAttackTime > cooltime)
        {
            isInCombat = false;
        }
    }

}
