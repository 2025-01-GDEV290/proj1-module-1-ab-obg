using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    public GameObject Egg;
    public GameObject Duck;

    private Animator animator;
    private Vector3 afk_mouse_position;

    private AudioSource audio_source;
    public AudioClip pop;

    public ParticleSystem particle_click;

    public float timer = 0f;
    public bool afk = false;

    public int hit_counter = 0;
    public GameObject random_crack;
    public GameObject random_crack_2;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audio_source = GetComponent<AudioSource>();

        

        random_crack.transform.rotation = Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
        random_crack_2.transform.rotation = Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
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
        animator.SetBool("Clicked", true);
        animator.SetTrigger("Click");
        animator.SetInteger("Click Amount", hit_counter);
    }

    private void OnMouseEnter()
    {
        animator.SetBool("Hover", true);
    }

    private void OnMouseExit()
    {
        animator.SetBool("Hover", false);
    }

    public void play_effect()
    {
        particle_click.Play();

        //Sound effect
        audio_source.clip = pop;
        audio_source.Play();

        random_crack.SetActive(true);

        if (hit_counter > 1)
        {
            random_crack_2.SetActive(true);
        }
    }

    public void on_break()
    {
        Egg.SetActive(false);
        Duck.SetActive(true);
    }
}
