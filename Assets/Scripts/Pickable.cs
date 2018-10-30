using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour {

    public bool picked;
    public bool red;
    public bool blue;
    public bool green;
    public int canShootRed;
    public int canShootBlue;
    public int canShootGreen;

    private Gun1 m_gun;

    

    private void Start()
    {
        m_gun = FindObjectOfType<Gun1>();
        
    }

    public void BePicked(Transform newParent)
    {
        picked = true;
        StartCoroutine(HandlePick(newParent));
       
    }

    IEnumerator HandlePick(Transform newParent)
    {
        yield return new WaitForSeconds(1.5f);
        transform.parent = newParent;
        transform.localPosition = Vector3.zero;

        yield return new WaitForSeconds(3.0f);
        Destroy(gameObject);
    }

    //parent object

    //destroy object

}
