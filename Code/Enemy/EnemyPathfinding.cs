using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{
    //initialize setting
    [SerializeField] private float moveSpeed = 2f;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private KnockBack knockBack;
    private SpriteRenderer spriteRenderer;

    //initialize
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        knockBack = GetComponent<KnockBack>();
        rb = GetComponent<Rigidbody2D>();
    }

    //update the facing direction and moving position of the enemy
    private void FixedUpdate()
    {
        if (knockBack.GettingKnockedBack) { return; }
        rb.MovePosition(rb.position + moveDirection * (moveSpeed * Time.fixedDeltaTime));

        if (moveDirection.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveDirection.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    //set the position of the enemy to move
    public void MoveTo(Vector2 targetPosition)
    {
        moveDirection = targetPosition;
    }

    //stop the moving behavior of the enemy
    public void StopMoving()
    {
        moveDirection = Vector3.zero;
    }
}
