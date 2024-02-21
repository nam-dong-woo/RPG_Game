using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat : MonoBehaviour
{
    public event Action OnHPZero;
    int currentHP;
    public int maxHP;

    public int power = 10;

    private void OnEnable()
    {
        currentHP = maxHP;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Hitted(10);
        }
    }

    public void Hitted(int damage)
    {
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHP -= damage;

        if (currentHP <= 0)
        {
            OnHPZero?.Invoke();
        }
    }
    //void Die()
    //{

    //}
}
