using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[Serializable]

public class EnemyAttackInfoData
{
    [field: SerializeField] public string AttackName { get; private set; }

    [field: SerializeField][field: Range(0f, 3f)] public float ForceTransitionTime { get; private set; }

    [field: SerializeField][field: Range(-10f, 10f)] public float Force { get; private set; }

    [field: SerializeField] public int Damage { get; private set; }
}

[Serializable]

public class EnemyAttackData
{
    [field: SerializeField] public List<EnemyAttackInfoData> EnemyAttackInfoData { get; private set; }

    public int GetEnemyAttackInfoCount() { return EnemyAttackInfoData.Count; }

    public EnemyAttackInfoData GetEnemyAttackInfo(int index) { return EnemyAttackInfoData[index]; }
}
