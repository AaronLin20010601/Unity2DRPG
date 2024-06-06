using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : Singleton<CameraController>
{
    //initialize setting
    private CinemachineVirtualCamera cinemachineVirtualCamera;

    //start setting
    private void Start()
    {
        SetPlayerCameraFollow();
    }

    //make the camera follow with player
    public void SetPlayerCameraFollow()
    {
        cinemachineVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        cinemachineVirtualCamera.Follow = PlayerController.Instance.transform;
    }
}
