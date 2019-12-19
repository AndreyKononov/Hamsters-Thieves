using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolHamsters : MonoBehaviour
{
    [SerializeField] private GameObject prefHamster;
    [SerializeField] private Transform trParentHamsters;

    Queue<GameObject> poolHamster = new Queue<GameObject>();

    private const int numberHamster = 9;

    private void Awake()
    {
        for (int i = 0; i < numberHamster; i++)
        {
            AddHamster();
        }
    }

    private void AddHamster()
    {
        GameObject goHamster = Instantiate(prefHamster, new Vector3(0, 0), Quaternion.identity, trParentHamsters);
        goHamster.SetActive(false);

        poolHamster.Enqueue(goHamster);
    }

    public GameObject GetHamster()
    {
        if (poolHamster.Count == 0)
            AddHamster();

        return poolHamster.Dequeue().gameObject;
    }        

    public void DropUnit(GameObject goHamster)
    {
        goHamster.SetActive(false);       
        poolHamster.Enqueue(goHamster);
    }
}
