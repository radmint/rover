using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public int maxWidth = 50;
    public int maxHeight = 10;

    public GameObject ground;
    public GameObject dirt;
    public GameObject iron;
    public GameObject copper;
    public GameObject gold;
    private GameObject blockToPlace;

    public float cubeHeightWidth;
    private Vector2 surface = new Vector2(0, 0);
    private Dictionary<int, GameObject[]> blockAvailByYAxis;
    private Vector2 originPosition;

	void Start () {
        originPosition = transform.position;
        cubeHeightWidth = ground.transform.localScale.y;
        blockAvailByYAxis = new Dictionary<int, GameObject[]>()
        {
            {0, new GameObject[] { ground } },
            {-1, new GameObject[] {dirt, copper } },
            {-5, new GameObject[] {dirt, copper, iron } },
            {-15 , new GameObject[] {dirt, copper, iron, gold } },
        };
        Spawn();
	}
	
	void Spawn()
    {
        for (int i = 0; i <= maxWidth; i++)
        {
            for (int j = 0; j < maxHeight; j++)
            {
                blockToPlace = DetermineBlock(originPosition.y);
                Instantiate(blockToPlace, originPosition, Quaternion.identity);
                float cubeY = originPosition.y - cubeHeightWidth;
                Vector2 nextPositionY = new Vector2(originPosition.x, cubeY);
                originPosition = nextPositionY;

                if (j == (maxHeight - 1))
                {
                    originPosition = new Vector2(originPosition.x, surface.y);
                }

            }
            blockToPlace = DetermineBlock(originPosition.y);
            Instantiate(blockToPlace, originPosition, Quaternion.identity);
            originPosition += new Vector2(cubeHeightWidth, originPosition.y);
        }
    }

    //determines which block to generate based on y axis
    GameObject DetermineBlock(float yAxis)
    {
        KeyValuePair<int, GameObject[]> lastObj = blockAvailByYAxis.OrderByDescending(block => block.Key).First();
        GameObject[] blockChoices = lastObj.Value;

        foreach(var avail in blockAvailByYAxis.OrderByDescending(block => block.Key))
        {
            if(yAxis == 0)
            {
                return blockChoices[0];
            }
            else if (yAxis == avail.Key)
            {
                return avail.Value[Random.Range(0, avail.Value.Length - 1)];
            }
            else if (yAxis < avail.Key)
            {
                blockChoices = avail.Value;
                continue;
            }
        }

        var randomIndex = Random.Range(0, blockChoices.Length);
        GameObject blockToReturn = blockChoices[randomIndex];
        return blockToReturn;
    }
}
