using UnityEngine;
using UnityEngine.UI; 


public class ColonistHealthUI : MonoBehaviour
{
    /// <summary>
    /// ‘Ì—Í‚ğQÆ‚³‚¹‚é‚½‚ß
    /// </summary>
    public ColonistAI ColonistAI;

    public Image healthBar;

    // Update is called once per frame
    void Update()
    {
        //HealthBar‚ÉŒ»İ‚Ì‘Ì—Í/Å‘å‚Ì‘Ì—Í‚Åo‚éŠ„‡‚ğ•\¦
        healthBar.fillAmount = ColonistAI.GetCurrentHealth / ColonistAI.MaxHealth;

        
    }
}
