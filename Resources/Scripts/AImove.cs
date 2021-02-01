using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.SceneManagement;

public class AImove : MonoBehaviour
{
    //Generate path
    Seeker seeker;

    //Stores the path
    Path path;

    //Referencing the target
    private Transform target;

    private string SceneName;


    // Start is called before the first frame update
    void Start()
    {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        SceneName = currentScene.name;

        WhichScene();

        //Instance of seeker attached to gameobject
        seeker = GetComponent<Seeker>();

        //Generating first path
        path = seeker.StartPath(transform.position, target.position);

        //Start the process of moving the AI block to the target
        StartCoroutine(MoveTowardsTarget(this.transform));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void WhichScene()
    {
        if (SceneName == "KU1")
        {
            target = GameObject.Find("TargetKU1").transform;
        }
        else if (SceneName == "KU2")
        {
            target = GameObject.Find("TargetKU2").transform;
        }
        else if (SceneName == "KU4")
        {
            target = GameObject.Find("TargetKU4").transform;
        }
        else if (SceneName == "Description")
        {
            target = GameObject.Find("TargetDescription").transform;

        }
    }

    IEnumerator MoveTowardsTarget(Transform theAI)
    {

        while (true)
        {

            List<Vector3> pos = path.vectorPath;
            //Debug.Log("Positions Count: " + pos.Count);

            for (int counter = 0; counter < pos.Count; counter++)
            {
                if (pos[counter] != null)
                {
                    while (Vector3.Distance(theAI.position, pos[counter]) >= 0.5f)
                    {
                        //The AI block moves 1 unit towards the position in the pos list
                        theAI.position = Vector3.MoveTowards(theAI.position, pos[counter], 1f);

                        //Path refrshed everytime in case code is updated for target to move
                        path = seeker.StartPath(theAI.position, target.position);

                        //Wait until new path is generated
                        yield return seeker.IsDone();

                        //The paths direction is updated
                        pos = path.vectorPath;

                        yield return new WaitForSeconds(0.1f);
                    }

                }
                path = seeker.StartPath(theAI.position, target.position);
                yield return seeker.IsDone();
                pos = path.vectorPath;
                
            }
            yield return null;
        }
    }

}
