using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newTestobj : MonoBehaviour
{

    public Material def_M;
    public Material hit_M;

    private int t;
    bool t_ing;
    int current_S;


    // Start is called before the first frame update
    void Start()
    {
        t = 1;
        t_ing = false;
        current_S = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if(current_S == 1 && t_ing != true)
        {
            StartCoroutine(hit_timer(t,2));
        }

        switch(current_S)
        {
            case 0 :
                this.GetComponent<Renderer>().material = def_M;
            break;
                
            case 1:
                this.GetComponent<Renderer>().material = hit_M;
            break;
        }
    }
    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag== "bullet" && t_ing == false)
        {
            current_S = 1;
            StartCoroutine(hit_timer(t,2));
        }
    }
    private IEnumerator hit_timer(int t, int a)
    {
        t_ing = true;
        if(t == 0)
        {
            yield break;
        }
        for(int i= 0;i< t;i++)
        {
            yield return new WaitForSeconds(t);
        }
        current_S = 0;
        t_ing = false;
    }
}
