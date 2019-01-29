using UnityEngine;

public class MiningManager : MonoBehaviour {

    private ResourceCube resource;
    ParticleSystem particleSystem;
    private Inventory inventory;
    float timeLapsed;

    // Use this for initialization
    void Start () {
        particleSystem = gameObject.GetComponent<ParticleSystem>();
        resource = gameObject.GetComponent<ResourceCube>();
        inventory = FindObjectOfType<Inventory>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        timeLapsed += Time.deltaTime;
        if (collision.name == "Rover")
        {
            if(!particleSystem.isPlaying) { 
                gameObject.GetComponent<ParticleSystem>().Play();
                ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
                em.enabled = true;
            }
            if (timeLapsed > resource.MiningSpeed) {
                Debug.Log(timeLapsed + " " + resource.MiningSpeed);

                if (resource.ResourceType != ResourceType.None) {
                    var resources = new ResourceCube[]
                    {
                        resource
                    };
                    inventory.SendMessage("CollectResource", resources);
                }
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(particleSystem.isPlaying) { 
            gameObject.GetComponent<ParticleSystem>().Stop();
        }
    }
}
