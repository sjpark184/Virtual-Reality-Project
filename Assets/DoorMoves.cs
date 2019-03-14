using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMoves : MonoBehaviour
{

    public Transform door1;
    public Transform door2;
    private bool open;

    private float timer;

    private void Start()
    {
        open = false;
        timer = 5.1f;
    }

    public void openDoor()
    {
        if (!open)
        {
            timer = 0.0f;
            open = true;
        }
        Debug.Log("message received");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer < 5.0 && open)
        {
            door1.position = new Vector3(door1.position.x, door1.position.y, door1.position.z + 0.005f);
            door2.position = new Vector3(door2.position.x, door2.position.y, door2.position.z - 0.005f);
        }
        if(5.01 < timer && timer <= 20 && open)
        {
            Debug.Log("waiting to close" + timer);
        }
        if(20.01 < timer && timer <= 25.0 && open)
        {
            door1.position = new Vector3(door1.position.x, door1.position.y, door1.position.z - 0.005f);
            door2.position = new Vector3(door2.position.x, door2.position.y, door2.position.z + 0.005f);
        }
        if (timer > 25.1) {
            open = false;
        }
    }
}