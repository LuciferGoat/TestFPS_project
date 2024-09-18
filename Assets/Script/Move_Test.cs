using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UI;

public class Move_Test : MonoBehaviour
{
    public GameObject Player;
    public GameObject playerC;
    public Rigidbody rb;
    
    float speed1 = 3.0f;

[SerializeField]
    public float sensitiveM = 0.7f; //マウス感度

[SerializeField]
    public GameObject mainCamera;

[SerializeField]
    public GameObject mainCameraf;


    public Camera mainCamera1;
[SerializeField]
    public GameObject subCamera;


[SerializeField]
private Material normalMaterial;
[SerializeField]
private Material powerUpMaterial;

public int powerUp;

[Serialize]
public GameObject playerscript;

 [Serialize]
 public float move_speed;

 [SerializeField]
 public int player_attitude;

    Vector3 terePos;

    Vector3 force;
    Vector3 forwardVec;
    



    CharacterController con;
    Animator anim;
 
    float normalSpeed = 3f; // 通常時の移動速度
    float sprintSpeed = 5f; // ダッシュ時の移動速度
    float jump = 2f;        // ジャンプ力
    float gravity = 10f;    // 重力の大きさ
 
    Vector3 moveDirection = Vector3.zero;
 
    Vector3 startPos;

    bool mouseP;

    bool grounded;
    bool groundedS;

    bool sprint;

    float speed;

    public Vector3 cameraForward;

    // 前後左右の入力（WASDキー）から、移動のためのベクトルを計算
    // Input.GetAxis("Vertical") は前後（WSキー）の入力値
    // Input.GetAxis("Horizontal") は左右（ADキー）の入力値
    Vector3 moveZ;
    Vector3 moveX;


    Vector3 Deceleration;

    // Start is called before the first frame update
    void Start()
    {
        player_attitude = 0;
        rb = GetComponent<Rigidbody>();
        force = new Vector3(0.0f,5.0f,0.0f);
        sprint = false;

        //con = GetComponent&lt;CharacterController&gt;();
        //anim = GetComponent&lt;Animator&gt;();
 
        // マウスカーソルを非表示にし、位置を固定
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        terePos = new Vector3(0.0f,0.0f,0.0f);

        startPos = transform.position;
        forwardVec = new Vector3(0.0f,2.0f,10.0f);

        mainCamera.SetActive(true);
        subCamera.SetActive(false);

        mainCamera1 = mainCamera.GetComponent<Camera>();

        transform.Rotate(0.0f,0.0f,0.0f);

        powerUp = 0;
        playerC.GetComponent<Renderer>().material = normalMaterial;

        mouseP = false;
        

        move_speed = 1f;

        

        

    }
    
    /*void Update()
    {
        


        if(Input.GetKey(KeyCode.W))
        {
            //transform.Translate(0,0,0.1f,Space.Self);
        }
    }*/
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            grounded = true;
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            grounded = true;
        }
        else
        {
        }
    }
    void OnCollisionExit(Collision collision)
    {
            grounded = false;
    }
    

    // Update is called once per frame
    void Update()
    {

        Vector3 position = gameObject.transform.position;
        cameraForward = Vector3.Scale(mainCamera.transform.forward,new Vector3(1, 0, 1)).normalized;
        


        if (mainCamera1 == null)
        {
            return;
        }


        switch(powerUp)
            {
                case 0:
                // powerUp = 1;
                playerC.GetComponent<Renderer>().material = powerUpMaterial;
                playerC.GetComponent<Player>().SN_p2 = 1;
                break;
                
                case 1:
                // powerUp = 0;
                playerC.GetComponent<Renderer>().material = normalMaterial;
                playerC.GetComponent<Player>().SN_p2 = 0;
                break;
                
            }

        if(Input.GetKeyDown(KeyCode.E) && mouseP == false)
        {
            mouseP = true;

            powerUp++;

            powerUp = powerUp%2;
            if(Input.GetKeyUp(KeyCode.E))
            {
                mouseP = false;
            }
            
            
            // if (powerUp==1)
            // {
            //     powerUp = 0;
            //     playerC.GetComponent<Renderer>().material = normalMaterial;
            //     playerC.GetComponent<Player>().SN_p2 = 0;

            // }
            // else if(powerUp==0)
            // {
            //     powerUp = 1;
            //     playerC.GetComponent<Renderer>().material = powerUpMaterial;
            //     playerC.GetComponent<Player>().SN_p2 = 1;
            // }
        }


        switch(player_attitude)
            {
                case 0:
                        
                        if (grounded)
                        {
                            speed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : normalSpeed;
                            if(rb.velocity.magnitude < 5)
                            {
                                float currentSpeed = speed - rb.velocity.magnitude;

                                moveZ = cameraForward * Input.GetAxis("Vertical") * currentSpeed * 15f;  //　前後（カメラ基準）　 
                                moveX = mainCamera.transform.right * Input.GetAxis("Horizontal") * currentSpeed * 14f; // 左右（カメラ基準）

                                if(Input.GetAxis("Vertical") == 0)
                                {
                                    
                                }
                            }
                            
                            //if (Input.GetButtonDown("jump"))
                            if(Input.GetKeyDown(KeyCode.V))
                            {
                                //moveDirection.y = jump;
                                moveDirection.y = 0.5f;
                            }
                            
                            
                        }
                        else
                        {
                            // 重力を効かせる
                            moveDirection = moveZ + moveX + new Vector3(0, moveDirection.y, 0);
                            moveDirection.y -= gravity * Time.deltaTime;
                        }
                        
                            
                        moveDirection = moveZ + moveX;
                
                        // 移動のアニメーション
                        //anim.SetFloat("MoveSpeed", (moveZ + moveX).magnitude);
                
                        // プレイヤーの向きを入力の向きに変更　
                        //transform.LookAt(transform.position + moveZ + moveX);





                    //    rb.AddForce(moveDirection * Time.deltaTime ,ForceMode.Impulse);
        




                        /*
                        if(Input.GetKeyDown(KeyCode.V)&& grounded == true)
                        {
                            rb.AddForce(force * jump * move_speed ,ForceMode.Impulse);
                        }

                        if(Input.GetKey(KeyCode.W)&& grounded == true)
                        {
                            if(sprint)
                            {
                            move_speed = 1.5f;
                            }else
                            {
                            move_speed = 1.5f;
                            }
                            transform.position += Player.transform.TransformDirection(Vector3. forward) * 10f * move_speed * Time.deltaTime; 
                        }
                        if(Input.GetKey(KeyCode.A)&& grounded == true)
                        {
                            transform.position += mainCameraf.transform.TransformDirection(Vector3. left) * 10f * move_speed * Time.deltaTime; 
                        }
                        if(Input.GetKey(KeyCode.S)&& grounded == true)
                        {
                            transform.position += Player.transform.TransformDirection(Vector3. back) * 10f * move_speed * Time.deltaTime; 
                        }
                        if(Input.GetKey(KeyCode.D)&& grounded == true)
                        {
                            transform.position += mainCameraf.transform.TransformDirection(Vector3. right) * 10f * move_speed * Time.deltaTime; 
                            
                        }*/

                break;
                
                case 1:
                        speed = 2f;
                        if (grounded)
                        {
                            moveZ = cameraForward * Input.GetAxis("Vertical") * speed;  //　前後（カメラ基準）　 
                            moveX = Camera.main.transform.right * Input.GetAxis("Horizontal") * speed; // 左右（カメラ基準）

                            moveDirection = moveZ + moveX;
                            if (Input.GetButtonDown("V"))
                            {
                                player_attitude = 0;
                                break;
                            }
                        }
                        else
                        {
                            // 重力を効かせる
                            moveDirection = moveZ + moveX + new Vector3(0, moveDirection.y, 0);
                            moveDirection.y -= gravity * Time.deltaTime;
                        }

                        
                
                        // 移動のアニメーション
                        //anim.SetFloat("MoveSpeed", (moveZ + moveX).magnitude);
                
                        rb.AddForce(moveDirection * Time.deltaTime);
                break;
                
            }
        
        


        if(Input.GetKey(KeyCode.Alpha0))
        {
            
            gameObject.transform.position = new Vector3(0f,10f,0f);

        }


        // 移動速度を取得
        /*float speed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : normalSpeed;
         
        // カメラの向きを基準にした正面方向のベクトル
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward,new Vector3(1, 0, 1)).normalized;
 
        // 前後左右の入力（WASDキー）から、移動のためのベクトルを計算
        // Input.GetAxis("Vertical") は前後（WSキー）の入力値
        // Input.GetAxis("Horizontal") は左右（ADキー）の入力値
        Vector3 moveZ = cameraForward * Input.GetAxis("Vertical") * speed;  //　前後（カメラ基準）　 
        Vector3 moveX = Camera.main.transform.right * Input.GetAxis("Horizontal") * speed; // 左右（カメラ基準）
             
        // isGrounded は地面にいるかどうかを判定します
        // 地面にいるときはジャンプを可能に
        //if (con.isGrounded)
        //{
            moveDirection = moveZ + moveX;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jump;
            }
        //}
        else
        {
            // 重力を効かせる
            moveDirection = moveZ + moveX + new Vector3(0, moveDirection.y, 0);
            moveDirection.y -= gravity * Time.deltaTime;
        }
 
        // 移動のアニメーション
        //anim.SetFloat("MoveSpeed", (moveZ + moveX).magnitude);
 
        // プレイヤーの向きを入力の向きに変更　
        transform.LookAt(transform.position + moveZ + moveX);
 
        // Move は指定したベクトルだけ移動させる命令
        //con.Move(moveDirection * Time.deltaTime);
        */
        
    }
    void FixedUpdate()
    {
        
        rb.AddForce(moveDirection * Time.deltaTime ,ForceMode.Impulse);
        
    }
}
