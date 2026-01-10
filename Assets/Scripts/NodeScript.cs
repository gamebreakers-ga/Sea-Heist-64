using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NodeScript : MonoBehaviour
{
    public NodeType nodeType;
    public GameObject[] ConnectedNodes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward);
    }

    public enum NodeType
    {
        Sentry,
        Path,
        Door
    }

}


