using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyTst1 : MonoBehaviour
{

    public int EneS1;

    [SerializeField]
    private GameObject ec1;

    [SerializeField]
    public GameObject a1;
    [SerializeField]
    public GameObject a2;


    [SerializeField]
    public int a1s;

    [SerializeField]
    public Transform at1;


    private float speed = 0.01f;


    // Start is called before the first frame update
    void Start()
    {
         EneS1 = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(at1 == null|| a1 == null)
        {
        return;
        }else 
        {transform.LookAt(at1.transform.position);
            if(a1.GetComponent<Player>().SN_p2 == 0){
            }else if(a1.GetComponent<Player>().SN_p2 == 1){
            transform.Rotate(0, 180, 0);
        }
         transform.Translate(0, 0, speed);
        }
    }

    public void CoAssain()
    {
        a1 = ec1.GetComponent<NewTest_enemycScript>().coG1;
        at1 = ec1.GetComponent<NewTest_enemycScript>().coV1;
    }

}
