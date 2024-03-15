using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameralScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 offset;
    public Transform PlayerTransform;
    void Start()
    {
        offset = transform.position - PlayerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = offset + PlayerTransform.position;
    }
}
