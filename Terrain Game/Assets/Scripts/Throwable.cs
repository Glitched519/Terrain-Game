using UnityEngine;

public class Throwable : MonoBehaviour {

    public Transform player, playerCam;
    public float throwForce = 10;
    bool hasPlayer, beingCarried = false;
        public int dmg;
    private bool touched = false;
	
	void Update ()
    {
        float dist = Vector3.Distance(gameObject.transform.position, player.position);
        if(dist <= 2.5f)
        {
            hasPlayer = true;
        }
        else
        {
            hasPlayer = false;
        }
        if(hasPlayer && Input.GetButtonDown("Submit"))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = playerCam;
            beingCarried = true;
        }
        if (beingCarried)
        {
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
