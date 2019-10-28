using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeReaction : MonoBehaviour
{
    Rigidbody rigidbody;
    public float JumpPower = 10;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Jump()
    {
        rigidbody.AddForce(Vector3.up * JumpPower);
    }
}
