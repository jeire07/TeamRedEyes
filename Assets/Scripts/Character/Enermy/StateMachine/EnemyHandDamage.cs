using UnityEngine;

public class EnemyHandDamage : MonoBehaviour
{
    public float damageAmount = 10f; // 데미지 양
    public float infectionAmount = 2f; // 감염도 증가량
    public float pushBackForce = 2f; // 밀어내는 힘의 정도

    private void OnTriggerEnter(Collider other)
    {
        // 플레이어와 충돌 시
        if (other.CompareTag("Player"))
        {
            PlayerCondition playerCondition = other.GetComponent<PlayerCondition>();
            if (playerCondition != null)
            {
                // 체력감소 감염도증가 
                playerCondition.Health.Add(-damageAmount);
                playerCondition.Infection.Add(infectionAmount);

                // 밀어내기 효과
                Vector3 pushDirection = other.transform.position - transform.position;
                pushDirection.y = 0; // 수직 방향 힘 제외
                Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();
                if (playerRigidbody != null)
                {
                    playerRigidbody.AddForce(pushDirection.normalized * pushBackForce, ForceMode.Impulse);
                }
            }
        }
    }
}
