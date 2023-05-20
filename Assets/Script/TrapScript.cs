using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    public int damageTrap;
    private BoxCollider2D trapCollider;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Cek apakah yang masuk collider adalah player
        if (other.CompareTag("Player"))
        {
            // Ambil komponen Health pada player

             other.GetComponent<HealtBar>().LoseHealth(damageTrap);
            

        }
        else if (trapCollider.isTrigger)
        {
            Debug.Log("Trap");
            other.GetComponent<HealtBar>().LoseHealth(damageTrap);
        }
    }
}
