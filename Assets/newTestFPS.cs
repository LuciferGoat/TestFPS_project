using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class newTestFPS : MonoBehaviour
{
    public GameObject cam;
    public GameObject camF;

    public GameObject gun;
    public GameObject player;


    float minX = -84f, maxX = 84f;
    float freeminX = -40f, freemaxX =40f;
    float freeminY = -30f, freemaxY =30f;

    float angleX,angleY;

    float xRot,yRot, x2Rot,y2Rot;

    UnityEngine.Quaternion cameraRotX,cameraRotY, characterRot, gunRot,cameraRot2x,cameraRot2y;

    [SerializeField]
    float Xsens, Ysens;

     bool cursorLock = true;

     bool playerLock = false;

     bool cameraSn = false;

    public Player player_;



    //Quaternion cameraRotX,cameraRotY, characterRot, gunRot,cameraRot2x,cameraRot2y;

    // Start is called before the first frame update
    void Start()
    {
        xRot = 0f;
        yRot = 0f;

        x2Rot = 0f;
        y2Rot = 0f;

        // cameraRotX = cam.transform.localRotation;
        // cameraRotY = camF.transform.localRotation;

        // gunRot = gun.transform.localRotation;
        // characterRot = transform.localRotation;

        transform.Rotate(0.0f,0.0f,0.0f);

        gun.gameObject.transform.parent = camF.gameObject.transform;
        //gun.gameObject.transform.parent = player.gameObject.transform;

        cam.gameObject.GetComponent<Camera>().enabled = true;

        Xsens = 3f;
        Ysens = 3f;
    }

    // Update is called once per frame
    void Update()
    {
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
            if(Player.player_S_life == 1){

            var localAngle = transform.localEulerAngles;
            var localAngleFCam = camF.transform.localEulerAngles;
            var localAngleFCamSub = cam.transform.localEulerAngles;

                if(Input.GetMouseButton(1))
                {
                    gun.transform.localPosition = new UnityEngine.Vector3(0f,-0.14f,0.97f);
                    camF.gameObject.transform.localPosition =new UnityEngine.Vector3(0.2f,0.75f,0f);

                }else
                {
                    gun.transform.localPosition = new UnityEngine.Vector3(0.41f,-0.15f,1f);
                    camF.gameObject.transform.localPosition =new UnityEngine.Vector3(0f,0.75f,0f);
                }
                
                    
                //gun.transform.localPosition = new Vector3(0f,0.6f,0f);
                if(Input.GetMouseButton(2))
                {
                    
                    //gun.gameObject.transform.parent = player.gameObject.transform;

                    // x2Rot = 0f;
                    // y2Rot = 0f;

                    //localAngle.y += x2Rot;

                    //ClampRotation(cameraRotY,0,freeminY,freemaxY);

                    //

                    if((((Mathf.Abs(localAngleFCam.y)+(Mathf.Abs(localAngleFCamSub.y)))<80f)&&  (Mathf.Abs(localAngleFCamSub.y))<80f)|| (((Mathf.Abs(localAngleFCam.y)+(Mathf.Abs(localAngleFCamSub.y)))> 280f &&  (Mathf.Abs(localAngleFCamSub.y))>280f)))
                    {
                        x2Rot = Input.GetAxis("Mouse X")* Xsens;
                        localAngleFCamSub.y += x2Rot;
                    }else
                    {
                        if((Mathf.Abs(localAngleFCamSub.y))>80f && (Mathf.Abs(localAngleFCamSub.y))<180f )
                        {
                            localAngleFCamSub.y = 80f;
                        }
                        if((Mathf.Abs(localAngleFCamSub.y)> 180f ) && (Mathf.Abs(localAngleFCamSub.y)< 280f ))
                        {
                            localAngleFCamSub.y = 280f;
                        }
                    }          // ここまで（8/14）
                    //
                    if((Mathf.Abs(localAngleFCam.x)<80f) || (Mathf.Abs(localAngleFCam.x)> 280f ))
                    {
                        y2Rot = Input.GetAxis("Mouse Y")* Ysens;
                        localAngleFCam.x -= y2Rot;
                    }else
                    {
                        if((Mathf.Abs(localAngleFCam.x))>80f && (Mathf.Abs(localAngleFCam.x))<180f )
                        {
                            localAngleFCam.x = 80f;
                        }
                        if((Mathf.Abs(localAngleFCam.x)> 180f ) && (Mathf.Abs(localAngleFCam.x)< 280f ))
                        {
                            localAngleFCam.x = 280f;
                        }
                    }
                    //



                    cam.transform.localEulerAngles = localAngleFCam;


                    // if(Mathf.Abs(y2Rot)> 0.001f)
                    // {
                    //     cam.transform.Rotate(-y2Rot,0f,0f);
                    // }




                    
                }
                else
                {

                    if(Input.GetMouseButtonUp(2))
                    {
                    gun.gameObject.transform.parent = player.gameObject.transform;

                    // x2Rot = 0f;
                    // y2Rot = 0f;
                    cam.transform.localRotation =UnityEngine.Quaternion.Euler(0,0,0);

                    }
                    
                    cam.transform.localRotation =UnityEngine.Quaternion.Euler(0,0,0);

                    xRot = Input.GetAxis("Mouse X")* Xsens;
                    localAngle.y += xRot;

                    if((Mathf.Abs(localAngleFCam.x)<80f) || (Mathf.Abs(localAngleFCam.x)> 280f ))
                    {
                        yRot = Input.GetAxis("Mouse Y")* Ysens;
                        localAngleFCam.x -= yRot;
                    }else
                    {
                        if((Mathf.Abs(localAngleFCam.x))>80f && (Mathf.Abs(localAngleFCam.x))<180f )
                        {
                            localAngleFCam.x = 80f;
                        }
                        if((Mathf.Abs(localAngleFCam.x)> 180f ) && (Mathf.Abs(localAngleFCam.x)< 280f ))
                        {
                            localAngleFCam.x = 280f;
                        }
                    }
                    
                    
                    // if(Mathf.Abs(xRot)> 0.001f)
                    // {
                    //     transform.Rotate(0f,xRot,0f);
                    // }


                    // if(Mathf.Abs(localAngleFCam.x)> 81f)
                    //     {
                    //         if(localAngleFCam.x > 81f)
                    //         {
                    //             localAngleFCam.x = 80f;
                    //         }
                    //         if(localAngleFCam.x < -81f)
                    //         {
                    //             localAngleFCam.x = -80f;
                    //         }
                    //     }
                    // if(Mathf.Abs(yRot)> 0.001f && (Mathf.Abs(yRot)< 80f))
                    // {
                    //     //camF.transform.Rotate(-yRot,0f,0f);
                    // }
                        
                }
                transform.localEulerAngles = localAngle;
                camF.transform.localEulerAngles = localAngleFCam;
                    

                
            }
        }

    }
    void FixedUpdate()
    {

    }
    public UnityEngine.Quaternion ClampRotation(UnityEngine.Quaternion q,int m,float min,float max)
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
}
