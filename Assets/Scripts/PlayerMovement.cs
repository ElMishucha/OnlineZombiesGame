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

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0f, 0f, -200f * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0f, 0f, 200f * Time.deltaTime);
        }
    }
}
