using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour, IWeapon
{
    //initialize setting
    [SerializeField] private WeaponInfo weaponInfo;
    [SerializeField] private GameObject magicLaser;
    [SerializeField] private Transform magicLaserSpawnPoint;

    private Animator myAnimator;
    readonly int ATTACK_HASH = Animator.StringToHash("Attack");

    //initialize
    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    //update the position with mouse
    private void Update()
    {
        MouseFollowWithOffset();
    }

    //staff attack implement
    public void Attack()
    {
        myAnimator.SetTrigger(ATTACK_HASH);
    }

    //spawn the laser projectile
    public void SpawnStaffProjectileAnimation()
    {
        GameObject newLaser = Instantiate(magicLaser, magicLaserSpawnPoint.position, Quaternion.identity);
        newLaser.GetComponent<MagicLaser>().UpdateLaserRange(weaponInfo.weaponRange);
    }

    //get the info of weapon
    public WeaponInfo GetWeaponInfo()
    {
        return weaponInfo;
    }

    //make the attack point follow with mouse
    private void MouseFollowWithOffset()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(PlayerController.Instance.transform.position);
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        if (mousePos.x < playerScreenPoint.x)
        {
            ActiveWeapon.Instance.transform.rotation = Quaternion.Euler(0, -180, angle);
        }
        else
        {
            ActiveWeapon.Instance.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
