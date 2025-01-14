﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericWaveEnemy<T>
{
    public T enemy;
    public int amount;
    public float interval;
    public bool done;
    public float delay;
    private int count;
    private float timer;

    private bool readyToSpawn = true;
    public bool AttemptSpawn()
    {
        if (readyToSpawn)
        {
            count++;
            if (count == amount)
                done = true;
            readyToSpawn = false;
            return true;
        } else
        {
            timer += Time.deltaTime;
            if (timer > interval)
            {
                readyToSpawn = true;
                timer = 0;
            }
        }

        return false;

    }
}

public abstract class GenericWaveEnemies<T, U> where T : GenericWaveEnemy<U>
{
    [SerializeField]
    public List<T> WaveEnemies;
}

[System.Serializable]
public class WaveEnemy : GenericWaveEnemy<GameObject>
{
    
}

[System.Serializable]
public class WaveEnemies : GenericWaveEnemies<WaveEnemy, GameObject> { }