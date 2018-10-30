using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour {

    public Material[] material; //array of materials

    Renderer rend;

    

	// Use this for initialization
	void Start () {

        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];

	}

    public void ColourRed()
    {
        rend.sharedMaterial = material[1];
        
    }

    public void ColourBlue()
    {
        rend.sharedMaterial = material[2];
        
    }
    public void ColourGreen()
    {
        rend.sharedMaterial = material[3];
      
    }

    
}
