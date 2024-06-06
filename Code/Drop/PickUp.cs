using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    //initialize setting
    private enum PickUpType
    {
        Coin,
        Heart,
        Stamina
    }

    [SerializeField] private PickUpType pickUpType;
    [SerializeField] private float pickUpDistance = 5f;
    [SerializeField] private float accelartionRate = .2f;
    [SerializeField] private float moveSpeed = 3f;

    [SerializeField] private AnimationCurve animationCurve;
    [SerializeField] private float heightY = 1.5f;
    [SerializeField] private float popDuration = 1f;

    private Vector3 moveDirection;
    private Rigidbody2D rb;

    //initialize
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //start setting
    private void Start()
    {
        StartCoroutine(AnimationCurveSpawnRoutine());
    }

    //update the move speed and direction of pickup item
    private void Update()
    {
        Vector3 playerPosition = PlayerController.Instance.transform.position;

        if (Vector3.Distance(transform.position, playerPosition) < pickUpDistance)
        {
            moveDirection = (playerPosition - transform.position).normalized;
            moveSpeed += accelartionRate;
        }
        else
        {
            moveDirection = Vector3.zero;
            moveSpeed = 0;
        }
    }

    //update the rigidbody of pickup item
    private void FixedUpdate()
    {
        rb.velocity = moveDirection * moveSpeed * Time.deltaTime;
    }

    //pickup item dissappear after the player get it
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            DetectPickUpType();
            Destroy(gameObject);
        }
    }

    //routine of pick up item pop up
    private IEnumerator AnimationCurveSpawnRoutine()
    {
        Vector2 startPoint = transform.position;
        float randomX = transform.position.x + Random.Range(-2f, 2f);
        float randomY = transform.position.y + Random.Range(-1f, 1f);
        Vector2 endPoint = new Vector2(randomX, randomY);
        float timePassed = 0f;

        while (timePassed < popDuration)
        {
            timePassed += Time.deltaTime;
            float linearTime = timePassed / popDuration;
            float heightTime = animationCurve.Evaluate(linearTime);
            float height = Mathf.Lerp(0f, heightY, heightTime);

            transform.position = Vector2.Lerp(startPoint, endPoint, linearTime) + new Vector2(0f, height);
            yield return null;
        }
    }

    //detect the type of pop up item
    private void DetectPickUpType()
    {
        switch(pickUpType)
        {
            case PickUpType.Coin:
                Economy.Instance.UpdateCurrentGold();
                break;
            case PickUpType.Heart:
                PlayerHealth.Instance.HealPlayer();
                break;
            case PickUpType.Stamina:
                Stamina.Instance.RefreshStamina();
                break;
        }
    }
}
