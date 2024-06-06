using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //initialize setting
    [SerializeField] private int startingHealth = 3;
    [SerializeField] private GameObject deathVFXPrefab;
    [SerializeField] private float knockBackThrust = 15f;

    private int currentHealth;
    private KnockBack knockBack;
    private Flash flash;

    //initialize
    private void Awake()
    {
        flash = GetComponent<Flash>();
        knockBack = GetComponent<KnockBack>();
    }

    //start setting
    private void Start()
    {
        currentHealth = startingHealth;
    }

    //enemy take damage and reduce health after getting hit
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        knockBack.GetKnockedBack(PlayerController.Instance.transform, knockBackThrust);
        StartCoroutine(flash.FlashRoutine());
        StartCoroutine(CheckDetectDeathRoutine());
    }

    //routine of checking if the health of enemy is clear
    private IEnumerator CheckDetectDeathRoutine()
    {
        yield return new WaitForSeconds(flash.GetRestoreMaterialTime());
        DetectDeath();
    }

    //enemy died after reach the bottom of the health bar
    public void DetectDeath()
    {
        if (currentHealth <= 0)
        {
            Instantiate(deathVFXPrefab, transform.position, Quaternion.identity);
            GetComponent<PickUpSpawner>().DropItems();
            Destroy(gameObject);
        }
    }
}
