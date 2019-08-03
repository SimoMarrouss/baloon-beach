using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float distanceFromPlayer = 10;

    void LateUpdate()
    {
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position,
            new Vector3(0, transform.position.y,player.transform.position.z - distanceFromPlayer), Time.deltaTime * 100);
    }
}
