using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class NewTestEasyShotBullet : MonoBehaviour
{
    [SerializeField]
    private GameObject muzzle;
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    public  GameObject magazine;
    

    [SerializeField]
    private int sTN;

    [SerializeField]
    private int gun_N;

    [SerializeField]
    public int bullet_chember;

    [SerializeField]
    private float moA;

    [SerializeField]
    public bool magazine_var;


    [SerializeField]
    private bool stNo_;

    [SerializeField]
     private bool gunUsable;


    [SerializeField]
    public int Smode_;

    [SerializeField]
    public int ammo_num_Z;

    [SerializeField]
    private bool mousePu;
    [SerializeField]
    private bool able_to_shot;


   

    private Rigidbody rb;

    public bulletscript bulletscript_;
    public magazine_Sc magazine_Script;

[SerializeField]
    public GameObject bullet_prefabNum_1;
[SerializeField]
    public GameObject bullet_prefabNum_2;


    public int zandan;

    // Start is called before the first frame update
    void Start()
    {
        mousePu = false;

        gun_N = 0;

        gunUsable = true;
        if(gunUsable)
        {
                able_to_shot = true;
        }

        //magazine =this.GetComponentInChildren<magazine_Sc>();

       
            

        
    
            if(bullet_chember == 0)
            {
                Reload_chenber();
            }
            bullet_chember =1;


            zandan = 7;       //
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.SN_p == 0)
            {
                if(!gunUsable)
                {
                    able_to_shot = false;
                }
            switch(sTN)
            {
                case 0:
                    stNo_ = true;
                    gameObject.SetActive (true);

                    if(Input.GetKey(KeyCode.T))
                    {
                        stNo_ = false;
                    }
                    if(Input.GetMouseButtonDown(0) && mousePu == false && able_to_shot == true)
                    {
                        if(zandan>0)
                        {
                            bullet = bullet_prefabNum_1;
                        }
                        else if(zandan == 0)
                        {
                            bullet = null;
                        }

                        if(bullet.TryGetComponent<bulletscript>(out var bulletscript))
                        {
                            //StartCoroutine("SR_shot_Bullet");
                            SR_shot_BulletTest(gun_N,bullet,moA,muzzle);
                            //Reload_chenber();
                        }
                        else
                        {
                            //弾切れ
                            Debug.Log("Error");

                        }
                    
                    
                    mousePu = true;
                    
                    
                }
                if(Input.GetMouseButtonUp(0))
                {
                    mousePu = false;
                }
                if(Input.GetMouseButton(0)){}

                //SR_shot_Bullet(gun_N,ammoNum,bullet,moA,muzzle);


                if(Input.GetKeyUp(KeyCode.R))
                {
                    SR_Reload_magazine(0,bullet,magazine,true);



                    
                        gunUsable = false;
                        
                        if(bullet_chember == 0)
                        {
                            zandan = 7;
                        }
                        else
                        {
                            zandan = 8;
                        }

                }



                break;

                case 1:
                stNo_ = false;
                gameObject.SetActive (false);
                break;


                
            }
            
        }
    }
    void FixedUpdate()
    {

    }
    [SerializeField] IEnumerator SR_shot_BulletTest(int gun,GameObject bullet,float moA,GameObject muzzle)
    {
        switch(gun)
        {
            case 0:
                //if()
                {}
                //else
                {
                able_to_shot = false;
                switch(bullet_chember)
                {
                    case 0:
                    break;

                    case 1:

                        Instantiate(bullet,muzzle.transform.position,muzzle.transform.rotation);

                        bulletscript_.Fire_Bullet(500f);

                        while (mousePu == false)
                        {
                            yield return new WaitForEndOfFrame();
                        }
                        yield return new WaitForSeconds(1.2f);
                        
                        //Reload_chenber();     

                        zandan --;

                        if(zandan > 0)
                        {
                            bullet_chember =1;
                        }

                    

                        //ここでAnimationさせる

                        

                        able_to_shot = true;
                    break;
                }

                
            }
            break;

            case 1:
            break;
        }





        yield break;
        //yield return null;
        
    }

    //リロード
    //Demo
    [SerializeField] IEnumerator SR_Reload_magazine(int gunN,GameObject bullet,GameObject magazine,bool chemb)
    {
        switch(gunN)
        {
            case 0:
                

                if(magazine != null)
                {
                    yield return new WaitForSeconds(1.2f);
                    
                    
                    if(!chemb)
                    {
                        Reload_chenber();
                        zandan = 7;
                    }
                    else
                    {
                        zandan = 8;
                    }

                    gunUsable = true;
                    able_to_shot = true;
                }
                

            break;
        }
    }
    // [SerializeField] IEnumerator SR_Reload_ammo(int magazineNum,GameObject bullet,GameObject magazine)
    // {
    //     switch(magazineNum)
    //     {
    //         case 0:

    //         break;
    //     }
    // }

    void Reload_chenber()
    {
        // if(f == 0)
        // {
        //     bullet_chember = 0;
        // }
        // //bullet = ;

        // if(f == 1)
        // {
        //     bullet_chember = 0;
        // }


        if(magazine!= null)
        {
            Debug.Log("a");
                  //i>magazine_Sc.limit_ammoN
            
                if(bullet != null){
                    switch(bullet_chember)
                    {
                        case 0:
                        //bullet = null;
                        break;

                        case 1:
                        Debug.Log("b");
                        bullet = bullet_prefabNum_1;
                        bullet_chember = 1;

                        Debug.Log(bullet_chember);

                        break; 

                        case 2:
                        //Debug.Log("c");
                        //bullet = bullet_prefabNum_2;
                        //bullet_chember = 2;
                        

                        // ここは一旦省略


                        break;
                    }
                
                }
            
        }
    }


    
}