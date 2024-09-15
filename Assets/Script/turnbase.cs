using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class turnbase : MonoBehaviour
{
    public player Player;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           Player = Player.GetComponent<player>();
           Player.turnbase = true;
        }
    }
}
