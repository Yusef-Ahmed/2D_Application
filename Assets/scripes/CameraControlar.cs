using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlar : MonoBehaviour
{
    [SerializeField] private Transform player;
    private void Update()
    {
        // camera move with the player
        transform.position=new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
