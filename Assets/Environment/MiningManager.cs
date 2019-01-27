using UnityEngine;

public class MiningManager : MonoBehaviour {

    public float cubeSpeed;
    public bool canBeMined;
    private float timeLapsed = 0;
    ParticleSystem particleSystem;

    // Use this for initialization
    void Start () {
        particleSystem = gameObject.GetComponent<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerStay2D(Collider2D collision)
    {
        timeLapsed += Time.deltaTime;
        if(!particleSystem.isPlaying) { 
            gameObject.GetComponent<ParticleSystem>().Play();
            ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
            em.enabled = true;
        }
        if (timeLapsed > cubeSpeed)
        {
            Debug.Log(timeLapsed);
            Destroy(gameObject);
            gameObject.GetComponent<ParticleSystem>().Stop();
            timeLapsed = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        timeLapsed = 0;
        Debug.Log("the thing left the trigger");
        if(particleSystem.isPlaying) { 
            gameObject.GetComponent<ParticleSystem>().Stop();
        }
    }
}
