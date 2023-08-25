using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public Transform[] Grounds;
    public List<Transform> groundSpawned;
    public Transform pivot;
    public int maxLevel , count;
    public static GroundSpawner instance;
    public bool Check;
    public GameObject groundEndPos;
    public float posLast , posFirst;
    private float posAxis = -80;    

    private void Awake()
    {
        instance = this;
        pivot = GameObject.FindGameObjectWithTag("PivotGround").transform;

        for (int i = 0; i < maxLevel; i++)
        {
           
            var gr = Instantiate(Grounds[Random.Range(0, Grounds.Length)], pivot.position, pivot.rotation);
            gr.SetParent(pivot);
            groundSpawned.Add(gr);
            groundSpawned[i].transform.localPosition = new Vector3(0, 0, posAxis);            
            posAxis += 35;
            if (i == 0)
            {
                gr.GetChild(0).GetChild(0).gameObject.SetActive(false);
                gr.GetComponent<SpawnRandomTarget>().SpawnedTarget = null;                
            }
        }
        count += 3;              
    }   
    private void Update()
    {
        if (count < maxLevel)
        {
            groundSpawned[count].gameObject.SetActive(true);
            posLast = groundSpawned[count].position.z;
        }       
        if (Check)
        {
            count++;                     
            groundEndPos.gameObject.SetActive(false);
            posFirst = posLast;
            Check = false;
        }
        if (count >= maxLevel)
        {
            count = 0;
        }       
       
    }
}
