using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomTarget : MonoBehaviour
{
    [SerializeField] private List<GameObject> Targets;
    public List<Transform> SpawnedTarget;
    public int MaxTarget;
    [SerializeField] private Vector3 MinPosition, MaxPosition;
    private bool _accSpawn;
    private int numberGuess;

    private void Update()
    {
        if(SpawnedTarget != null)
        SpawnedTarget.RemoveAll(item => item == null);
    }
    private void Spawn(int maximum)
    {
        for (int i = 0; i < maximum; i++)
        {
            var t = Instantiate(Targets[Random.Range(0, Targets.Count)], Vector3.zero, Quaternion.identity, transform);
            t.transform.localPosition = new Vector3(Random.Range(MinPosition.x, MaxPosition.x), Random.Range(MinPosition.y, MaxPosition.y), Random.Range(MinPosition.z, MaxPosition.z));            
            SpawnedTarget.Add(t.transform);
            t.SetActive(false);
        }
    }
    public void EnableTargets()
    {
        foreach (var item in SpawnedTarget)
        {
            item.gameObject.SetActive(true);
        }
    }
    private void OnEnable()
    {
        numberGuess = Random.Range(0 , 4);
        if((numberGuess%2) == 0)
        {
            _accSpawn = true;
        }
        else
        {
            _accSpawn = false;
        }

        if (SpawnedTarget == null || SpawnedTarget.Count <= 0 && _accSpawn)
            Spawn(MaxTarget);
    }

}
