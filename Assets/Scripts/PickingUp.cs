using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingUp : StateMachineBehaviour
{        
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameManagment.instance.lp.ThisObject.transform.SetParent(GameManagment.instance.player.HandPivot);
        GameManagment.instance.lp.ThisObject.transform.localPosition = Vector3.zero;
    }  
}
