using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public List<GameObject> grounds;
    private float offset = 50f;


    // Start is called before the first frame update
    void Start()
    {
        if(grounds != null && grounds.Count > 0)
        {
            grounds = grounds.OrderBy(r => r.transform.position.z).ToList();
        }
    }

    public void MoveGround()
    {
        GameObject movedGround = grounds[0];
        grounds.Remove(movedGround);
        float newZ = grounds[grounds.Count - 1].transform.position.z + offset;
        movedGround.transform.position = new Vector3(0, 0, newZ);
        grounds.Add(movedGround);
    }
         
}
