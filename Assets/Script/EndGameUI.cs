using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameUI : MonoBehaviour
{
    public Canvas confirmationPanel;

    bool cursorLockUI;


    // Start is called before the first frame update
    void Start()
    {
        cursorLockUI = false;
        confirmationPanel.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateCursorLockUI();

        if (Input.GetKey(KeyCode.Escape))
        {
            Player.SN_p = 1;
            confirmation();
        }
        
            
    }

    public void confirmation()
    {
        Player.SN_p = 1;
        cursorLockUI = false;
        confirmationPanel.enabled = true;
    }
    public void confirmation_null()
    {
        cursorLockUI = true;
        confirmationPanel.enabled = false;
        Player.SN_p = 0;
    }
    

    //ゲーム終了
    public void EndGame()
    {
            #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
            #else
                Application.Quit();//ゲームプレイ終了
            #endif

    }

    /*public void UpdateCursorLockUI()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLockUI = false;
        }
        else if(Input.GetMouseButton(0))
        {
            //cursorLock = true;
        }

        if (cursorLockUI)
        {
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        }
        else if(!cursorLockUI)
        {
            UnityEngine.Cursor.lockState = CursorLockMode.None;
        }
    }*/
}
