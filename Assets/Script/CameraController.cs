using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] float xOffset;
    [SerializeField] float yOffset;
    [SerializeField] protected float followspeed = 2f;
    [SerializeField] protected bool isXLocked = false;
    [SerializeField] protected bool isYLocked = false;
    void Update()
    {
        float xTarget = player.position.x + xOffset;
        float yTarget = player.position.y + yOffset;

        float xAxis = transform.position.x;
        if (!isXLocked)
        {
            xAxis = Mathf.Lerp(transform.position.x, xTarget, Time.deltaTime * followspeed);
        }
        float yAxis = transform.position.y;
        if (!isYLocked)
        {
            yAxis = Mathf.Lerp(transform.position.y, yTarget, Time.deltaTime * followspeed);
        }
        transform.position = new Vector3(xAxis, yAxis, transform.position.z);
    }
}
