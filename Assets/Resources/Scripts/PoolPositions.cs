using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolPositions : MonoBehaviour
{
    private List<Vector3> dotsSpawnes = new List<Vector3>(9)
    {
        new Vector3(-1.75f,-2.3f,0),
        new Vector3(0,-2.3f,0),
        new Vector3(1.75f,-2.3f,0),

        new Vector3(-1.75f,-0.3f,0),
        new Vector3(0,-0.3f,0),
        new Vector3(1.75f,-0.3f,0),

        new Vector3(-1.75f,1.7f,0),
        new Vector3(0,1.7f,0),
        new Vector3(1.75f,1.7f,0)
    };

    public Vector3 GetUnit()
    {
        int rndPos = Random.Range(0, dotsSpawnes.Count);
        Vector3 position = dotsSpawnes[rndPos];
        dotsSpawnes.RemoveAt(rndPos);

        return position;
    }

    public void DropUnit(Vector3 position)
    {
        dotsSpawnes.Add(position);
    }
}
