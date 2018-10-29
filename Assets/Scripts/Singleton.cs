using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    static T instance;

    public DateTime BirthTime { private set; get; }

    public static T Instance
    {
        get
        {
            if (instance != null)
                return instance;

            Initialize();

            return instance;
        }
    }

    private void Awake()
    {
        BirthTime = DateTime.Now;
    }

    public static void Initialize()
    {
        Singleton<T>[] instances = FindObjectsOfType<T>() as Singleton<T>[];
        if (instances != null)
        {
            DateTime min = instances.Min(x => x.BirthTime);

            for (int i = 0; i < instances.Length; i++)
            {
                if (instances[i].BirthTime != min)
                    Destroy(instances[i].gameObject);
            }

            instance = instances.FirstOrDefault() as T;
        }
    }
}