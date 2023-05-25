using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int Heal;
    private BoxCollider2D itemCollider;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Cek apakah yang masuk collider adalah player
        if (other.CompareTag("Player"))
        {
            // Ambil komponen Health pada player

            other.GetComponent<HealtBar>().Healing(Heal);
            Destroy(gameObject, 0f);

        }
        
    }
}
