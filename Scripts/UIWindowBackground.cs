// =======================================================================================
// UIWindowBackground
// by Weaver (Fhiz)
// MIT licensed
// =======================================================================================

using UnityEngine;
using System.Collections;

public class UIWindowBackground : MonoBehaviour 
{

    [SerializeField] protected Animator animator;
    [SerializeField] protected string fadeInTriggerName = "fadeIn";
    [SerializeField] protected string fadeOutTriggerName = "fadeOut";

    public void FadeIn()
    {
        animator.SetTrigger(fadeInTriggerName);
    }

    public void FadeOut()
    {
        animator.SetTrigger(fadeOutTriggerName);
    }
}