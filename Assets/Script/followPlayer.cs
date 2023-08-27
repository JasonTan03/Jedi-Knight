using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public float cameraSpeed;
    public float heightOffSet;
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        Vector3 followPlayer = new Vector3(player.position.x, player.position.y + heightOffSet, -10f);
        transform.position = Vector3.Slerp(transform.position, followPlayer, cameraSpeed * Time.deltaTime);
    }
}
