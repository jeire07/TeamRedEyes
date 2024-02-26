using UnityEngine;

public class EnemyHandDamage : MonoBehaviour
{
    public float damageAmount = 10f; // ������ ��
    public float infectionAmount = 2f; // ������ ������
    public float pushBackForce = 2f; // �о�� ���� ����

    private void OnTriggerEnter(Collider other)
    {
        // �÷��̾�� �浹 ��
        if (other.CompareTag("Player"))
        {
            PlayerCondition playerCondition = other.GetComponent<PlayerCondition>();
            if (playerCondition != null)
            {
                // ü�°��� ���������� 
                playerCondition.Health.Add(-damageAmount);
                playerCondition.Infection.Add(infectionAmount);

                // �о�� ȿ��
                Vector3 pushDirection = other.transform.position - transform.position;
                pushDirection.y = 0; // ���� ���� �� ����
                Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();
                if (playerRigidbody != null)
                {
                    playerRigidbody.AddForce(pushDirection.normalized * pushBackForce, ForceMode.Impulse);
                }
            }
        }
    }
}
