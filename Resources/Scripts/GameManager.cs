using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Referencing the obstacles
    public GameObject obstacle;

    //Referencing the aiblocks
    public GameObject AIblocks;

    //Referencing PointGraphObject
    GameObject graphParent;

    private string SceneName;

    // Start is called before the first frame update
    void Start()
    {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        SceneName = currentScene.name;

        WhichScene();

        graphParent = GameObject.Find("AStar");
        //we scan the graph to generate it in memory
        graphParent.GetComponent<AstarPath>().Scan();

    }

    // Update is called once per frame
    void Update()
    {
        graphParent.GetComponent<AstarPath>().Scan();
    }

    void WhichScene()
    {
        if (SceneName == "KU1")
        {
            for (int i = 0; i < 10; i++)
            {
                generateAIblocks(AIblocks);
            }
        }
        else if (SceneName == "KU2")
        {
            for (int i = 0; i < 5; i++)
            {
                generateObstacles(obstacle);
            }
        }
        else if (SceneName == "KU4")
        {
            
        }
        else if (SceneName == "Description")
        {
            
        }
    }

    public void updateGraphMethod()
    {
        graphParent.GetComponent<AstarPath>().Scan();
    }


    IEnumerator updateGraph()
    {
            graphParent.GetComponent<AstarPath>().Scan();
            yield return null;
    }

    public void generateObstacles(GameObject obstacle)
    {
        float randomX = Mathf.Floor(Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y));

        float randomY = Mathf.Floor(Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x));

        Vector3 randomLocation = new Vector3(randomX, randomY);

        Instantiate(obstacle, randomLocation, Quaternion.identity);
    }

    public void generateAIblocks(GameObject AIblocks)
    {
        float randomX = Mathf.Floor(Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y));

        float randomY = Mathf.Floor(Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x));

        Vector3 randomLocation = new Vector3(randomX, randomY);

        Instantiate(AIblocks, randomLocation, Quaternion.identity);
    }

}
