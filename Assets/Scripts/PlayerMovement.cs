using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour
{
    public float health = 1f;
    //public Transform CameraPoint;
    public float speed;
    public int id;

    private void Start()
    {
        FindObjectOfType<PlayersManager>().players++;
        id = FindObjectOfType<PlayersManager>().players;
    }

    private void FixedUpdate()
    {
        if (health <= 0f)
        {
            Destroy(gameObject);
        }
        if (!isLocalPlayer)
        {
            return;
        }
        Vector2 move;
        move.x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        move.y = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        GetComponent<Rigidbody2D>().MovePosition(move + new Vector2(transform.position.x, transform.position.y));


        // look at mouse

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x,
                mousePosition.y - transform.position.y);
        transform.up = direction;

        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    CameraPoint.Rotate(0f, 0f, 200f * Time.deltaTime);
        //    transform.Rotate(0f, 0f, -200f * Time.deltaTime);
        //}
        //else if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    CameraPoint.Rotate(0f, 0f, -200f * Time.deltaTime);
        //    transform.Rotate(0f, 0f, 200f * Time.deltaTime);
        //}

    }
}
