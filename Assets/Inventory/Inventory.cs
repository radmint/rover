using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
    public Text Copper;
    public Text Iron;
    public Text Gold;

    public Resource[] resources;

    // Use this for initialization
    void Start () {
        var copperResource = ScriptableObject.CreateInstance<Resource>();
        copperResource.Count = 10;
        copperResource.ResourceType = ResourceType.Copper;

        var ironResource = ScriptableObject.CreateInstance<Resource>();
        ironResource.Count = 10;
        ironResource.ResourceType = ResourceType.Iron;

        var goldResource = ScriptableObject.CreateInstance<Resource>();
        goldResource.Count = 10;
        goldResource.ResourceType = ResourceType.Gold;

        resources = new[]
        {
            copperResource, ironResource, goldResource
        };
        Copper.text = resources.FirstOrDefault(resource => resource.ResourceType == ResourceType.Copper).Count.ToString();
        Iron.text = resources.FirstOrDefault(resource => resource.ResourceType == ResourceType.Iron).Count.ToString();
        Gold.text = resources.FirstOrDefault(resource => resource.ResourceType == ResourceType.Gold).Count.ToString();
    }

    public void AddResourceThenUpdate(ResourceCube resource, int count)
    {
        var tempResource = resources.FirstOrDefault(x => x.ResourceType == resource.resourceType);
        tempResource.Count += count;
        if(tempResource.ResourceType == ResourceType.Copper)
        {
            Copper.text = tempResource.Count.ToString();
        } else if (tempResource.ResourceType == ResourceType.Iron)
        {
            Iron.text = tempResource.Count.ToString();
        } else if (tempResource.ResourceType == ResourceType.Gold)
        {
            Gold.text = tempResource.Count.ToString();
        }
    }

    public void RemoveResourceThenUpdate(ResourceCube resource, int count)
    {
        resources.FirstOrDefault(x => x.ResourceType == resource.resourceType).Count -= count;
    }
}
