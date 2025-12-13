using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FirstPersonControllerScript : MonoBehaviour
{
    public Vector3 moveDirection;
    public float speed;
    public float jump;

    public bool itemHeld;
    public Transform cameraPosition;
    public Rigidbody rigidBody;

    public LayerMask groundMask;

    // Start is called before the first frame update
    void Start()
    {
        cameraPosition = GameObject.Find("Main Camera").transform;
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(x, 0, z);
        transform.Translate(speed * Time.deltaTime * moveDirection);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rigidBody.AddForce(jump * Vector3.up, ForceMode.Impulse); // Impuse makes AddForce take the mass of the rb into account.
        }
    }

    bool IsGrounded()
    {
        if (Physics.Raycast(transform.position - new Vector3(0, 0.9f, 0), Vector3.down, out RaycastHit hit, 0.2f, groundMask)) 
        {
            return hit.collider.gameObject.CompareTag("Ground");
        }
        return false;    
    }
}
