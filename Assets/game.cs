using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game : MonoBehaviour
{
    GameObject[] bowl;
    GameObject[] bottle;
    GameObject[] beer;
    GameObject[] apple;
    GameObject[] chips;
    GameObject[] yogurt;
    GameObject[] can;
    GameObject[] meat;
    GameObject[] sprayBottle;
    //GameObject[] bottleWaste;
    //GameObject[] beerWaste;
    //GameObject[] appleWaste;
    //GameObject[] chipsWaste;
    //GameObject[] yogurtWaste;
    //GameObject[] canWaste;
    //GameObject[] meatWaste;
    //GameObject[] sprayBottleWaste;
    AudioSource musicSource;
    public AudioClip musicClip;
    public Text screen;
    public Text tutorialScipt;
    public int price = 0;
    public int bottleCounter = 0, beerCounter = 0, appleCounter = 0, chipsCounter = 0, yogurtCounter = 0, canCounter = 0, meatCounter = 0, sprayBottleCounter = 0;
    public static int totalCounter = 0;
    public Renderer water;
    private bool airPol = false, waterPol = false, landPol = false;
    void Start()
    {
        //put grocery objects into an array "x" and start the x settings
        bowl = GameObject.FindGameObjectsWithTag("bowl");
        bottle = GameObject.FindGameObjectsWithTag("bottle");
        beer = GameObject.FindGameObjectsWithTag("beer");
        apple = GameObject.FindGameObjectsWithTag("apple");
        chips = GameObject.FindGameObjectsWithTag("chips");
        yogurt = GameObject.FindGameObjectsWithTag("yogurt");
        can = GameObject.FindGameObjectsWithTag("can");
        meat = GameObject.FindGameObjectsWithTag("meat");
        sprayBottle = GameObject.FindGameObjectsWithTag("sprayBottle");

        //bottleWaste = GameObject.FindGameObjectsWithTag("bottleWaste");
        //beerWaste = GameObject.FindGameObjectsWithTag("beerWaste");
        //appleWaste = GameObject.FindGameObjectsWithTag("appleWaste");
        //chipsWaste = GameObject.FindGameObjectsWithTag("chipsWaste");
        //yogurtWaste = GameObject.FindGameObjectsWithTag("yogurt");
        //canWaste = GameObject.FindGameObjectsWithTag("canWaste");
        //meatWaste = GameObject.FindGameObjectsWithTag("meatWaste");
        //sprayBottleWaste = GameObject.FindGameObjectsWithTag("sprayBottleWaste");
        musicSource.clip = musicClip;
    }

    //void ontriggerstay(collider other)
    //{
    //    if (other.transform.tag == "bowl")
    //    {
    //        debug.log("bowl is placed on the counter");
    //    }
    //    if (other.transform.tag == "bottle")
    //    {
    //        debug.log("bottle is placed on the counter");
    //    }
    //    if (other.transform.tag == "beer")
    //    {
    //        debug.log("beer is placed on the counter");
    //    }
    //    if (other.transform.tag == "apple")
    //    {
    //        debug.log("apple is placed on the counter");
    //    }
    //    if (other.transform.tag == "chips")
    //    {
    //        debug.log("chips is placed on the counter");
    //    }
    //    if (other.transform.tag == "yogurt")
    //    {
    //        debug.log("yogurt is placed on the counter");
    //    }
    //    if (other.transform.tag == "can")
    //    {
    //        debug.log("can is placed on the counter");
    //    }
    //    if (other.transform.tag == "meat")
    //    {
    //        debug.log("meat is placed on the counter");
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "bottle")
        {
            bottleCounter++;
        }
        if (other.transform.tag == "beer")
        {
            beerCounter++;
        }
        if (other.transform.tag == "apple")
        {
            appleCounter++;
        }
        if (other.transform.tag == "chips")
        {
            chipsCounter++;
        }
        if (other.transform.tag == "yogurt")
        {
            yogurtCounter++;
        }
        if (other.transform.tag == "can")
        {
            canCounter++;
            Debug.Log(canCounter);
        }
        if (other.transform.tag == "meat")
        {
            meatCounter++;
        }
        if (other.transform.tag == "sprayBottle")
        {
            sprayBottleCounter++;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "bottle")
        {
            bottleCounter--;
        }
        if (other.transform.tag == "beer")
        {
            beerCounter--;
        }
        if (other.transform.tag == "apple")
        {
            appleCounter--;
        }
        if (other.transform.tag == "chips")
        {
            chipsCounter--;
        }
        if (other.transform.tag == "yogurt")
        {
            yogurtCounter--;
        }
        if (other.transform.tag == "can")
        {
            canCounter--;
        }
        if (other.transform.tag == "meat")
        {
            meatCounter--;
        }
        if (other.transform.tag == "sprayBottle")
        {
            sprayBottleCounter--;
        }
    }

    void Update()
    {
        tutorial();
        if (bottleCounter != 0 || beerCounter != 0 || appleCounter != 0
            || chipsCounter != 0 || yogurtCounter != 0 || canCounter != 0 || sprayBottleCounter != 0)
            screen.text = "bottle:  " + bottleCounter.ToString() + "\n"
                        + "beer:    " + beerCounter.ToString() + "\n"
                        + "apple:   " + appleCounter.ToString() + "\n"
                        + "chips:   " + chipsCounter.ToString() + "\n"
                        + "yogurt:  " + yogurtCounter.ToString() + "\n"
                        + "can:     " + canCounter.ToString() + "\n"
                        + "meat:    " + meatCounter.ToString() + "\n" 
                        + "spray bottle: " + sprayBottleCounter.ToString() + "\n";
        else
            screen.text = "WELCOME TO GUILT!\n Grab an item and place it on the checkout \n to see how it will affect the environment!\n";
        totalCounter = bottleCounter + beerCounter + appleCounter + chipsCounter + yogurtCounter + canCounter + meatCounter + sprayBottleCounter;
        if (beerCounter > 0)
        {
            startSmog();
            airPol = true;
        }
        if (canCounter > 0 || chipsCounter > 0)
        {
            spawnCans();
            landPol = true;
        }
        if (appleCounter > 0)
        {
            waterPollution();
            waterPol = true;
        }
    }
    void startSmog()
    {

    }
    void spawnCans()
    {

    }
    void waterPollution()
    {
        water.material.shader = Shader.Find("FX/Water");
        water.material.SetColor("_RefrColor", Color.green);
        //Debug.Log("Hello");
    }

    void tutorial()
    {
        if (totalCounter == 0)
            tutorialScipt.text = "Move around with a left touch pad joystick. \ngrab an item using any hand triggers and place it on the checkout station.";
        if(1 <= totalCounter && totalCounter<4)
            tutorialScipt.text = "place at least four items on the checkout station";
        if(4 <= totalCounter)
            tutorialScipt.text = "press button A on right touch pad to checkout";
        if (playerScript.checkout)
        {
            /*tutorialScipt.text = "you have purchased:" + ((bottleCounter > 0) ? "\nbottle" : "") + ((beerCounter > 0) ? "\nbeer" : "") + ((appleCounter > 0) ? "\napple" : "")
                                + ((chipsCounter > 0) ? "\nchips" : "") + ((yogurtCounter > 0) ? "\nyogurt" : "") + ((canCounter > 0) ? "\ncan" : "")
                                + ((meatCounter > 0) ? "\nmeat" : "") + ((sprayBottleCounter > 0) ? "\nspray bottle." : "" + "\n They have caused following pollutions: . You can go outside and pick up trash"); */

            tutorialScipt.text = "The following items have caused the following pollutions: " + ((airPol && landPol && waterPol) ? "air pollution, land pollution, and water pollution.": "") +
                                    ((airPol && landPol && !waterPol) ? "air pollution and land pollution." : "") +
                                    ((airPol && !landPol && waterPol) ? "air pollution and water pollution." : "") +
                                    ((!airPol && landPol && waterPol) ? "land pollution and water pollution." : "") +
                                    ((airPol && !landPol && !waterPol) ? "air pollution." : "") +
                                    ((!airPol && landPol && !waterPol) ? "land pollution." : "") +
                                    ((!airPol && !landPol && waterPol) ? "water pollution." : "") + "\nPlease go outside by standing on the door mat. And help picking up the cans and clean environment";
        }
    }
}
