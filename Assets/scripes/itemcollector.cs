using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemcollector : MonoBehaviour
{
    private int counter = 0;

    [SerializeField] private Text CherriesCnt;
    [SerializeField] private AudioSource collectsound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            collectsound.Play();
            Destroy(collision.gameObject);
            counter++;
            CherriesCnt.text = "Cherries:" + counter;
        }
    }
}
