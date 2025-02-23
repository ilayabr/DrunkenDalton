using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Animator _animator;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletVelocity = 30f;
    public float bulletLifeTime = 3f;
    private bool isHit = false;

    void Start()
    {
        StartCoroutine(ShootPlayer());
    }

    void LateUpdate()
    {
        Vector3 lookDirection = player.transform.position - gameObject.transform.position;
        lookDirection.Normalize();
        gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation,
            Quaternion.LookRotation(lookDirection), 25f * Time.deltaTime);
        
        _animator.SetBool("isHit", isHit);
    }

    //action called by bullet on hit
    public void Shoot()
    {
        StartCoroutine(GotHit());
    }

    public bool GetIsHit()
    {
        return isHit;
    }

    private IEnumerator GotHit()
    {
        isHit = true;
        yield return new WaitForSeconds(Random.Range(0, 10));
        isHit = false;
    }

    //enemy shoots the player
    private IEnumerator ShootPlayer()
    {
        yield return new WaitForSeconds(3);
        if (!isHit)
        {
            FireWeapon();
        }

        StartCoroutine(ShootPlayer());
    }

    private void FireWeapon()
    {
        //spawning bullet
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
        //shooting bullet
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward.normalized * bulletVelocity, ForceMode.Impulse);
        //destroy bullet after some time
        StartCoroutine(DestroyBulletAfterTime(bullet, bulletLifeTime));
    }

    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}