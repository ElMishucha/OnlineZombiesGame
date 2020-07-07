using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour
{
    public Camera camera;
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
        
        if (!isLocalPlayer)
        {
            return;
        }
        if (health <= 0f)
        {
            Destroy(gameObject);
        }
        Vector2 move;
        move.x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        move.y = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        GetComponent<Rigidbody2D>().MovePosition(move + new Vector2(transform.position.x, transform.position.y));
        GetComponent<Rigidbody2D>().MovePosition(move + new Vector2(transform.position.x, transform.position.y));
        //Camera.main.transform.position = new Vector2(Mathf.Lerp(Camera.main.transform.position.x, transform.position.x, Time.deltaTime * 5f),
        //    Mathf.Lerp(Camera.main.transform.position.y, transform.position.y, Time.deltaTime * 5f));
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10f);

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
