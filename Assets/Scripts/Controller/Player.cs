using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Singleton
    public static Player instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public CharacterStat Stat;
    public CharacterCombat combat;

    private void OnEnable()
    {
        Stat.OnHPZero += Die;
    }

    private void OnDisable()
    {
        Stat.OnHPZero -= Die;
    }

    void Die()
    {
        Debug.Log("플레이어 캐릭터가 죽었습니다.");
    }
}