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
        if (other.CompareTag("Enemy") && player != null) // player 참조를 직접 사용
        {
            float totalDamage = BaseDamage + player.GetCurrentAttack();
        }
    }
}

