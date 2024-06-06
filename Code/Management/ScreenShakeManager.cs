using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ScreenShakeManager : Singleton<ScreenShakeManager>
{
    //initialize setting
    private CinemachineImpulseSource source;

    //initialize
    protected override void Awake()
    {
        base.Awake();
        source = GetComponent<CinemachineImpulseSource>();
    }

    //shake the screen when player get hit
    public void ShakeScreen()
    {
        source.GenerateImpulse();
    }
}
