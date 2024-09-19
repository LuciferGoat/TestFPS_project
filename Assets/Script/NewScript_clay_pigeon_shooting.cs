using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewScript_clay_pigeon_shooting : MonoBehaviour
{

    private bool clay_pigeon_shooting;

    public int timer = 5;

    bool key;

    public int countClay;


    public GameObject shot_pos1;
    public GameObject shot_pos2;
    public GameObject shot_pos3;
    public GameObject shot_pos4;
    public GameObject shot_pos5;
    public GameObject shot_pos6;

    public GameObject shell;
    public float shotSpeed;

    private int playerSnp;

    private bool pushF = false;
    private bool recust = false;

    private Vector3 shotVec;



    // Start is called before the first frame update
    void Start()
    {
        clay_pigeon_shooting = false;

        countClay = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(shotSpeed == 0)
        {
            shotSpeed = 100f;
        }

        if(Input.GetKeyUp(KeyCode.F))
        {
            pushF = false;
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            
            if(other.gameObject.TryGetComponent(out Player Player))
            {
                playerSnp = Player.SN_p;
                if(other.gameObject.TryGetComponent(out UI_for_Player UI_for_player1)){
                Debug.Log("P");
                if(Player.SN_p == 0)
                {
                    if(clay_pigeon_shooting)
                    {
                        UI_for_player1.UI_s = 0;
                        UI_for_Player.UI_dot= false;
                        clay_pigeon_shooting = true;
                    }
                    else
                    {
                        //UI_for_player.UI_canv = 1;
                        UI_for_player1.UI_s = 1;
                        UI_for_Player.UI_dot= true;

                        if(Input.GetKeyDown(KeyCode.F))
                        {
                            pushF = true;
                            UI_for_player1.UI_s = 0;
                            UI_for_Player.UI_dot= false;
                            clay_pigeon_shooting = true;

                            UI_for_Player.Score_clay = 0;
                            StartCoroutine(clay_pigeon_());
                        }

                    }
                        
                }
            }
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Player Player)&&other.TryGetComponent(out UI_for_Player UI_for_player1))
            {
                UI_for_player1.UI_s = 0;
                UI_for_Player.UI_dot= false;
                
            }
    }

    private IEnumerator clay_pigeon_()
    {
        if(Input.GetKeyDown(KeyCode.F)&& pushF==false && clay_pigeon_shooting)
        {
            clay_pigeon_shooting = false;
            yield break;
        }
        if(clay_pigeon_shooting)
        {
            for(int i = 0;i < 30;i++)
            {
                    yield return new WaitForSeconds(5);

                    recust = true;
                    StartCoroutine(clay_pigeon_shoot(Random.Range(1,7)));
                    countClay++;
            }
            yield return new WaitForSeconds(timer);
            clay_pigeon_shooting = false;
            countClay = 0;
            yield break;
        }


        
    }
    private IEnumerator clay_pigeon_shoot(int a)
    {
        GameObject shell_C;
        Rigidbody shell_CRb;

        float rand_f1 = Random.Range(-1.0f,1.0f);
        float rand_f2 = Random.Range(0.0f,1.0f);
        switch (a)
        {
            
            case 1:
                
                shell_C = Instantiate(shell,shot_pos1.transform.position,Quaternion.Euler(shot_pos1.transform.eulerAngles.x, shot_pos1.transform.eulerAngles.y, 0));
                shell_CRb = shell_C.GetComponent<Rigidbody>();
                shotVec = shell_C.transform.forward* shotSpeed * 10f ;// + new Vector3(0.0f,rand_f2,rand_f1);
                shell_CRb.AddForce(shotVec * Time.deltaTime,ForceMode.Impulse);

                //Destroy(shell_C, 4.0f);
            break;

            case 2:
                shell_C = Instantiate(shell,shot_pos2.transform.position,Quaternion.Euler(shot_pos2.transform.eulerAngles.x, shot_pos2.transform.eulerAngles.y, 0));
                shell_CRb = shell_C.GetComponent<Rigidbody>();
                shotVec = shell_C.transform.forward* shotSpeed * 10f;// + new Vector3(0.0f,rand_f2,rand_f1);
                shell_CRb.AddForce(shotVec * Time.deltaTime ,ForceMode.Impulse);

                //Destroy(shell_C, 4.0f);
            break;

            case 3:
                shell_C = Instantiate(shell,shot_pos3.transform.position,Quaternion.Euler(shot_pos3.transform.eulerAngles.x, shot_pos3.transform.eulerAngles.y, 0));
                shell_CRb = shell_C.GetComponent<Rigidbody>();
                shotVec = shell_C.transform.forward * shotSpeed * 10f;// + new Vector3(0.0f,rand_f2,rand_f1);
                shell_CRb.AddForce(shotVec * Time.deltaTime ,ForceMode.Impulse);

                //Destroy(shell_C, 4.0f);
            break;

            case 4:
                shell_C = Instantiate(shell,shot_pos4.transform.position,Quaternion.Euler(shot_pos4.transform.eulerAngles.x, shot_pos4.transform.eulerAngles.y, 0)); 
                shell_CRb = shell_C.GetComponent<Rigidbody>();
                shotVec = shell_C.transform.forward* shotSpeed  * 10f;//  + new Vector3(0.0f,rand_f2,rand_f1);
                shell_CRb.AddForce(shotVec * Time.deltaTime ,ForceMode.Impulse);

                //Destroy(shell_C, 4.0f);
            break;

            case 5:
                shell_C = Instantiate(shell,shot_pos5.transform.position,Quaternion.Euler(shot_pos5.transform.eulerAngles.x, shot_pos5.transform.eulerAngles.y, 0)); 
                shell_CRb = shell_C.GetComponent<Rigidbody>();
                shotVec = shell_C.transform.forward * shotSpeed * 10f;//  + new Vector3(0.0f,rand_f2,rand_f1);
                shell_CRb.AddForce(shotVec * Time.deltaTime ,ForceMode.Impulse);

                //Destroy(shell_C, 4.0f);
            break;

            case 6:
                shell_C = Instantiate(shell,shot_pos6.transform.position,Quaternion.Euler(shot_pos6.transform.eulerAngles.x, shot_pos6.transform.eulerAngles.y, 0)); 
                shell_CRb = shell_C.GetComponent<Rigidbody>();
                shotVec = shell_C.transform.forward * shotSpeed * 10f;//  + new Vector3(0.0f,rand_f2,rand_f1);
                shell_CRb.AddForce(shotVec * Time.deltaTime ,ForceMode.Impulse);

                //Destroy(shell_C, 4.0f);
            break;
        }
        yield return new WaitForSeconds(timer);
        recust = false;
        

        //Rigidbody shell_CRb = shell_C.GetComponent<Rigidbody>();
        //shell_CRb.AddForce(transform.forward * shotSpeed);

        //Destroy(shell_C, 3.0f);
 
        yield break;
    }
}
