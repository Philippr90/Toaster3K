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
        Destroy(gameObject, 20); // 20sec
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
        Debug.Log("Explosive Missile");
        if (explosiveMissile == true)
        {
            Debug.Log("Explosive Missile");
            generateCircularTargets(0.05f, childGameObject, 0.6f, 10f);
            Debug.Log("Generating");
        }
        Debug.Log(explosiveMissile);



    }

    private void generateCircularTargets(float increment, GameObject target, float lifetime, float movementSpeed)
    {
        if (increment == 0)
            return;

        double r = 1;
        Debug.Log("Generate circle Missile");
        try
        {
            for (int j = -1; j < 2; j += 2)
            {
                for (int k = -1; k < 2; k += 2)
                {
                    for (double i = 0; i < 1; i = i + increment)
                    {
                        float y = (float)(j) * (float)Math.Sqrt(Math.Pow(r * k, 2) - Math.Pow(i * k, 2));
                        if (target != null)
                        {
                            try
                            {
                                
                                GameObject obj = Instantiate(target, gameObject.transform.position, Quaternion.identity);
                                Destroy(obj, lifetime); // 20sec
                                if (obj != null)
                                {
                                    MoveScript move = obj.gameObject.GetComponent<MoveScript>();
                                    move.speed.x = movementSpeed;
                                    move.speed.y = movementSpeed;
                                    move.direction.y = y;
                                    move.direction.x = (float)i * k;
                                }
                                
                            }
                            catch (Exception ex)
                            {
                                Debug.LogError(ex.Message);
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.Message);
        }
    }
    


}


