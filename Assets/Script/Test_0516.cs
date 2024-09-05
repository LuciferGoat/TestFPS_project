using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_0516 : MonoBehaviour
{

    private int intTest1;

    public int intTest2;

    [SerializeField]
    private int intTest3;

    [SerializeField]
    private GameObject otherObject;
    private GameObject PreFab1;


    // Start is called before the first frame update
    void Start()
    {

        var newObject1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        var newObject2 = Instantiate(PreFab1,transform.position,transform.rotation);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
