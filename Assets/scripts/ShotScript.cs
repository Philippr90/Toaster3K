using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Projectile behavior
/// </summary>
public class ShotScript : MonoBehaviour
{
    // 1 - Designer variables

    /// <summary>
    /// Damage inflicted
    /// </summary>
    public int damage = 1;

    /// <summary>
    /// Projectile damage player or enemies?
    /// </summary>
    public bool isEnemyShot = false;

    public GameObject childGameObject;
    public bool explosiveMissile = false;

    void Start()
    {
        // 2 - Limited time to live to avoid any leak
        Destroy(gameObject, 10); // 20sec
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {    
        // Is this an enemy?
        // Is this a shot?
        EnemyScript shot = otherCollider.gameObject.GetComponent<EnemyScript>();
        
        if (shot != null && !isEnemyShot)
        {      
            // Avoid friendly fire
            Init(otherCollider);
        }
    }

    
    void Init(Collider2D otherCollider)
    {
        if (explosiveMissile == true)
        {
            Debug.Log("Explosive Missile");
            generateCircularTargets(0.1f, childGameObject, 10f, 10f);
            Debug.Log("Generating");
        }
        Debug.Log(explosiveMissile);
    }

    private void generateCircularTargets(float increment, GameObject target, float lifetime, float movementSpeed)
    {
        GameObject obj = Instantiate(target, gameObject.transform.position, Quaternion.identity);
        Destroy(obj, lifetime); // 20sec
    }
}