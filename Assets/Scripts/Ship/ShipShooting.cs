using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField]
    protected GameObject bulletPrefabs;

    [SerializeField]
    protected GameObject fireParticle;

    [SerializeField]
    protected bool isShooting = false;

    protected AudioSource audioSrc;
    [SerializeField]
    protected AudioClip bulletSound;

    [SerializeField]
    protected float shootDelay;

    [SerializeField]
    protected float shootTimer;

    private void Awake()
    {
        audioSrc = GetComponent<AudioSource>();    
    }

    private void FixedUpdate()
    {
        this.IsShooting();
        this.Shooting();
    }

    protected virtual void Shooting()
    {
        if (!isShooting) {
            fireParticle.SetActive(false);
            return;
        };

        this.shootTimer += Time.fixedDeltaTime;
        if (shootTimer < shootDelay) return;
        this.shootTimer = 0;

        Vector3 spawnPos = transform.parent.position;
        Quaternion rotation = transform.parent.rotation;
        Instantiate(bulletPrefabs, spawnPos, rotation);
        fireParticle.SetActive(true);
        audioSrc.PlayOneShot(bulletSound);
    }

    protected virtual bool IsShooting()
    {
        this.isShooting = InputManager.Instance.OnFiring == 1;
        return this.isShooting;
    }
}
