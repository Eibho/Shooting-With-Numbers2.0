using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun1 : MonoBehaviour {
    public float range = 1000f; //if player is whithin range it will hit
    public GameObject bulletPoint; //where the raycast will shoot from
    private bool m_fire;
    private Character m_character;
    private ZombieController m_zombie;


    private void Start()
    {
        m_character = GetComponent<Character>();
        m_zombie = FindObjectOfType<ZombieController>();
    }

    // Update is called once per frame
    void Update () {



        if (Input.GetButtonDown("1"))
        {

            m_character.Shoot(m_fire);
            ShootRed();
            ShootZombie();
            
        }

        if (Input.GetButtonDown("2"))
        {
            m_character.Shoot(m_fire);
            ShootBlue();

        }

        if (Input.GetButtonDown("3"))
        {
            m_character.Shoot(m_fire);
            ShootGreen();
            
        }
	}

    void ShootRed()
    {
       

        RaycastHit hit;
        if (Physics.Raycast(bulletPoint.transform.position, bulletPoint.transform.forward, out hit, range)) //(position of bullet point,forward from bullet point position, shoot, within certain range)
        {
            Debug.Log(hit.transform.name);


            ChangeMaterial changeMaterial = hit.transform.GetComponent<ChangeMaterial>();


            if (changeMaterial != null)
            {

                changeMaterial.ColourRed();
            }


        }
    }
    void ShootBlue()
    {
        RaycastHit hit;
        if (Physics.Raycast(bulletPoint.transform.position, bulletPoint.transform.forward, out hit, range)) //(position of bullet point,forward from bullet point position, shoot, within certain range)
        {
            Debug.Log(hit.transform.name);


            ChangeMaterial changeMaterial = hit.transform.GetComponent<ChangeMaterial>();


            if (changeMaterial != null)
            {

                changeMaterial.ColourBlue();
            }


        }
    }

    void ShootGreen()
    {
        RaycastHit hit;
        if (Physics.Raycast(bulletPoint.transform.position, bulletPoint.transform.forward, out hit, range)) //(position of bullet point,forward from bullet point position, shoot, within certain range)
        {
            Debug.Log(hit.transform.name);


            ChangeMaterial changeMaterial = hit.transform.GetComponent<ChangeMaterial>();
            

            if (changeMaterial != null)
            {
                
                changeMaterial.ColourGreen();
            }

           
        }
    }

    void ShootZombie()
    {
        RaycastHit hit;
        if (Physics.Raycast(bulletPoint.transform.position, bulletPoint.transform.forward, out hit, range)) //(position of bullet point,forward from bullet point position, shoot, within certain range)
        {
            Debug.Log(hit.transform.name);
            

            if (m_zombie != null)
            {
                m_zombie.zombieHealth = m_zombie.zombieHealth - 1;
                Debug.Log(m_zombie.zombieHealth);

               
                
            }


        }
    }

}
