using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    //initialize setting
    [SerializeField] private float parallaxOffset = -0.15f;
    private Camera camera;
    private Vector2 startPosition;
    private Vector2 travel => (Vector2)camera.transform.position - startPosition;

    //initialize
    private void Awake()
    {
        camera = Camera.main;
    }

    //start setting
    private void Start()
    {
        startPosition = transform.position;
    }

    //update the position due to travel
    private void FixedUpdate()
    {
        transform.position = startPosition + travel * parallaxOffset;
    }
}
