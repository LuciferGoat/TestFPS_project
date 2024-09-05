using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTest_enemycScript : MonoBehaviour
{
    [SerializeField]
    GameObject eneO1;

    [SerializeField]
    public GameObject coG1;

    [SerializeField]
    public Transform coV1;


    public EnemyTst1 enemyTst1;

    // Start is called before the first frame update

    
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other)
    {
        if(other.tag =="Player")
        {   coG1 = GameObject.FindGameObjectWithTag("Player");;
            coV1 = other.GetComponent<Transform>();
            enemyTst1.CoAssain();
        }
    }
}
