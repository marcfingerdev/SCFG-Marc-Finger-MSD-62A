using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KU4PatrolBehaviourScript : MonoBehaviour
{
    public List<Transform> Obstacles;

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        MoveObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MoveObstacle()
    {
        foreach (Transform obstacle in Obstacles)
        {
            //create a new list of positions.
            List<Vector3> positions = new List<Vector3>();

            //target's current position (the top position)
            positions.Add(obstacle.position);

            //adding another position (the bottom position)
            positions.Add(new Vector3(-obstacle.position.x, obstacle.position.y));

            StartCoroutine(MoveObstacle(obstacle.transform, positions, true));
        }
        
    }

    IEnumerator MoveObstacle(Transform t, List<Vector3> points, bool loop)
    {
        if (loop)
        {
            while (true)
            {
                List<Vector3> forwardpoints = points;

                foreach (Vector3 position in forwardpoints)
                {
                    while (Vector3.Distance(t.position, position) > 0.5f)
                    {
                        t.position = Vector3.MoveTowards(t.position, position, 1f);
                        yield return new WaitForSeconds(0.05f);
                    }
                }
                forwardpoints.Reverse();
                yield return null;

            }
        }
    }

}
