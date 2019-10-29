using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handle hitpoints and damages
/// </summary>
public class ShrinkScript : MonoBehaviour
{

    private bool pick = false;
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Is this a packet?
        PacketScript packg = otherCollider.gameObject.GetComponent<PacketScript>();
        if (packg != null && pick)
        {
            transform.localScale *= 0.7f;
                //new Vector3(0.25f, 0.25f, 1);
            Destroy(packg.gameObject); // Remember to always target the game object, otherwise you will just remove the script

        }
    }

    private void Update()
    {
        pick = Input.GetButton("Fire1");
    }



}