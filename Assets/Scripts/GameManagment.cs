using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManagment : MonoBehaviour
{
    public bool _EndGame, _isAttack, _isShooted;
    public Transform GroundCurrent;
    public List<Transform> TargetsCurrent;
    public PlayerController player;
    public static GameManagment instance;
    public Transform t , destroyTargets;
    public Color[] colors;
    public launchingProjectiles lp;
    private void Awake()
    {
        instance = this;
    }
    Transform GetClosestTargets(List<Transform> targets, Transform fromThis)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = fromThis.position;
        foreach (Transform potentialTarget in targets)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
        return bestTarget;
    }
    private Transform SetTarget()
    {
        var p = GroundCurrent.GetComponentInParent<SpawnRandomTarget>();
        if (p != null)
        {
            p.EnableTargets();
            TargetsCurrent = p.SpawnedTarget;
        }
        return GetClosestTargets(TargetsCurrent, transform);
    }
    private void MainAttacking()
    {
      
        lp = player.GetComponent<launchingProjectiles>();
        lp.ThisObject = player.playerAttack.SpawnedAmmo[player.playerAttack.ammoCount];     
        lp.SetValueAttack();
        player.playerAttack.SpawnedAmmo[player.playerAttack.ammoCount].GetComponent<Rigidbody>().isKinematic = false;
        player.playerAttack.Attacking(t, player._anim);
        lp.TargetObject = t;
    }

    private void Update()
    {
        if (_EndGame)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;

            if (_isAttack)
            {                
                if (TargetsCurrent != null)
                {                   
                    t = SetTarget();
                    if (TargetsCurrent.Count <= 0)
                    {
                        foreach (Transform item in destroyTargets)
                        {
                            if(item != null)
                            Destroy(item.gameObject);
                        }
                        _isAttack = false;
                    }
                    MainAttacking();
                    
                }
               
            }
            else
            {
                player.playerAttack.DefaultRotation(player._anim);
            }
        }

    }
}
