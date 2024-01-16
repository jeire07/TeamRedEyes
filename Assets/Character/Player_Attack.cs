using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Player_Attack : MonoBehaviour
{
    public float attackCooldown = 0.5f; // ��Ÿ�� �ð�
    private bool isCooldown = false;     // ��Ÿ�� Ȱ��ȭ ����

    public void OnAttack(InputAction.CallbackContext context)
    {
        // Attack �׼�
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

