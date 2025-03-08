using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    //for 2D PlayerMovement
    [SerializeField]
    private GameObject cube;

    private float speed = 10;
    public Vector2 jumpHeight; //is set to 5 in inspector
    private bool _isGrounded = false;
    private int lMask;

    void Start()
    {
        lMask = LayerMask.GetMask("RaycastLayer");
        Debug.Log("Layer mask number: " + lMask);
    }
    void Update()
    {
        RaycastHit2D res = Physics2D.Raycast(transform.position, Vector2.down, 1.5f, lMask); //this is if the player is 1u tall
        Debug.Log("RaycastHit2D: " + res.collider);
        if (res.collider != null)
            {
                _isGrounded = true;
                Debug.Log("Player is Grounded: " + _isGrounded);
            }
        else
            {
                _isGrounded = false;
                Debug.Log("Player is Grounded: " + _isGrounded);
            } 
        if (Input.GetKey(KeyCode.D))
            {
                GetComponent<Transform>().position += transform.right * speed * Time.deltaTime;
                Debug.Log("KeyCodeD");
            }
        if (Input.GetKey(KeyCode.A))
            {
                GetComponent<Transform>().position -= transform.right * speed * Time.deltaTime;
                Debug.Log("KeyCodeA");
            }
        if (_isGrounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)))
            {
                GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
                Debug.Log("KeyCode W or Space");
            }
        else if (!_isGrounded)
            {
                Debug.Log("Player is Grounded: " +_isGrounded);
            }
    }
}
