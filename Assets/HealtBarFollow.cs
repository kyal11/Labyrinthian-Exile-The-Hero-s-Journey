using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtBarFollow : MonoBehaviour
{
    public Transform monsterTransform;  // Referensi transform dari monster

    void LateUpdate()
    {
        // Atur posisi health bar sesuai dengan posisi monster
        transform.SetPositionAndRotation(monsterTransform.position, Quaternion.identity);
    }
}
