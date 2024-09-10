using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public  class FireB : MonoBehaviour
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

        var magazine_children = this.GetComponentsInChildren<magazine_Sc>();
        if(magazine_children == null)
        {
            //magazine = null;
            ammo_num_Z = 1;
            Debug.Log("NoMagazine");
            

        }
        else
        {
            if(bullet_chember == 0)
            {
                Reload_chenber();
            }
            bullet_chember =1;
           
        }
        bullet_chember =1;

        //if(magazine.TryGetComponent<magazine_Sc>(out var magazine_Sc))
        //{

       
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

                //if(magazine.TryGetComponentInChildren<magazine_Sc>())
                //{
                    //Debug.Log("magazine is OK");
                //}
                //else
                //
                    //magazine = null;
                //}

                //var magazine = GetComponentInChildren<magazine_Sc>(); 



            switch(sTN)
            {
                case 0:
                    stNo_ = true;
                    gameObject.SetActive (true);

                    if(Input.GetKey(KeyCode.H))
                    {
                        stNo_ = false;
                    }
                    if(Input.GetMouseButtonDown(0) && mousePu == false && able_to_shot == true)
                    {
                        //if(magazine_Script.ammoN>0)

                        if(bullet.TryGetComponent<bulletscript>(out var bulletscript))
                        {
                            //StartCoroutine("SR_shot_Bullet");
                            SR_shot_Bullet(gun_N,bullet,moA,muzzle);
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
                    if(magazine.GetComponentInChildren<magazine_Sc>())
                    {
                        gunUsable = false;
                        
                        if(bullet_chember == 0)
                        {
                            SR_Reload_magazine(gun_N,bullet,magazine,false);
                        }
                        else
                        {
                            SR_Reload_magazine(gun_N,bullet,magazine,false);
                        }
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
    [SerializeField] IEnumerator SR_shot_Bullet(int gun,GameObject bullet,float moA,GameObject muzzle)
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
                    case 1:

                        Instantiate(bullet,muzzle.transform.position,muzzle.transform.rotation);

                        //bulletscript_.Fire_Bullet(500f);                              ///   テスト　保留中
                        

                        while (mousePu == false)
                        {
                            yield return new WaitForEndOfFrame();
                        }
                        yield return new WaitForSeconds(1.2f);
                        
                        Reload_chenber();



                        /*
                        if(magazine_Script.ammoN>0)
                        {
                            magazine_Script.ammoN--;
                        }
                        else
                        {
                            magazine_Script.ammoN = 0;
                        }*/

                    

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
                

                if(magazine.TryGetComponent<magazine_Sc>(out var magazine_Sc))
                {
                    yield return new WaitForSeconds(1.2f);
                    magazine_Script.ammoN = 7;
                    
                    if(!chemb)
                    {
                        Reload_chenber();
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


        if(magazine.TryGetComponent<magazine_Sc>(out var magazine_Sc))
        {
            Debug.Log("a");
            for(int i = 0;((magazine_Sc.ammoNumber[i] > 0)|| i>magazine_Sc.ammoNumber.Length);i++)        //i>magazine_Sc.limit_ammoN
            {
                if(bullet != null){
                    switch(magazine_Sc.ammoNumber[i])
                    {
                        case 0:
                        bullet = null;
                        break;

                        case 1:
                        Debug.Log("b");
                        bullet = bullet_prefabNum_1;
                        bullet_chember = 1;

                        Debug.Log(bullet_chember);

                        magazine_Sc.ammoNumber[i] = 0;

                        break; 

                        case 2:
                        Debug.Log("c");

                        //bullet = bullet_prefabNum_1;
                        bullet = bullet_prefabNum_2;
                        bullet_chember = 2;
                        

                        // ここは一旦省略


                        break;
                    }
                    break;
                
                }
            }
            
        }
    }


    
}
        /*
public static class ComponentExt
{
    public static bool TryGetComponentInChildren<T>( this Component self, out T component ) where T : Component
    {
        component = self.GetComponentInChildren<T>();
        return component != null;
    }
    
    public static bool TryGetComponentInChildren<T>( this Component self, out T component, bool includeInactive ) where T : Component
    {
        component = self.GetComponentInChildren<T>( includeInactive );
        return component != null;
    }
}

public static class GameObjectExt
{
    public static bool TryGetComponentInChildren<T>( this GameObject self, out T component ) where T : Component
    {
        component = self.GetComponentInChildren<T>();
        return component != null;
    }
    
    public static bool TryGetComponentInChildren<T>( this GameObject self, out T component, bool includeInactive ) where T : Component
    {
        component = self.GetComponentInChildren<T>( includeInactive );
        return component != null;
    }
}
*/
