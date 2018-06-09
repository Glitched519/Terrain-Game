using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

    public GameObject pickupEffect;
    public float multiplyer = 1.4f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
            Debug.Log("Powerup picked up!");
        }   
    }

    void Pickup(Collider player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        player.transform.localScale *= multiplyer;
        Destroy(gameObject);
    }
}
