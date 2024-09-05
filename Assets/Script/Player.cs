using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    public static int SN_p;
    public static int player_S_life;
    public int SN_p2;

    [SerializeField]
    public  bool snp3;

    [SerializeField]
    public Canvas _canvas;
    // Start is called before the first frame update
    void Start()
    {
        SN_p = 0;
        snp3 = false;
        _canvas.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Tab) && snp3 == false)
        {
            snp3 = true;
            switch (SN_p)
            {
                case 0:
                    _canvas.enabled = true;
                        SN_p = 1;
                break;

                case 1:
                    SN_p = 0;
                        _canvas.enabled = false;
                break;
            }
            snp3 = false;
        }
        // if(Input.GetKeyUp(KeyCode.Tab))
            // {
            //     snp3 = true;
            // }
        
    }
}
