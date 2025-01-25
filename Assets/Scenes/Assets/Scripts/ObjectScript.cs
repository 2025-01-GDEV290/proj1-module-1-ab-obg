using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    private Animator animator;
    private Vector3 afk_mouse_position;

    public float timer = 0f;
    public bool afk = false;

    public int hit_counter = 0;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.mousePosition == afk_mouse_position)
        {
            timer += Time.deltaTime;

            if (timer > 5f)
            {
                afk = true;
                animator.SetBool("AFK", true);
            }
        } else
        {
            afk = false;
            animator.SetBool("AFK", false);
            timer = 0f;
        }

        afk_mouse_position = Input.mousePosition;
    }

    private void OnMouseUpAsButton()
    {
        hit_counter += 1;
    }
}
