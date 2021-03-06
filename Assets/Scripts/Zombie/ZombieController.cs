﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ZombieController : MonoBehaviour
{

    public Transform player;

    public int playerHealth;
    public int zombieHealth;
    float destroyTime;

  //public AudioClip m_idle;
  //public AudioClip m_walk;
  //public AudioClip m_die;


    private Animator m_anim; 
     Character m_character;
  //private AudioSource m_audioSource;


    // Use this for initialization
    public void Start()
    {
        m_anim = GetComponent<Animator>();
     // m_audioSource = GetComponent<AudioSource>();

        playerHealth = 3;

        zombieHealth = 3;
    }


    // Update is called once per frame
    void Update()
    {
        Die();

            if (Vector3.Distance(player.position, this.transform.position) < 10)
            {
                Vector3 direction = player.position - this.transform.position;
                direction.y = 0;

                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

                m_anim.SetBool("Walk", false);

         // m_audioSource.PlayOneShot(m_idle);


                if (direction.magnitude > 2)
                {
                    this.transform.Translate(0, 0, 0.01f);
                    m_anim.SetBool("Walk", true);
                    m_anim.SetBool("Attack", false);

           //   m_audioSource.Pause();
            //  m_audioSource.PlayOneShot(m_walk);
                
            }

                if (direction.magnitude <= 2)
                {
                    m_anim.SetBool("Walk", false);
                    m_anim.SetBool("Attack", true);


                    playerHealth = playerHealth - 1;

                    Debug.Log(playerHealth);

                


            }


            }
       
    }

    void Die()
    {
        destroyTime = 2;

        if (zombieHealth == 0)
        {
            m_anim.SetTrigger("Die");

          //m_audioSource.Stop();
          //m_audioSource.PlayOneShot(m_die);

            Destroy(gameObject, destroyTime);
        }
    }


}
