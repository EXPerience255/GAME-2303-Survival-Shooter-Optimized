using UnityEngine;

[CreateAssetMenu(fileName = "EnemyObj", menuName = "Scriptable Objects/EnemyObj")]
public class EnemyObj : ScriptableObject
{
    // EnemyHealth.cs
    [field: SerializeField] public int MaxHealth;
    [field: SerializeField] public float SinkSpeed;
    [field: SerializeField] public int ScoreValue;
    [field: SerializeField] public AudioClip DeathSound;

    // EnemyAttack.cs
    [field: SerializeField] public float AttackCooldown;
    [field: SerializeField] public int AttackDamage;
}
