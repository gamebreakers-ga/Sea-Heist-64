using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolderScript : MonoBehaviour
{
    public bool isHeld;
    public Transform HolderPosition;
    public GMScript gm;
    // Start is called before the first frame update
    void Start()
    {
        HolderPosition = GameObject.Find("Holder").transform;
        gm = GameObject.Find("GameManager").GetComponent<GMScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isHeld)
        {
            transform.position = HolderPosition.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            gm.Score++;
            Destroy(collision.gameObject);
        } else if (collision.gameObject.CompareTag("Special Target"))
        {
            gm.Score += 3;
            Destroy(collision.gameObject);
        }
    }

}
