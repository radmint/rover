using UnityEngine;
using UnityEngine.UI;

public class StoreFront : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Rover")
        {
            Debug.Log("rover in");
        }
    }
}
