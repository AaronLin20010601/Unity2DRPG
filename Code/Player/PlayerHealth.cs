using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : Singleton<PlayerHealth>
{
    //initialize setting
    public bool isDead {  get; private set; }
    [SerializeField] private int maxHealth = 4;
    [SerializeField] private float knockBackThrustAmount = 10f;
    [SerializeField] private float damageRecoveryTime = 1f;
    [SerializeField] private float deathReviveTime = 2f;

    private Slider healthSlider;
    private int currentHealth;
    private bool canTakeDamage = true;
    private KnockBack knockBack;
    private Flash flash;

    const string HEALTH_SLIDER_TEXT = "Health Slider";
    const string TOWN_TEXT = "StartScene";
    readonly int DEATH_HASH = Animator.StringToHash("Death");

    //initialize
    protected override void Awake()
    {
        base.Awake();

        flash = GetComponent<Flash>();
        knockBack = GetComponent<KnockBack>();
    }

    //start setting
    private void Start()
    {
        isDead = false;
        currentHealth = maxHealth;
        UpdateHealthSlider();
    }

    //detect whether player collide with enemy
    private void OnCollisionStay2D(Collision2D collision)
    {
        EnemyAI enemy = collision.gameObject.GetComponent<EnemyAI>();
        if (enemy)
        {
            TakeDamage(1, collision.transform);
        }
    }

    //heal player after pick up heart
    public void HealPlayer()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += 1;
            UpdateHealthSlider();
        }
    }

    //player taking damage implement
    public void TakeDamage(int damageAmount, Transform hitTransform)
    {
        if (!canTakeDamage) { return; }
        ScreenShakeManager.Instance.ShakeScreen();
        knockBack.GetKnockedBack(hitTransform, knockBackThrustAmount);

        StartCoroutine(flash.FlashRoutine());
        canTakeDamage = false;
        currentHealth -= damageAmount;
        StartCoroutine(DamageRecoveryRoutine());

        UpdateHealthSlider();
        CheckPlayerDeath();
    }

    //check if the player is dead
    private void CheckPlayerDeath()
    {
        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            Destroy(ActiveWeapon.Instance.gameObject);
            currentHealth = 0;

            GetComponent<Animator>().SetTrigger(DEATH_HASH);
            StartCoroutine(DeathLoadSceneRoutine());
        }
    }

    //routine of teleport player to start scene after death
    private IEnumerator DeathLoadSceneRoutine()
    {
        yield return new WaitForSeconds(deathReviveTime);
        Destroy(gameObject);
        SceneManager.LoadScene(TOWN_TEXT);
    }

    //routine of recovery after taking damage
    private IEnumerator DamageRecoveryRoutine()
    {
        yield return new WaitForSeconds(damageRecoveryTime);
        canTakeDamage = true;
    }

    //update health bar
    private void UpdateHealthSlider()
    {
        if (healthSlider == null)
        {
            healthSlider = GameObject.Find(HEALTH_SLIDER_TEXT).GetComponent<Slider>();
        }

        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }
}
