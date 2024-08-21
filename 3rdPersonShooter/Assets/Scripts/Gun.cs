using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    [Range(0.1f,1.5f)]
    private float fireRate = 0.3f;
    [SerializeField]
    [Range(1,10)]
    private int damage = 1;
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private ParticleSystem muzzleFlash;

    [SerializeField]
    private AudioSource fireSound;
    private float timer;

    private InputActions inputActions;

    // Start is called before the first frame update
    void Start()
    {
        inputActions = GameManager.Instance.inputActions;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= fireRate)
        {
            if(inputActions.OnFoot.Fire.IsPressed())
            {
                timer = 0f;
                FireGun();
            }
        }
    }

    private void FireGun()
    {
        
        Ray ray = new Ray(firePoint.position,firePoint.forward);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, 100f))
        {
            // Destroy(hitInfo.collider.gameObject);
            // Debug.DrawRay(firePoint.position,firePoint.forward * 100, Color.red, 2f);
            if(muzzleFlash != null)
             muzzleFlash.Play();
            if(fireSound != null)
             fireSound.Play();
            var enemyHealth = hitInfo.collider.gameObject.GetComponent<Health>();
            if(enemyHealth != null)
                enemyHealth.TakeDamage(damage);
        }
    }
}
