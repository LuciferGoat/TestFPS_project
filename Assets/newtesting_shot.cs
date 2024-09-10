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
    public float bullet_Velocity; 



    public int zandan;
    // Start is called before the first frame update

    private bool ableshot;
    private bool reloading;
    void Start()
    {
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
        }
        ableshot = true;

    }

    // Update is called once per frame
    void Update()
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
                Debug.Log("Error");

            }
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
    }
    [SerializeField]public void SR_shot_BulletTest(GameObject bullet,GameObject muzzle)
    {
                Debug.Log("s");
                GameObject bullet_clone = Instantiate(bullet,muzzle.transform.position,muzzle.transform.rotation);
                rb_bullet = bullet_clone.GetComponent<Rigidbody>();
                rb_bullet.AddForce(muzzle.transform.forward* 50f* bullet_Velocity);

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

                        zandan --;

                        //ここでAnimationさせる
                        ableshot = true;
                        yield return null;
    }
    [SerializeField]IEnumerator SR_shot_reloadTest()
    {
        yield return new WaitForSeconds(2);
        zandan = 7;
        ableshot = true;
        reloading = false;
        yield return null;
        
    }
}
