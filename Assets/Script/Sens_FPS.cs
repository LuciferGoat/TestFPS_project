using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.AI;
//using System.Windows.Forms;

public class Sens_FPS : MonoBehaviour
{
    // Start is called before the first frame update
    float x, z;
    float speed = 0.1f;

    public GameObject cam;
    public GameObject camF;

    public GameObject subcam;
    public GameObject subcamF;

    public GameObject gun;
    public GameObject player;
    public GameObject player2;
    Quaternion cameraRotX,cameraRotY, characterRot, gunRot,cameraRot2x,cameraRot2y;
    float Xsensityvity = 3f, Ysensityvity = 3f;
    
    bool cursorLock = true;
    bool playerLock = false;

    //変数の宣言(角度の制限用)
    float minX = -90f, maxX = 90f;
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

    // Start is called before the first frame update
    void Start()
    {
        //cam.enabled = true;


        xRot = 0f;
        yRot = 0f;

        x2Rot = 0f;
        y2Rot = 0f;

        cameraRotX = cam.transform.localRotation;
        cameraRotY = camF.transform.localRotation;

        cameraRot2x = subcam.transform.localRotation;
        cameraRot2y = subcamF.transform.localRotation;

        gunRot = gun.transform.localRotation;
        characterRot = transform.localRotation;

        transform.Rotate(0.0f,0.0f,0.0f);
        gun.gameObject.transform.parent = player.gameObject.transform;

        cam.gameObject.GetComponent<Camera>().enabled = true;
        //camF.gameObject.GetComponent<Camera>().enabled = true;
        subcam.gameObject.GetComponent<Camera>().enabled = false;
        //subcamF.gameObject.GetComponent<Camera>().enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
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

        //Updateの中で作成した関数を呼ぶ

        if (cursorLock)
        {
            if(Input.GetMouseButton(2))
            {
                
                x2Rot = Input.GetAxis("Mouse X")* Ysensityvity;
                y2Rot = Input.GetAxis("Mouse Y") * Xsensityvity;
                subcam.gameObject.GetComponent<Camera>().enabled = true;
                cameraRot2x *= Quaternion.Euler(0f, x2Rot, 0f);
                cameraRot2y *= Quaternion.Euler(-y2Rot, 0f, 0f);

                //gun.gameObject.transform.parent = player.gameObject.transform;

                cameraRot2x = ClampRotation(cameraRot2x,1,freeminX,freemaxX);
                cameraRot2y = ClampRotation(cameraRot2y,0,freeminY,freemaxY);

                cameraSn = true;
                cam.gameObject.GetComponent<Camera>().enabled = false;

                if(cameraSn)
                {
                    subcamF.transform.localRotation = cameraRot2x;
                    subcam.transform.localRotation = cameraRot2y;
                }
            }
            else
            {
                xRot = Input.GetAxis("Mouse X") * Ysensityvity;
                yRot = Input.GetAxis("Mouse Y") * Xsensityvity;

                cameraRotY *= Quaternion.Euler(-yRot, 0f, 0f);
                cameraRotY = ClampRotation(cameraRotY,0,freeminY,freemaxY);
                characterRot *= Quaternion.Euler(0f, xRot, 0f);
                gunRot = cameraRotY;

                if(Input.GetMouseButtonUp(2))
                {
                    // gun.gameObject.transform.localRotation = player.transform.localRotation;

                    subcamF.transform.localRotation = camF.transform.localRotation;
                    subcam.transform.localRotation = cam.transform.localRotation;
                    x2Rot = 0f;
                    y2Rot = 0f;
                    cameraRot2x *= Quaternion.Euler(0f, 0f, 0f);
                    cameraRot2y *= Quaternion.Euler(0f, 0f, 0f);
                    Debug.Log("reset");
                    
                    xRot = 0f;
                    yRot = 0f;
                    cam.gameObject.GetComponent<Camera>().enabled = true;
                    
                    //System.Windows.Forms.Cursor.Position = new System.Drawing.Point(0, 0);
                    
                    //gun.gameObject.transform.parent = cam.gameObject.transform;

                    cameraSn = false;
                    subcam.gameObject.GetComponent<Camera>().enabled = false;
                    //subcam.gameObject.transform.localEulerAngles = new Vector3(0f,0f,0f);
                    //subcamF.gameObject.transform.localEulerAngles = new Vector3(0f,0f,0f);

                    // cameraRot2x *= Quaternion.Euler(0f, 0f, 0f);
                    // cameraRot2y *= Quaternion.Euler(0f, 0f, 0f);
                    // cameraRot2x = ClampRotation(cameraRot2x,0,0f,0f);
                    // cameraRot2y = ClampRotation(cameraRot2y,0,0f,0f);

                    // subcamF.transform.localRotation = cameraRot2x;
                    // subcam.transform.localRotation = cameraRot2y;

                    // subcamF.transform.localRotation = cameraRotX;
                    // subcam.transform.localRotation = cameraRotY;
                    
                }
                if(!cameraSn)
            {
                camF.transform.localRotation = cameraRotX;
                cam.transform.localRotation = cameraRotY;
                transform.localRotation = characterRot;
                gun.transform.localRotation = cameraRotY;
            }
                

                
                //camF.transform.localRotation =  Quaternion.LookRotation(player2.transform.forward);
                //cam.transform.localRotation =  Quaternion.LookRotation(player2.transform.forward);
               
               
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
}
