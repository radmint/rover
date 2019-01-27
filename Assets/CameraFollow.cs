using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform target;
    private float distance = 10f;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y, target.position.z - distance);
    }
}
