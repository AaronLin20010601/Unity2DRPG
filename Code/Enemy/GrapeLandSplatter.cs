using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapeLandSplatter : MonoBehaviour
{
    //initialize setting
    private SpriteFade spriteFade;

    //initialize
    private void Awake()
    {
        spriteFade = GetComponent<SpriteFade>();
    }

    //start setting
    private void Start()
    {
        StartCoroutine(spriteFade.SlowFadeRoutine());
        Invoke("DisableCollider", 0.2f);
    }

    //player take damage after getting hit by grape
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
        playerHealth?.TakeDamage(1, transform);
    }

    //disable the grape splatter collider after dissappear
    private void DisableCollider()
    {
        GetComponent<CapsuleCollider2D>().enabled = false;
    }
}
