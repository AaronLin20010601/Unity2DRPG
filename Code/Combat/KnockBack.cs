using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    //initialize setting
    public bool GettingKnockedBack { get; private set; }
    [SerializeField] private float knockBackTime = .2f;
    private Rigidbody2D rb;

    //initialize
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //target knock back implement
    public void GetKnockedBack(Transform damageSource,float knockBackThrust)
    {
        GettingKnockedBack = true;
        Vector2 difference = (transform.position - damageSource.position).normalized * knockBackThrust * rb.mass;
        rb.AddForce(difference,ForceMode2D.Impulse);
        StartCoroutine(KnockRoutine());
    }

    //routine of knock back after target getting hit
    private IEnumerator KnockRoutine()
    {
        yield return new WaitForSeconds(knockBackTime);
        rb.velocity = Vector2.zero;
        GettingKnockedBack = false;
    }
}
