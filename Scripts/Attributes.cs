using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Attributes
{
    [Header("Normal Phase")]
    public float moveSpeed = 250;
    public float friction = 0.8f;

    [Range(1, 10)]
    public float jumpForce = 10;
    [Range(0, 1)]
    public float doubleJumpMultiplier = 0.6f;
    public float pushSpeed = 150;

    [Header("Running Phase")]
    [Range(1, 40)]
    public float maxRunVelocity = 5;
    [Range(1, 200)]
    public float runAcceleration = 100;
    [Range(1, 10)]
    public float jumpForceRun = 10;
    [Range(0, 1)]
    public float doubleJumpMultiplierRun = 0.6f;

}
