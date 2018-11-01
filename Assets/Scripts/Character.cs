using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    private float deltaX;
    private Quaternion spineRotation;
    private bool m_aim;

    //public UnityEvent OnFire;

   private Animator m_animator;
   private bool m_picked;

    private bool m_enableIK;
    private float m_weightIK;
    private Vector3 m_positionIK;
    public float delay = 5;

    public ZombieController m_zombie; //zombie script 
   


    // Use this for initialization
    void Start()
    {
        // Initialize Animator
        m_animator = GetComponent<Animator>();

        m_zombie = FindObjectOfType<ZombieController>();

        



    }

    public void Update()
    {
        if (m_zombie.playerHealth == 0 )
        {
            m_animator.SetTrigger("Die");
            StartCoroutine(LoadLevelAfterDelay(delay));
        }
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(0);
    }

    public void Move(float turn, float forward, bool jump, bool picked)
    {
        m_animator.SetFloat("Turn", turn);
        m_animator.SetFloat("Forward", forward);

        m_picked = picked;

        if (jump)
        {
            m_animator.SetTrigger("Jump");
        }

    }

   
   public void Shoot(bool fire)
    {
        m_animator.SetTrigger("Fire");
    }
    

    private void OnTriggerStay(Collider other)
    {
        var pickable = other.GetComponent<Pickable>();
        // use var when the type is exlpained somewhere else. Big types

        if(m_picked && pickable != null && !pickable.picked)
        {
            //do the thing
            Debug.Log("Picking");
            Transform rightHand = m_animator.GetBoneTransform(HumanBodyBones.RightHand);
            pickable.BePicked(rightHand);
            

            m_animator.SetTrigger("Pick");

            StartCoroutine(UpdateIK(other));
            
        }
    }

    private IEnumerator UpdateIK (Collider other)
    {
        m_enableIK = true;

        while(m_enableIK)
        {
            m_positionIK = other.transform.position;
            m_weightIK = m_animator.GetFloat("IK");
            yield return null;
        }
    }

    public void DisableIK()
    {
        m_enableIK = false;
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if(m_enableIK)
        {
            m_animator.SetIKPosition(AvatarIKGoal.RightHand,m_positionIK);
            m_animator.SetIKPositionWeight(AvatarIKGoal.RightHand, m_weightIK);
        }

        if(m_aim)
        {
            // do spine rotation
            Vector3 rotationEuler = new Vector3(0, deltaX, 0);
            Quaternion rotationOffSet = Quaternion.EulerAngles(rotationEuler);
            spineRotation = Quaternion.Lerp(spineRotation, spineRotation * rotationOffSet, Time.deltaTime * 50.0f);

            rotationEuler = spineRotation.eulerAngles;
            
            if(rotationEuler.y > 180)
            {
                rotationEuler.y -= 360;
            }

            if (rotationEuler.y < 180)
            {
                rotationEuler.y += 360;
            }

            rotationEuler.y = Mathf.Clamp(rotationEuler.y, -60.0f, +60.0f);

            m_animator.SetBoneLocalRotation(HumanBodyBones.Spine, Quaternion.EulerRotation(rotationEuler));
        }
    }

   

}
