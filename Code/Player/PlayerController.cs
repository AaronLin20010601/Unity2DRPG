using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Singleton<PlayerController>
{
    //initialize setting
    public bool FacingLeft { get { return facingLeft; } }
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float dashSpeed = 4f;
    [SerializeField] private TrailRenderer myTrailRenderer;
    [SerializeField] private Transform weaponCollider;

    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRenderer;
    private KnockBack knockBack;

    private float startingMoveSpeed;
    private bool facingLeft = false;
    private bool isDashing = false;

    //initialize
    protected override void Awake()
    {
        base.Awake();
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        knockBack = GetComponent<KnockBack>();
    }

    //start setting
    private void Start()
    {
        playerControls.Combat.Dash.performed += _ => Dash();
        startingMoveSpeed = moveSpeed;
        ActiveInventory.Instance.EquipStartWeapon();
    }

    //enable player controls
    private void OnEnable()
    {
        playerControls.Enable();
    }

    //disable player control when died
    private void OnDisable()
    {
        playerControls.Disable();
    }

    //update player controls
    private void Update()
    {
        PlayerInput();
    }

    //update the facing direction and movement
    private void FixedUpdate()
    {
        AdjustPlayerFacingDirection();
        Move();
    }

    //return the collider of sword
    public Transform GetWeaponCollider()
    {
        return weaponCollider;
    }

    //detect the input control of player
    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
        myAnimator.SetFloat("MoveX", movement.x);
        myAnimator.SetFloat("MoveY",movement.y);
    }

    //player movement implement
    private void Move()
    {
        if (knockBack.GettingKnockedBack || PlayerHealth.Instance.isDead) { return; }
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    //adjust the facing direction of player
    private void AdjustPlayerFacingDirection()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if (mousePos.x  < playerScreenPoint.x)
        {
            mySpriteRenderer.flipX = true;
            facingLeft = true;
        }
        else
        {
            mySpriteRenderer.flipX = false;
            facingLeft= false;
        }
    }

    //player dash behavior
    private void Dash()
    {
        if (!isDashing && Stamina.Instance.CurrentStamina > 0)
        {
            Stamina.Instance.UseStamina();
            isDashing = true;
            moveSpeed *= dashSpeed;
            myTrailRenderer.emitting = true;
            StartCoroutine(EndDashRoutine());
        }
    }

    //routine of player dash cooldown
    private IEnumerator EndDashRoutine()
    {
        float dashTime = .2f;
        float dashCD = .25f;
        yield return new WaitForSeconds(dashTime);
        moveSpeed = startingMoveSpeed;
        myTrailRenderer.emitting = false;
        yield return new WaitForSeconds(dashCD);
        isDashing= false;
    }
}
