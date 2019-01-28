using System.Collections;
using UnityEngine;

public class MiningManager : MonoBehaviour {

    private ResourceCube resource;
    ParticleSystem particleSystem;
    private Inventory inventory;

    // Use this for initialization
    void Start () {
        particleSystem = gameObject.GetComponent<ParticleSystem>();
        resource = gameObject.GetComponent<ResourceCube>();
        inventory = FindObjectOfType<Inventory>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(!particleSystem.isPlaying) { 
            gameObject.GetComponent<ParticleSystem>().Play();
            ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
            em.enabled = true;
        }

        StartCoroutine(DestroyAndCollect());
           
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("trigger exited");
        if(particleSystem.isPlaying) { 
            gameObject.GetComponent<ParticleSystem>().Stop();
        }
        StopCoroutine(DestroyAndCollect());
    }

    private IEnumerator DestroyAndCollect()
    {
        Debug.Log(resource.MiningSpeed + " " + resource.resourceType.ToString());
        yield return new WaitForSeconds(5/resource.MiningSpeed);
        Destroy(gameObject);
        gameObject.GetComponent<ParticleSystem>().Stop();
        inventory.AddResourceThenUpdate(resource, resource.Value);
    }
}
