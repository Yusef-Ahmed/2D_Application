using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class itemcollector : MonoBehaviour
{
    public static int counter = 7;
    [SerializeField] private Text CherriesCnt;
    [SerializeField] private AudioSource collectsound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            collectsound.Play();
            Destroy(collision.gameObject);
            counter=Math.Max(counter-1,0);
            CherriesCnt.text = "Required:" + counter;
        }
    }
}
