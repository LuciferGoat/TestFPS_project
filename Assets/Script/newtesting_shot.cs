using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newtesting_shot: MonoBehaviour
{
    private Rigidbody rb;
    private Rigidbody rb_bullet;

    public bulletscript bulletscript_1;

    [SerializeField]
    private GameObject muzzle;


    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private GameObject muzzle2;
    [SerializeField]
    private GameObject bolt;
    [SerializeField]
    private GameObject trigger;

    [SerializeField]
    private GameObject magazine;

    [SerializeField]
    public float bullet_Velocity; 

    Vector3 bullet_forward;

    private int gun_status;



    public int zandan;
    // Start is called before the first frame update

    private bool ableshot;
    private bool reloading;
    void Start()
    {
        gun_status = 0;

        if(bullet_Velocity == 0)
        {
            bullet_Velocity = 1;
        }

        reloading = false;
        if(bullet.TryGetComponent(out bulletscript bulletscript1))  
        {
            bulletscript_1 = bulletscript1;
        }
        else
        {
            Debug.Log("false bullet");
            ableshot = false;
        }
        ableshot = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(gun_status == 0)
        {
            if(Input.GetMouseButtonDown(0) && ableshot&& !reloading )
            {
                ableshot = false;
                if(zandan>0)
                {
                        if(bullet.TryGetComponent(out bulletscript bulletscript1))   //bullet.TryGetComponent<bulletscript>(out var bulletscript1)
                    {
                        Debug.Log("Getcomponent");
                        Debug.Log(bulletscript1.bullet_Damage);

                        // StartCoroutine(SR_shot_BulletTest());
                        //Reload_chenber();
                    }

                    //StartCoroutine(SR_shot_BulletTest());

                    SR_shot_BulletTest(bullet,muzzle);


                }
                else
                {
                    //弾切れ
                    Debug.Log("No Ammo");

                    trigger.GetComponent<null_ammo_sound>().null_ammo_sound_ ();

                }
            }
            if(Input.GetMouseButtonDown(0) &&!reloading )
            {
                ableshot = true;
                trigger.GetComponent<null_ammo_sound>().null_ammo_sound_ ();
            }

            if(Input.GetKeyUp(KeyCode.R))
            {
                ableshot = false;
                reloading = true;
                StartCoroutine(SR_shot_reloadTest());
                
            }
            if(Input.GetKeyUp(KeyCode.Y))
            {
            
            }

            if(Input.GetKey(KeyCode.Alpha2))
            {
                gun_status = 1;
            }
        }
        else 
        {
            if(Input.GetKey(KeyCode.Alpha1))
            {
                gun_status = 0;
            }
        }
    }
    [SerializeField]public void SR_shot_BulletTest(GameObject bullet,GameObject muzzle)
    {
                Debug.Log("s");
                GameObject bullet_clone = Instantiate(bullet,muzzle.transform.position,muzzle.transform.rotation);
                rb_bullet = bullet_clone.GetComponent<Rigidbody>();
                //rb_bullet.AddForce(muzzle.transform.forward* 50f* bullet_Velocity ,ForceMode.Impulse);

                bullet_forward = muzzle.transform.forward* bullet_Velocity* 0.007f;

                muzzle.GetComponent<shot_sound>().shot_B_sound ();
                rb_bullet.AddForce(bullet_forward,ForceMode.Impulse);

                zandan --;

                //bulletscript_1.Fire_Bullet(500f);

                        //ここでAnimationさせる



                        StartCoroutine(SR_shot_BulletTest1());

    }
    [SerializeField]IEnumerator SR_shot_BulletTest1()
    {
                Debug.Log("s1");

                        while (Input.GetMouseButtonDown(0))
                        {
                            yield return new WaitForEndOfFrame();
                        }
                        yield return new WaitForSeconds(1.2f);
                        
                        //Reload_chenber();     

                        bolt.GetComponent<bolt_sounds>().bolt_sound_ ();

                        //ここでAnimationさせる
                        ableshot = true;
                        yield return null;
    }
    [SerializeField]IEnumerator SR_shot_reloadTest()
    {
        if(magazine!= null)
        {
            magazine.GetComponent<magazine_sound>().DropM_sound ();
        }
        
        yield return new WaitForSeconds(2);

        if(magazine!= null)
        {
            magazine.GetComponent<magazine_sound>().SetM_sound ();
        }

        zandan = 7;
        ableshot = true;
        reloading = false;
        yield return null;
        
    }
}
