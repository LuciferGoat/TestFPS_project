using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_for_Player : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI start_Text;
    [SerializeField]
    private TextMeshProUGUI stop_Text;
    [SerializeField]
    private Canvas canvas_start;
    [SerializeField]
    private Canvas canvas_stop;

    [SerializeField]
    private Canvas canvas_;
    
    [SerializeField]
    private Canvas canvas_Dot1;
    [SerializeField]
    private Canvas canvas_Dot2;

    [SerializeField]
    private Canvas canvas_ScoreClay;
    [SerializeField]
    public TextMeshProUGUI score_clay_tmp;

    [SerializeField]
    public GameObject scoreObj_clay;
    public Player player_u;

    [SerializeField]
    public int UI_s;
    [SerializeField] 
    public int UI_canv;
    [SerializeField]  
    public static bool UI_dot;
    [SerializeField] 
    public int playerUI;

    [SerializeField] 
    public static int Score_clay;

    // Start is called before the first frame update
    void Start()
    {
        UI_s = 0;
        UI_canv = 0;
        UI_dot = false;
        canvas_.enabled = false;
        canvas_start.enabled = false;
        canvas_stop.enabled = false;
        canvas_Dot1.enabled = false;
        canvas_Dot2.enabled = false;

        canvas_ScoreClay.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.SN_p == 0)
        {
            if(scoreObj_clay.gameObject.TryGetComponent(out TMP_Text scoreTMPro))
            {
                scoreTMPro.text = "score:"+ Score_clay.ToString();
            }
            
            if(UI_dot)
            {
                canvas_Dot1.enabled = true;
                canvas_Dot2.enabled = true;
            }
            else
            {
                canvas_Dot1.enabled = false;
                canvas_Dot2.enabled = false;
            }

            switch (UI_s)
            {
                case 0:
                    canvas_.enabled = false;
                    canvas_start.enabled = false;
                    canvas_stop.enabled = false;
                break;

                case 1:
                    canvas_.enabled = true;
                    canvas_start.enabled = true;
                    canvas_stop.enabled = false;
                break;

                case 2:
                    canvas_.enabled = true;
                    canvas_start.enabled = false;
                    canvas_stop.enabled = true;
                break;
            }
        }
        else
        {

        }
    }
}
