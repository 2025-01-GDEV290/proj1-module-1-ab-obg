using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggScrpit : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        //animator.SetBool("AFK", true);
    }

    void Update()
    {
        
    }

    private void OnMouseUpAsButton()
    {
        animator.SetTrigger("Left Click");
    }

}
