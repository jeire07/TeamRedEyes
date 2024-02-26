using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float BaseDamage = 10f;
    private Player player;

    public float Damage
    {
        get { return BaseDamage; }
        set { BaseDamage = value; }
    }

    public void SetPlayer(Player player)
    {
        this.player = player;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && player != null)
        {
            float totalDamage = BaseDamage + player.GetCurrentAttack();
            // 적에게 데미지를 적용합니다.
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(totalDamage);
            }
        }
    }
}

