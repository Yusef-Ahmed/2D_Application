using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class itemcollector : MonoBehaviour
{
    public static int counter = 7;
    [SerializeField] private Text CherriesCnt; // required text above in the game
    [SerializeField] private AudioSource collectsound; // Collect cherry's sound

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            collectsound.Play(); // play sound
            Destroy(collision.gameObject); // the cheery disabear
            counter=Math.Max(counter-1,0); // counter minimiz but don't go blow zero
            CherriesCnt.text = "Required:" + counter;
        }
    }
}
