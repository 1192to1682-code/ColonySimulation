using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JobSwitchUI : MonoBehaviour

{
    /// <summary>
    /// 
    /// 
    /// </summary>
    public ColonistAI ColonistAI;

    public Button SwitchButton;


    /// <summary>
    /// Jobの名前を表示するための機能
    /// </summary>
    public TextMeshProUGUI JobLabel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    /// <summary>
    /// ColonistUIManagerさんから呼ばれることを想定
    /// </summary>
    /// <param name="colonistAI"></param>
    public void SetSwitchUI(ColonistAI colonistAI)
    {
        this.ColonistAI = colonistAI;
        SwitchButton.onClick.AddListener(ToggleJob);
        UpdateLabel();

    }


    public void ToggleJob()
    {

        if (ColonistAI.Job == ColonistAI.JobType.Miner)
        {
            ColonistAI.Job = ColonistAI.JobType.Carrier;

        }
        //そうじゃなくって運搬者だったら
        else if (ColonistAI.Job == ColonistAI.JobType.Carrier)
        {
            ColonistAI.Job = ColonistAI.JobType.Miner;

        }
        UpdateLabel();

    }
    void UpdateLabel()
    {
     JobLabel.text = $"Job:{ColonistAI.Job}";

    }

}


