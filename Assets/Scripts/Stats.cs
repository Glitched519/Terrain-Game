using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour {

    public Text coordinates, direction;
    public Transform player;
    
    // Use this for initialization
    void Update () {
        coordinates.text = "Location: " + player.position;
        direction.text = "Rotation: " + Mathf.Abs((int)(player.rotation.y * 180)) + "°";
        
        

    }

}
