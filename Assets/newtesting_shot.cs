using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newtesting_shot: MonoBehaviour
{
    private Rigidbody rb;

    public bulletscript bulletscript_;

    [SerializeField]
    private GameObject muzzle;


    [SerializeField]
    private GameObject bullet;

    public int zandan;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) )
        {
            if(zandan>0)
            {
                    if(bullet.TryGetComponent<bulletscript>(out var bulletscript_))
                {
                    // StartCoroutine(SR_shot_BulletTest());
                    //Reload_chenber();
                }

                StartCoroutine(SR_shot_BulletTest());

                //SR_shot_BulletTest();


            }
            else
            {
                //弾切れ
                Debug.Log("Error");

            }
        }
    }
    IEnumerator SR_shot_BulletTest()
    {
                Instantiate(bullet,muzzle.transform.position,muzzle.transform.rotation);

                bulletscript_.Fire_Bullet(500f);

                        while (Input.GetMouseButtonDown(0))
                        {
                            yield return new WaitForEndOfFrame();
                        }
                        yield return new WaitForSeconds(1.2f);
                        
                        //Reload_chenber();     

                        zandan --;

                        //ここでAnimationさせる
    }
}
