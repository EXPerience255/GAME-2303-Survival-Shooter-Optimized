using UnityEngine;

[CreateAssetMenu(fileName = "PlayerUI", menuName = "Scriptable Objects/PlayerUI")]
public class PlayerUI : ScriptableObject
{
    [field: SerializeField] public int Score;
    [field: SerializeField] public int Health;
}
