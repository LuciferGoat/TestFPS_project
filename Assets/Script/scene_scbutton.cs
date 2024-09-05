using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class scene_scbutton : MonoBehaviour
{
     //[SerializeField]
    //TextMeshProUGUI button;

    //private int _count = 0;
    // Start is called before the first frame update
    void Start()
    {
        // .text = $"{_count}";
    }

    // Update is called once per frame
    void Update()
    {
        //if(){}
    }
    public void OnPressed()
    {
        Invoke("ChangeScene", 1.5f);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("Test_Scene1");
    }
}
