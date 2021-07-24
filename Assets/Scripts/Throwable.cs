using UnityEngine;
using UnityEngine.UI;

public class Throwable : MonoBehaviour {

    public Transform player, playerCam;
    public float throwForce = 200f;
    bool hasPlayer, beingCarried = false;
    public int dmg;
    private bool touched = false;
    public Text msg;
	
	void Update ()
    {
        float dist = Vector3.Distance(gameObject.transform.position, player.position);
        if(dist <= 2.5f)
        {
            hasPlayer = true;
            msg.text = "Left Shift to pick up object.";
        }
        else
        {
            hasPlayer = false;
            msg.text = null;
        }
        if(hasPlayer && Input.GetButtonDown("Submit"))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = playerCam;
            beingCarried = true;
        }
        if (beingCarried)
        {
            msg.text = "Left Click to throw object.";
            if (touched)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                touched = false;
            }
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);
            }
            else if (Input.GetMouseButtonDown(1))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
            }
        }
	}
    private void OnTriggerEnter()
    {
        if (beingCarried)
        {
            touched = true;
            
        }
    }
}
