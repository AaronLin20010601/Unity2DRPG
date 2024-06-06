using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomIdleAnimation : MonoBehaviour
{
    //initailize srtting
    private Animator myAnimator;

    //initialize
    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    //start setting
    private void Start()
    {
        if (!myAnimator) { return; }
        AnimatorStateInfo state = myAnimator.GetCurrentAnimatorStateInfo(0);
        myAnimator.Play(state.fullPathHash, -1, Random.Range(0f, 1f));
    }
}
