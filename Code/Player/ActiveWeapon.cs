using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeapon : Singleton<ActiveWeapon>
{
    //initialize setting
    public MonoBehaviour CurrentActiveWeapon { get; private set; }
    private PlayerControls playerControls;
    private float timeBetweenAttacks;
    private bool attackButtonDown, isAttacking = false;

    //initialize
    protected override void Awake()
    {
        base.Awake();
        playerControls = new PlayerControls();
    }

    //enable the player control
    private void OnEnable()
    {
        playerControls.Enable();
    }
    
    //start setting
    private void Start()
    {
        playerControls.Combat.Attack.started += _ => StartAttacking();
        playerControls.Combat.Attack.canceled += _ => StopAttacking();
        AttackCooldown();
    }

    //update the attack behavior
    private void Update()
    {
        Attack();
    }

    //change to the new weapon
    public void NewWeapon(MonoBehaviour newWeapon)
    {
        CurrentActiveWeapon = newWeapon;
        AttackCooldown();
        timeBetweenAttacks = (CurrentActiveWeapon as IWeapon).GetWeaponInfo().weaponCD;
    }

    //clear the weapon
    public void WeaponNull()
    {
        CurrentActiveWeapon = null;
    }

    //cooldown of attack
    private void AttackCooldown()
    {
        isAttacking = true;
        StopAllCoroutines();
        StartCoroutine(TimeBetweenAttacksRoutine());
    }

    //routine of attack cooldown
    private IEnumerator TimeBetweenAttacksRoutine()
    {
        yield return new WaitForSeconds(timeBetweenAttacks);
        isAttacking = false;
    }

    //start attacking
    private void StartAttacking()
    {
        attackButtonDown = true;
    }

    //stop attacking
    private void StopAttacking()
    {
        attackButtonDown = false;
    }

    //player attack implement
    private void Attack()
    {
        if (attackButtonDown && !isAttacking && CurrentActiveWeapon)
        {
            AttackCooldown();
            (CurrentActiveWeapon as IWeapon).Attack();
        }
    }
}
