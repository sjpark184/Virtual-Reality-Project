using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour {
    public GameObject door;
    public static bool checkout;

    private void Start()
    {
        checkout = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "doorMat" && game.totalCounter >= 1 /*&& game.totalCounter >= 4*/)
        {
            Debug.Log("IM ON THE MAT");
            door.SendMessage("openDoor");
        }
    }
    private void Update()
    {

        if (OVRInput.GetDown(OVRInput.RawButton.A))// && game.totalCounter>=4)
        {
            Debug.Log("checkout done");
            checkout = true;
        }
        if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
		        Application.Quit ();
            #endif
        }
    }
}
