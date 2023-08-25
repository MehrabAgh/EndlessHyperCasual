using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : StateMachineBehaviour
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.normalizedTime > .12f)
        {
            if (GameManagment.instance.lp.ThisObject)
            {
                GameManagment.instance.lp.ThisObject.transform.SetParent(null);
                GameManagment.instance.lp.Launch();
               
            }
        }
    }
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameManagment.instance._isShooted = true;
    }
}
