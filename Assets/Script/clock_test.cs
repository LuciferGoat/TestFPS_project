using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using System; //DateTimeを使用する為追加。
using UnityEngine.UI; //Textを使用する為追加。
using TMPro;
public class clock_test : MonoBehaviour
{
    // Start is called before the first frame update
        [SerializeField] TMP_Text DateTimeText;

    DateTime dt;



    void Start()
    {
        // Debug.Log(100);

         dt = DateTime.Now;




         
    }

    // Update is called once per frame
    void Update()
    {
        //DateTimeText.text = dt.Year.ToString() + "年 " + dt.Month.ToString() + "月" + dt.Day.ToString() + "日" + DateTime.Now.ToLongTimeString();
       //DateTimeText.text = dt.Year.ToString() + ":" + dt.Month.ToString() + ":" + dt.Day.ToString() + ":" +"\n" + DateTime.Now.ToLongTimeString();
    DateTimeText.text = dt.Year.ToString() + ":" + dt.Month.ToString() + ":" + dt.Day.ToString()  +"\n" + DateTime.Now.ToLongTimeString();
    
    
    }
}