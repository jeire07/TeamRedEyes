using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float BaseDamage = 10f;
    private Player player;
    public bool isAttacking = false;

    public float Damage
    {
        get { return BaseDamage; }
        set { BaseDamage = value; }
    }

    public void SetPlayer(Player player)
    {
        this.player = player;
    }

    public void ActivateAttack(bool isActive)
    {
        isAttacking = isActive;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && player != null && isAttacking) // isAttacking 조건 추가
        {
            float totalDamage = BaseDamage + player.GetCurrentAttack();
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(totalDamage);
                Debug.Log("111");
            }
        }
    }
}

