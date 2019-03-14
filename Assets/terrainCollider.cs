using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("can hit the terrain");
        if (other.gameObject.name == "Terrain")
        {
            Debug.Log("can hit the terrain");
        }
    }
}
