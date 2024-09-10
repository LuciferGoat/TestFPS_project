using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newtestADDforce : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField]
    public float moveCu_speed;

    private Vector3 forwardCu = Vector3.forward;
    // Start is called before the first frame update
    void Start()
    {
         rb = this.GetComponent<Rigidbody>();
        forwardCu = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [SerializeField ]public void moveAdd (float b_velocity)
    {
        moveCu_speed = b_velocity;
        Debug.Log("fireadd");
        rb = this.GetComponent<Rigidbody>();
        forwardCu = transform.forward;
        //b_velocity = 1000f;

        Debug.Log("rb"+b_velocity);
        Debug.Log("rbForward"+transform.forward);

        rb.AddForce(forwardCu * b_velocity,ForceMode.Impulse);
        Debug.Log("fireFin");
    }
    public void OnCollisionEnter(Collision other)
    {
        Destroy(this);
    }
}
