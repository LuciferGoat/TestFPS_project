using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magazine_Sc : MonoBehaviour
{
    [SerializeField]
    public int[] ammoNumber= new int [7];

    [SerializeField]
    public int ammoN;

    [SerializeField]
    private int magazine_SN;
    [SerializeField]
    public int limit_ammoN;

    public GameObject gun;
    public int gun_Number;

    private FireB gunScript;

    // Start is called before the first frame update
    void Start()
    {
        limit_ammoN = 7;

        //test

        ammoNumber [0] = 1;
        ammoNumber [1] = 1;
        ammoNumber [2] = 1;
        ammoNumber [3] = 1;
        ammoNumber [4] = 1;
        ammoNumber [5] = 1;
        ammoNumber [6] = 1;
    }

    // Update is called once per frame
    void Update()
    {
        gunScript = GetComponentInChildren<FireB>();
    }
}
