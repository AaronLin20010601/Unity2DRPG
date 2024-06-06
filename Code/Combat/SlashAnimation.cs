using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAnimation : MonoBehaviour
{
    //initialize setting
    private ParticleSystem ps;

    //initialize
    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }

    //update slash animation
    private void Update()
    {
        if (ps && !ps.IsAlive())
        {
            DestroySelf();
        }
    }

    //finish slash animation
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
