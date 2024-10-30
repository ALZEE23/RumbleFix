using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class turnbase : MonoBehaviour
{
    public player Player;
    public GameObject ui1;
    public GameObject ui2;
    public bool flip;
    //public GameObject ui2;
    //public GameObject ui3;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           Player = Player.GetComponent<player>();
           Player.turnbase = true;
            Player.flipping = flip;

           ui1.SetActive(true);
           ui2.SetActive(true);
        }
    }
}
