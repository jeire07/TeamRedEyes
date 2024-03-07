using UnityEngine;

public class EnemyHandDamage : MonoBehaviour
{

    public float damageAmount = 10f; // ������ ��
    public float infectionAmount = 2f; // ������ ������
    public float pushBackForce = 2f; // �о�� ���� ����
    public LayerMask InteractableLayer;
    public LayerMask NotInteractableLayer;
    public Enemy enemy;

    private void Start()
    {
        // Enemy ������Ʈ�� �ڵ����� ã�Ƽ� �Ҵ��մϴ�.
        enemy = GetComponentInParent<Enemy>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerCondition playerCondition = other.GetComponent<PlayerCondition>();
            if (playerCondition != null)
            {
                playerCondition.statData.Conditions[(int)ConditionType.Health].Add(-damageAmount);
                playerCondition.statData.Conditions[(int)ConditionType.Infection].Add(infectionAmount);

                Vector3 pushDirection = other.transform.position - transform.position;
                pushDirection.y = 0;
                Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();
                if (playerRigidbody != null)
                {
                    playerRigidbody.AddForce(pushDirection.normalized * pushBackForce, ForceMode.Impulse);
                }
            }
        }
        // ���� �浹 ��
        else if (((1 << other.gameObject.layer) & InteractableLayer & NotInteractableLayer) != 0)
        {
            // ������ �浹 ���� �� Enemy�� �̵� ���� ��ȣ�� �����ϴ�.
            if (enemy != null)
            {
                enemy.StopMovementTemporary();
            }
        }
    }
}
