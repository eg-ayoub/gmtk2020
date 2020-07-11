﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LalaHitScanner : MonoBehaviour
{
    private bool _ready = true;

    private HashSet<GameObject> enemies;

    public void StartHits()
    {
        _ready = false;
        enemies = new HashSet<GameObject>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!_ready && other.CompareTag("LalaEnemy"))
        {
            Debug.Log("1 hit");
            enemies.Add(other.gameObject);
        }
    }

    public HashSet<GameObject> EndHits()
    {
        _ready = true;
        return enemies;
    }
}
