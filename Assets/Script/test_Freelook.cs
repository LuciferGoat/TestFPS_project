using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.AI;
//using System.Windows.Forms;

public class test_Freelook : MonoBehaviour
{
    // Start is called before the first frame update
    float x, z;
    float speed = 0.1f;

    public GameObject cam;//camera
    public GameObject camF;

    //public GameObject subcam;
    
    public GameObject gun;
    public GameObject player;
    public GameObject player2;
    public Quaternion cameraRotX,cameraRotY, characterRot, gunRot,cameraRot2x,cameraRot2y,cameraRot,cameraRotSub;
    float Xsensityvity = 3f, Ysensityvity = 3f;
    
    bool cursorLock = true;
    bool playerLock = false;

    //変数の宣言(角度の制限用)
    float minX = -85f, maxX = 85f; //x軸の回転の制限


    float freeminX = -40f, freemaxX =40f;
    float freeminY = -30f, freemaxY =30f;

    float angleX,angleY;

    float xRot,yRot, x2Rot,y2Rot;

    //int mX = System.Windows.Forms.Cursor.Position.X;

    //int mY = System.Windows.Forms.Cursor.Position.Y;

    //int mX = System.Windows.Forms.Cursor.Position.X;
    //int mY = System.Windows.Forms.Cursor.Position.Y;

    bool cameraSn = false;

    public Player player_;

    [SerializeField]
    private Material normalscMaterial;
    [SerializeField]
    private Material AimMaterial;

    public GameObject scope_obj_f;


    // Start is called before the first frame update
    void Start()
    {
        //cam.enabled = true;

        cam.gameObject.GetComponent<Camera>().enabled = true;

        xRot = 0f;
        yRot = 0f;

        x2Rot = 0f;
        y2Rot = 0f;

        // cameraRotX = cam.transform.localRotation;
        // cameraRotY = camF.transform.localRotation;

        cameraRot = cam.transform.localRotation;
        cameraRotSub = camF.transform.localRotation;

        gunRot = gun.transform.localRotation;
        characterRot = transform.rotation;
        
        transform.Rotate(0.0f,0.0f,0.0f);


        //cam.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        //camF.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        //gun.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);


        //gun.gameObject.transform.parent = player.gameObject.transform;

        cam.gameObject.GetComponent<Camera>().enabled = true;

        scope_obj_f.GetComponent<Renderer>().material = normalscMaterial;

    }

    // Update is called once per frame
    void Update()
    {
        //xRot = Input.GetAxis("Mouse X") * Ysensityvity;
        //yRot = Input.GetAxis("Mouse Y") * Xsensityvity;

        
        
        if(Player.SN_p == 0)
        {
            cursorLock = true;
        }
        else
        {
            cursorLock = false;
        }

        if (cursorLock)
        {
            if(Input.GetMouseButton(1))
                {
                    scope_obj_f.GetComponent<Renderer>().material = AimMaterial;
                    gun.transform.localPosition = new UnityEngine.Vector3(0.2f,-0.142f,1f);
                    camF.gameObject.transform.localPosition =new UnityEngine.Vector3(0.2f,0.75f,0f);

                }else
                {
                    scope_obj_f.GetComponent<Renderer>().material = normalscMaterial;
                    gun.transform.localPosition = new UnityEngine.Vector3(0.41f,-0.15f,1.2f);
                    camF.gameObject.transform.localPosition =new UnityEngine.Vector3(0f,0.75f,0f);
                }

            if(Input.GetMouseButton(2))
            {
                
                x2Rot = Input.GetAxis("Mouse X")* Ysensityvity;
                y2Rot = Input.GetAxis("Mouse Y") * Xsensityvity;

                cameraRot *= Quaternion.Euler(-y2Rot, x2Rot, 0f);
                //cameraRotSub *= Quaternion.Euler(-y2Rot, 0f, 0f);


                cameraRot = ClampRotation(cameraRot,1,freeminX,freemaxX);
                cameraRotSub = ClampRotation(cameraRotSub,0,freeminY,freemaxY);

                cameraSn = true;

                
            }
            else
            {
                xRot = Input.GetAxis("Mouse X") * Ysensityvity;
                yRot = Input.GetAxis("Mouse Y") * Xsensityvity;

                cameraRotSub *= Quaternion.Euler(-yRot, 0f, 0f);
                cameraRotSub = ClampRotation(cameraRotSub,0,minX,maxX);

                characterRot *= Quaternion.Euler(0f, xRot, 0f);
                //gunRot = cameraRotSub;

                // if(Input.GetMouseButtonUp(2))
                // {
                //     // gun.gameObject.transform.localRotation = player.transform.localRotation;

                //     //x2Rot = 0f;
                //     //y2Rot = 0f;

                    

                //     Debug.Log("reset1");
                    
                //     //cam.gameObject.GetComponent<Camera>().enabled = true;
                    
                //     //System.Windows.Forms.Cursor.Position = new System.Drawing.Point(0, 0);

                //     cameraSn = false;
                //     cameraRot *= Quaternion.Euler(0f, 0f, 0f);
                //     cameraRotSub *= Quaternion.Euler(0f, 0f, 0f);

                //     y2Rot = 0f;
                //     x2Rot = 0f;
                //     cameraRotSub *= Quaternion.Euler(0f, 0f, 0f);


                    
                // }
                
                

                
                //camF.transform.localRotation =  Quaternion.LookRotation(player2.transform.forward);
                //cam.transform.localRotation =  Quaternion.LookRotation(player2.transform.forward);
               
               
            }
            if(Input.GetMouseButtonUp(2))
                {
                    // gun.gameObject.transform.localRotation = player.transform.localRotation;

                    //x2Rot = 0f;
                    //y2Rot = 0f;

                    

                    Debug.Log("reset2");
                    
                    //cam.gameObject.GetComponent<Camera>().enabled = true;
                    
                    //System.Windows.Forms.Cursor.Position = new System.Drawing.Point(0, 0);

                    cameraSn = false;
                    cameraRot = Quaternion.Euler(0f, 0f, 0f);
                    //cameraRotSub *= Quaternion.Euler(0f, 0f, 0f);

                    y2Rot = 0;
                    x2Rot = 0f;
                    cameraRotSub *= Quaternion.Euler(0f, 0f, 0f);


                    
                }
            // if(Input.GetMouseButtonUp(2))
            //     {
            //         // gun.gameObject.transform.localRotation = player.transform.localRotation;

            //         //x2Rot = 0f;
            //         //y2Rot = 0f;

                    

            //         Debug.Log("reset2");
                    
            //         //cam.gameObject.GetComponent<Camera>().enabled = true;
                    
            //         //System.Windows.Forms.Cursor.Position = new System.Drawing.Point(0, 0);

            //         cameraSn = false;
            //         cameraRot *= Quaternion.Euler(0f, 0f, 0f);
            //         cameraRotSub *= Quaternion.Euler(0f, 0f, 0f);




                    
            //     }
            if(cameraSn)
            {
                //transform.rotation = characterRot;
                //transform.localRotation = characterRot;
                //gun.transform.localRotation = cameraRotY;

                cam.transform.localRotation = cameraRot;
                camF.transform.localRotation = cameraRotSub;

            }
            if(!cameraSn)
            {
                //camF.transform.localRotation = cameraRotX;
                cam.transform.localEulerAngles = new Vector3(0f,0f,0f);
                camF.transform.localRotation = cameraRotSub;
                transform.localRotation = characterRot;
                gun.transform.localRotation = gunRot;

                //cameraRot2x *= Quaternion.Euler(0f, 0f, 0f);
                //cameraRot2y *= Quaternion.Euler(0f, 0f, 0f);
            }

            //gun.transform.localRotation = gunRot;

            
            
            
            
        }


        UpdateCursorLock();

        // if(Input.GetAxis("Mouse X") != 0)
        // {
        //     Debug.Log("Mouse");
        // }
    }

    // private void FixedUpdate()
    // {
    //     x = 0;
    //     z = 0;

    //     x = Input.GetAxisRaw("Horizontal") * speed;
    //     z = Input.GetAxisRaw("Vertical") * speed;

    //     //transform.position += new Vector3(x,0,z);

    //     //transform.position += cam.transform.forward * z + cam.transform.right * x;
    // }


    public void UpdateCursorLock()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLock = false;
        }
        else if(Input.GetMouseButton(0))
        {
            //cursorLock = true;
        }

        if (cursorLock)
        {
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        }
        else if(!cursorLock)
        {
            UnityEngine.Cursor.lockState = CursorLockMode.None;
        }
    }
    
    //角度制限関数の作成
    public Quaternion ClampRotation(Quaternion q,int m,float min,float max)
    {
        //q = x,y,z,w (x,y,zはベクトル（量と向き）：wはスカラー（座標とは無関係の量）)

        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1f;

        switch(m){
            case 0:
                angleX = Mathf.Atan(q.x) * Mathf.Rad2Deg * 2f;
                angleX = Mathf.Clamp(angleX,min,max);
                q.x = Mathf.Tan(angleX * Mathf.Deg2Rad * 0.5f);

            break;

            case 1:
                angleX = Mathf.Atan(q.x) * Mathf.Rad2Deg * 2f;
                angleY = Mathf.Atan(q.y) * Mathf.Rad2Deg * 2f;
                angleX = Mathf.Clamp(angleX,min,max);
                angleY = Mathf.Clamp(angleY,min,max);

                q.x = Mathf.Tan(angleX * Mathf.Deg2Rad * 0.5f);
                q.y = Mathf.Tan(angleY * Mathf.Deg2Rad * 0.5f);

            break;
        }
        return q;
    }
    // public static Quaternion GetAngleDiff(Quaternion a, Quaternion b)
    // {
    //     var va = a * Vector3.up;
    //     var vb = b * Vector3.up;
 
    //     var angleA = Mathf.Atan2(va.x, va.z) * Mathf.Rad2Deg;
    //     var angleB = Mathf.Atan2(vb.x, vb.z) * Mathf.Rad2Deg;
 
    //     //var diff = Mathf.DeltaAngle(angleA, angleB);

    //     var diff = a.inverse().multiply(angleB);
    //     return diff;
    // }

    public void FixedUpdate()
    {

    }
}


