using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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

    void FixedUpdate()
    {
        var emitPos = Emitter_obj.transform.position;
        var emitDir = Emitter_obj.transform.forward;

        Ray ray = new Ray(emitPos,emitDir);

        RaycastHit hit;

        bool isHit = Physics.Raycast(ray, out hit, 100.0f, mask);

        if(isHit)
        {
            GameObject hitObj = hit.collider.gameObject;

            if(hitObj.gameObject.tag == "shell")
            {
                UI_for_Player.Score_clay++;
                Destroy(hitObj);
            }

            if(hitObj.gameObject.tag == "test_obj")
            {
            //hitObj.GetComponent<Renderer>().material.color = Color.green;

            }

            Vector3 hitPos = hit.point;

            Vector3 normal = hit.normal;

            Vector3 r_direction = ray.direction;

            //反射ベクトル
            Vector3 reflect_Dir = 2* normal * Vector3.Dot(normal, -r_direction) + r_direction;

            float rad = Mathf.Acos(Vector3.Dot(-ray.direction,reflect_Dir)/ray.direction.magnitude * reflect_Dir.magnitude);

            float deg = rad * Mathf.Rad2Deg;

            //反射角度が90度以上だったら・・・
            //if(deg>90)
            //{  
            //}


            //Debug.Log(deg);

            //（デバッグ用）新しい反射用レイを作成する
            Ray reflect_ray = new Ray(hitPos, reflect_Dir);

            //（デバッグ用）レイを画面に表示する
            Debug.DrawLine(reflect_ray.origin, reflect_ray.origin+reflect_ray.direction * 100, Color.blue, 0);


        }
    }
    public void OnCollisionEnter(Collision other)
    {
        //Destroy(this);
    }
}
