using UnityEngine;

public class EnemyHandDamage : MonoBehaviour
{

    public float damageAmount = 10f; // 데미지 양
    public float infectionAmount = 2f; // 감염도 증가량
    public float pushBackForce = 2f; // 밀어내는 힘의 정도
    public LayerMask InteractableLayer;
    public LayerMask NotInteractableLayer;
    public Enemy enemy;

    private void Start()
    {
        // Enemy 컴포넌트를 자동으로 찾아서 할당합니다.
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
        // 벽과 충돌 시
        else if (((1 << other.gameObject.layer) & InteractableLayer & NotInteractableLayer) != 0)
        {
            // 벽과의 충돌 감지 시 Enemy에 이동 중지 신호를 보냅니다.
            if (enemy != null)
            {
                enemy.StopMovementTemporary();
            }
        }
    }
}
