using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Player",menuName ="Character/Player")]

public class PlayerSO : ScriptableObject
{
    [field: SerializeField] public PlayerGroundData GroundData {  get; private set; }
    [field: SerializeField] public PlayerAirData AirData { get; private set; }
    [field: SerializeField] public PlayerAttackData AttackData { get; private set;}
}
