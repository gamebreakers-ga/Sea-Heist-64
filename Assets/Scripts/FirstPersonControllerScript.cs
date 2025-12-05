using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FirstPersonControllerScript : MonoBehaviour
{
    public Vector3 moveDirection;
    public float speed;
    public float jump;

    public LayerMask groundMask;

    public bool itemHeld;
    public GameObject currentItem;
    public Transform cameraPosition;
    public LayerMask interactMask;
    public LayerMask EnemyLayer;

    public Rigidbody rigidBody;

    public float throwPower;
    public float throwMultiplier;
    public Slider powerMeter;

    // Start is called before the first frame update
    void Start()
    {
        cameraPosition = GameObject.Find("Main Camera").transform;
        rigidBody = GetComponent<Rigidbody>();
        powerMeter.gameObject.SetActive(false);
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

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Physics.SphereCast(transform.position, 20f, Vector3.forward, out RaycastHit hit))
            {
                
                if (hit.collider.gameObject.layer == 7)
                {

                }
            }
        }

        powerMeter.value = throwPower;

        if (Input.GetKeyDown(KeyCode.E) && itemHeld)
        {
            throwPower = 0;
            powerMeter.gameObject.SetActive(true);
        }
        if (Input.GetKey(KeyCode.E) && itemHeld)
        {
            throwPower = Mathf.PingPong(Time.time, 1);
        }
        if (Input.GetKeyUp(KeyCode.E) && itemHeld)
        {
            itemHeld = false;
            currentItem.GetComponent<HolderScript>().isHeld = false;
            currentItem.GetComponent<Rigidbody>().useGravity = true;
            currentItem.GetComponent<Rigidbody>().AddForce(throwMultiplier * throwPower * cameraPosition.forward, ForceMode.Impulse);
            currentItem = null;
            powerMeter.gameObject.SetActive(false);
            throwPower = 0;
        }


        pickup();
    }

    bool IsGrounded()
    {
        if (Physics.Raycast(transform.position - new Vector3(0, 0.9f, 0), Vector3.down, out RaycastHit hit, 0.2f, groundMask)) 
        {
            return hit.collider.gameObject.CompareTag("Ground");
        }
        return false;    
    }

    void pickup()
    {
        if (Input.GetKeyDown(KeyCode.F))       
        {
            if (!itemHeld)
            {
                if (Physics.Raycast(cameraPosition.position, cameraPosition.forward, out RaycastHit reach, 1.5f, interactMask))
                {
                    itemHeld = true;
                    currentItem = reach.collider.gameObject;
                    currentItem.GetComponent<HolderScript>().isHeld = true;
                    currentItem.GetComponent<Rigidbody>().useGravity = false;
                }
            }
            else
            {
                itemHeld = false;
                currentItem.GetComponent<HolderScript>().isHeld = false;
                currentItem.GetComponent<Rigidbody>().useGravity = true;
                currentItem = null;
            }
        }


    }
}
