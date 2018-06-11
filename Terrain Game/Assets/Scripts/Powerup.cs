using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Powerup : MonoBehaviour {

    public GameObject pickupEffect;
    public float multiplier = 1.4f;
    public float duration = 30f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
            Debug.Log("Powerup picked up!");
        }   
    }

    IEnumerator Pickup(Collider player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        player.transform.localScale *= multiplier;
        FirstPersonController controller = player.GetComponent<FirstPersonController>();
        controller.m_RunSpeed *= multiplier;
        controller.m_WalkSpeed *= multiplier;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(duration);
        controller.m_RunSpeed /= multiplier;
        controller.m_WalkSpeed /= multiplier;
        Destroy(gameObject);
    }
}
