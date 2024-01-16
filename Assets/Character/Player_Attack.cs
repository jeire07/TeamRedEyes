using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Player_Attack : MonoBehaviour
{
    public float attackCooldown = 0.5f; // 쿨타임 시간
    private bool isCooldown = false;     // 쿨타임 활성화 여부

    public void OnAttack(InputAction.CallbackContext context)
    {
        // Attack 액션
        if (context.performed && !isCooldown)
        {
            Debug.Log("Attack!");
            StartCoroutine(AttackCooldown());
        }
    }

    private IEnumerator AttackCooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(attackCooldown);
        isCooldown = false;
    }
}

