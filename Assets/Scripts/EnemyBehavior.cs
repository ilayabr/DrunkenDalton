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
    private float bulletVelocity = 100f;
    public float bulletLifeTime = 3f;
    private bool isHit = false;

    void Start()
    {
        Shoot();
    }

    void LateUpdate()
    {
        Vector3 lookDirection = player.transform.position - gameObject.transform.position;
        lookDirection.Normalize();
        gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation,
            Quaternion.LookRotation(lookDirection), 25f * Time.deltaTime);
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
        _animator.SetBool("isHit", isHit);
        yield return new WaitForSeconds(Random.Range(0, 10));
        isHit = false;
        _animator.SetBool("isHit", isHit);
        StartCoroutine(ShootPlayer());
    }

    //enemy shoots the player
    private IEnumerator ShootPlayer()
    {
        yield return new WaitForSeconds(3);
        if (!isHit)
        {
            FireWeapon();
        }
        StartCoroutine(GotHit());
    }

    private void FireWeapon()
    {
        //spawning bullet
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
        //shooting bullet
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward.normalized * bulletVelocity, ForceMode.Impulse);
        if (!player.GetComponent<PlayerMovment>().getIsInvincible())
        {
            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().LosePoint();
        }
        //destroy bullet after some time
        StartCoroutine(DestroyBulletAfterTime(bullet, bulletLifeTime));
    }

    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}