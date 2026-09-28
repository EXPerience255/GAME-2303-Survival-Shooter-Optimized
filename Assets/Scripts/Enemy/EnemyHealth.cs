using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public EnemyObj stats;
    public EnemyManager sourcePool;
    public int currentHealth;


    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;


    void Awake ()
    {
        anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();

        currentHealth = stats.MaxHealth;
    }


    void Update ()
    {
        if(isSinking)
        {
            transform.Translate (-Vector3.up * stats.SinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        if(isDead)
            return;

        enemyAudio.Play ();

        currentHealth -= amount;
            
        hitParticles.transform.position = hitPoint;
        hitParticles.Play();

        if(currentHealth <= 0)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.SetTrigger (AnimationHasher.Dead);

        enemyAudio.clip = stats.DeathSound;
        enemyAudio.Play ();
    }


    public void StartSinking ()
    {
        GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
        GetComponent <Rigidbody> ().isKinematic = true;
        isSinking = true;
        ScoreManager.playerInterface.Score += stats.ScoreValue;
        StartCoroutine(ReturnToPool(2));
    }


    private IEnumerator ReturnToPool(float time)
    {
        yield return new WaitForSeconds (time);
        sourcePool.enemyPool.Release(gameObject);
    }
}
