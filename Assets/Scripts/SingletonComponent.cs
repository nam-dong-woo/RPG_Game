using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonComponent : MonoBehaviour
{
    private static SingletonComponent instance;

    public static SingletonComponent Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindAnyObjectByType<SingletonComponent>();
                if (obj != null)
                {
                    instance = obj;
                }
                else
                {
                    var newobj = new GameObject().AddComponent<SingletonComponent>();
                    instance = newobj;
                }                
            }
            return instance;
        }
    }
}
