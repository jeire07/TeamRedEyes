using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public class PlayerAirData
{
    [field: Header("JumpData")]

    [field: SerializeField][field: Range(0f, 5f)] public float JumpForce { get; private set; } = 5f;
}
