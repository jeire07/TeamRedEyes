using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "Enemy/Enemy")]
public class EnemySO : ScriptableObject
{
    [field: SerializeField] public float MaxHealth = 100f;
    [field: SerializeField] public float PlayerChasingRange { get; private set; } = 10f;
    [field: SerializeField] public float AttackRange { get; private set; } = 3f;
    [field: SerializeField] public int Exp { get; private set; } = 5;
    [field: SerializeField][field: Range(0f, 3f)] public float ForceTransitionTime { get; private set; }
    [field: SerializeField][field: Range(-10f, 10f)] public float Force {  get; private set; }
    [field: SerializeField][field : Range(0f, 1f)] public float Dealing_Start_TransitionTime { get; private set; }
    [field: SerializeField][field: Range(0f, 1f)] public float Dealing_End_TransitionTime { get; private set; }
    [field: SerializeField] public EnemyGroundData EnemyGroundData {  get; private set; }
    [field: SerializeField] public EnemyAttackData EnemyAttackData { get; private set;}
}
