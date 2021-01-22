using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GameManager : MonoBehaviour
{
    //Referencing the obstacles
    public GameObject obstacle;

    //Referencing the aiblocks
    public GameObject AIblocks;

    //Referencing PointGraphObject
    GameObject graphParent;

    // Start is called before the first frame update
    void Start()
    {
        graphParent = GameObject.Find("AStar");
        //we scan the graph to generate it in memory
        graphParent.GetComponent<AstarPath>().Scan();

        

        for (int i = 0; i < 5; i++)
        { 
            generateObstacles(obstacle);
        }

        for (int i = 0; i < 10; i++)
        {
            generateAIblocks(AIblocks);
            StartCoroutine(updateGraph());
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator updateGraph()
    {
            graphParent.GetComponent<AstarPath>().Scan();
            yield break;
            //yield return null;
    }

    void generateObstacles(GameObject obstacle)
    {
        float randomX = Mathf.Floor(Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y));

        float randomY = Mathf.Floor(Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x));

        Vector3 randomLocation = new Vector3(randomX, randomY);

        Instantiate(obstacle, randomLocation, Quaternion.identity);
    }

    void generateAIblocks(GameObject AIblocks)
    {
        float randomX = Mathf.Floor(Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y));

        float randomY = Mathf.Floor(Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x));

        Vector3 randomLocation = new Vector3(randomX, randomY);

        Instantiate(AIblocks, randomLocation, Quaternion.identity);
    }

}
