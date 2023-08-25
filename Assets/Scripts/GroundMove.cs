using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    public Transform pointEnd, pointStart;
    private float dist;
    [SerializeField] private float maxDist;
    public bool Not;
    [SerializeField] private float speed;
    private void Awake()
    {
        pointEnd = GameObject.Find("pointEnd").transform;
        if(!Not)
        transform.localPosition = new Vector3(0, 0, GroundSpawner.instance.posLast - 45);
    }   
    public IEnumerator up(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);

            if (!GameManagment.instance._EndGame && !GameManagment.instance._isAttack)
            {
                transform.position += -Vector3.forward * speed;
                dist = Vector3.Distance(pointStart.position, pointEnd.position);
                if (dist <= maxDist)
                {
                    GroundSpawner.instance.Check = true;
                    GroundSpawner.instance.groundEndPos = gameObject;
                }
            }
        }
    }
    private void OnDisable()
    {
        transform.localPosition -= new Vector3(0, 0, transform.localPosition.z);       
    }
    private void OnEnable()
    {        
        StartCoroutine(up(0.01f));
    }
}