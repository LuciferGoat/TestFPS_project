using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscript : MonoBehaviour
{
    public Rigidbody rb;
    //public float b_velocity = 500f;

    [SerializeField]
    public float bullet_Damage;

    [SerializeField]
    public float bullet_speed;

    private Vector3 forward1 = Vector3.forward;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("bullet start");
        bullet_Damage  = 70f;


        rb = this.GetComponent<Rigidbody>();
        forward1 = transform.forward;
        //b_velocity = 1000f;
        //Fire_Bullet ();
        //Debug.Log("fires");
        

    }

    // Update is called once per frame
    void Update()
    {
        forward1 = transform.forward;
    }
    // [SerializeField ]public void Fire_Bullet (float b_velocity)
    // {
    //     bullet_speed = b_velocity;
    //     Debug.Log("fireT");
    //     rb = this.GetComponent<Rigidbody>();
    //     forward1 = transform.forward;
    //     //b_velocity = 1000f;

    //     Debug.Log("rb"+b_velocity);
    //     Debug.Log("rbForward"+transform.forward);

    //     rb.AddForce(forward1 * b_velocity,ForceMode.Impulse);
    //     Debug.Log("fireFin");
    // }
    public void OnCollisionEnter(Collision other)
    {
        Destroy(this);
    }
}
