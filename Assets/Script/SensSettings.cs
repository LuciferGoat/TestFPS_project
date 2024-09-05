using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SensSettings : MonoBehaviour
{
    private float sensv = 60.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FexedUpdate()
    {
        // float xMovement = Input.GetAxis("Horizontal") * sensv  * Time.deltaTime; // 左右の移動
        // float zMovement = Input.GetAxis("Vertical") * sensv * Time.deltaTime; // 前後の移動
        // transform.Translate(xMovement, 0, zMovement); // オブジェクトの位置を更新

        // float my = Input.GetAxis("Mouse Y");//マウスの縦方向の移動量を取得
                
        // if (Mathf.Abs(my) > 0.001f)// Y方向に一定量移動していれば縦回転
        // {
        //     transform.RotateAround(player.transform.position, Vector3.right, -my);
        // }



        float mx = Input.GetAxis("Mouse X");//カーソルの横の移動量を取得
        float my = Input.GetAxis("Mouse Y");//カーソルの縦の移動量を取得
        if (Mathf.Abs(mx) > 0.001f) // X方向に一定量移動していれば横回転
        {
            transform.RotateAround(transform.position, Vector3.up, mx); // 回転軸はplayerオブジェクトのワールド座標Y軸
        
        }
                
        if (Mathf.Abs(my) > 0.001f)// Y方向に一定量移動していれば縦回転
        {
            transform.RotateAround(transform.position, Vector3.right, -my);
        }
    
    }
    
}
