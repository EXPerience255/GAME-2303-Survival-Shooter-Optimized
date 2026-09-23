using UnityEngine;

public static class AnimationHasher
{
    // HUDCanvas
    public static int GameOver = Animator.StringToHash("GameOver");

    // PlayerAC
    public static int IsWalking = Animator.StringToHash("IsWalking");
    public static int Die = Animator.StringToHash("Die");

    // EnemyAC
    public static int Dead = Animator.StringToHash("Dead");
    public static int PlayerDead = Animator.StringToHash("PlayerDead");
}
