using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grape : MonoBehaviour, IEnemy
{
    //initialize setting
    [SerializeField] private GameObject grapeProjectilePrefab;
    private Animator myAnimator;
    private SpriteRenderer spriteRenderer;
    readonly int ATTACK_HASH = Animator.StringToHash("Attack");

    //initialize
    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //grape shooter attack direction
    public void Attack()
    {
        myAnimator.SetTrigger(ATTACK_HASH);

        if (transform.position.x - PlayerController.Instance.transform.position.x < 0 )
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }

    //spawn grape shooter projectile
    public void SpawnProjectileAnimation()
    {
        Instantiate(grapeProjectilePrefab, transform.position, Quaternion.identity);
    }
}
