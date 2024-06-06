using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    //initialize setting
    [SerializeField] private Material whiteFlashMaterial;
    [SerializeField] private float restoreDefaultMaterialTime = .2f;

    private Material defaultMaterial;
    private SpriteRenderer spriteRenderer;

    //initialize
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultMaterial = spriteRenderer.material;
    }

    //return time of restore material
    public float GetRestoreMaterialTime()
    {
        return restoreDefaultMaterialTime;
    }

    //routine of enemy flash after getting hit
    public IEnumerator FlashRoutine()
    {
        spriteRenderer.material = whiteFlashMaterial;
        yield return new WaitForSeconds(restoreDefaultMaterialTime);
        spriteRenderer.material = defaultMaterial;
    }
}
