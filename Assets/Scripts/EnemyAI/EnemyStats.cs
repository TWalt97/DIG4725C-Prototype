using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Stats", menuName = "ScriptableObject/Enemy Stats")]
public class EnemyStats : ScriptableObject
{
    public int health = 100;
    public float speed;
    public float chargeRange = 7f;

}
