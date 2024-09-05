using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Camera_s : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
         // MainCameraとplayerとの位置関係（方向＋距離）を求めて変数offsetに入れる
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         transform.position = player.transform.position + offset;
    }
}
