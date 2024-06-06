using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapeProjectile : MonoBehaviour
{
    //initialize setting
    [SerializeField] private float duration = 1f;
    [SerializeField] private AnimationCurve animationCurve;
    [SerializeField] private float heightY = 3f;
    [SerializeField] private GameObject grapeProjectileShadows;
    [SerializeField] private GameObject splatterPrefab;

    //start setting
    private void Start()
    {
        GameObject grapeShadow = Instantiate(grapeProjectileShadows, transform.position + new Vector3(0, -0.3f, 0), Quaternion.identity);
        Vector3 playerPosition = PlayerController.Instance.transform.position;
        Vector3 shadowStartPosition = grapeShadow.transform.position;

        StartCoroutine(ProjectileCurveRoutine(transform.position, playerPosition));
        StartCoroutine(MoveShadowRoutine(grapeShadow, shadowStartPosition, playerPosition));
    }

    //routine of grape projectile curve
    private IEnumerator ProjectileCurveRoutine(Vector3 startPosition, Vector3 endPosition)
    {
        float timePassed = 0f;

        while (timePassed < duration)
        {
            timePassed += Time.deltaTime;
            float linearTime = timePassed / duration;
            float heightTime = animationCurve.Evaluate(linearTime);
            float height = Mathf.Lerp(0f, heightY, heightTime);

            transform.position = Vector2.Lerp(startPosition, endPosition, linearTime) + new Vector2(0f, height);
            yield return null;
        }

        Instantiate(splatterPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    //routine of grape shadow movement
    private IEnumerator MoveShadowRoutine(GameObject grapeShadow, Vector3 startPosition, Vector3 endPosition)
    {
        float timePassed = 0f;

        while (timePassed < duration)
        {
            timePassed += Time.deltaTime;
            float linearTime = timePassed / duration;
            grapeShadow.transform.position = Vector2.Lerp(startPosition, endPosition, linearTime);
            yield return null;
        }

        Destroy(grapeShadow);
    }
}
