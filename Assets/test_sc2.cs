using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_sc2 : MonoBehaviour
{
    public Rigidbody rb;
    public float b_velocity = 500f;

    private Vector3 forward1 = Vector3.forward;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = this.GetComponent<Rigidbody>();
        suTest();

        //rb.AddForce(0,0,10f,ForceMode.Impulse);
        //rb.AddForce(transform.forward,ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void suTest()
    {
        Debug.Log("fire");
        rb = this.GetComponent<Rigidbody>();
        forward1 = transform.forward;
        b_velocity = 1000f;
        rb.AddForce(transform.forward * b_velocity,ForceMode.Impulse);
    }
}
