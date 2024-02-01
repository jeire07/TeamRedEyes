using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerHealthState : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int health;
    public event Action OnDie;

    public bool IsDead => health == 0;

    public void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (health == 0) return;
        health = math.max(health-damage, 0);

        if (health == 0)
            OnDie?.Invoke();

        Debug.Log("health");
    }

}
