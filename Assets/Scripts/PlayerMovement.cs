using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour
{
    public float speed;
    private void FixedUpdate()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        Vector2 move;
        move.x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        move.y = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.Translate(move);
    }
}
