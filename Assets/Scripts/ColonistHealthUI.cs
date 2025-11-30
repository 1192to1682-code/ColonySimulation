using UnityEngine;
using UnityEngine.UI; 


public class ColonistHealthUI : MonoBehaviour
{
    /// <summary>
    /// 体力を参照させるため
    /// </summary>
    public ColonistAI ColonistAI;

    public Image healthBar;

    /// <summary>
    /// ストレス値のバー
    /// </summary>
    public Image StressBar;

    /// <summary>
    /// 空腹値用のバー
    /// </summary>
    public Image HungerBar;

    // Update is called once per frame
    void Update()
    {
        //HealthBarに現在の体力/最大の体力で出る割合を表示
        healthBar.fillAmount = ColonistAI.GetCurrentHealth / ColonistAI.MaxHealth;

        HungerBar.fillAmount 
            =ColonistAI.GetHunger / 100; 


        StressBar.fillAmount
            = ColonistAI.GetStress / 100; 

        
    }
}
