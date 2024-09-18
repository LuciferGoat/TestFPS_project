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

    private Vector3 _prevPosition;

    private Vector3 forward1 = Vector3.forward;

    public GameObject Emitter_obj;

    public LayerMask mask = -1;
    // Start is called before the first frame update
    void Start()
    {
        bullet_Damage  = 70f;


        rb = this.GetComponent<Rigidbody>();
        forward1 = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        forward1 = transform.forward;

    }
    public void OnCollisionEnter(Collision other)
    {
        //Destroy(this);
    }
}
