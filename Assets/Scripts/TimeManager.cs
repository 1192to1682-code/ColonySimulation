using UnityEngine;
using UnityEngine.UI;
//ボタンやテキストを表示する

public class TimeManager : MonoBehaviour
{
    public Button PauseButton;
    public Button PlayButton;//1倍速
    public Button Speed2Xbutton;//2倍速
    public Button Speed3Xbutton;//3倍速

    public AudioClip stopSE;
    public AudioClip PlaySE;
    public AudioClip SpeedUpSE;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //ゲーム開始時は塔倍速にしておく
        SetTimeScale(1f);
        PauseButton.onClick.AddListener(() =>

        {
            SetTimeScale(0f);
            SEManager.Instance.PlaySE(stopSE);
        });


        PlayButton.onClick.AddListener(() =>
        {
            SetTimeScale(1f);
            SEManager.Instance.PlaySE(PlaySE);
        });

        Speed2Xbutton.onClick.AddListener(() =>
        {
            SetTimeScale(2f);
            SEManager.Instance.PlaySE(SpeedUpSE);
        });


        Speed3Xbutton.onClick.AddListener(() =>
        {

            SetTimeScale(3f);
            SEManager.Instance.PlaySE(SpeedUpSE);
        });

    }

    /// <summary>
    /// 時間の倍速設定を引数の値によって行う
    /// </summary>
    /// <param name="scale"></param>
    private void SetTimeScale(float scale)
    {
        Time.timeScale = scale;
        Debug.Log($"TimeScale:{scale}");
        SetButtonColor(scale);
    }
        private void SetButtonColor(float scale)
        {

        switch (scale)

        {

            case 0f:                
                PauseButton.image.color = Color.white;
                PlayButton.image.color = Color.gray5;
                Speed2Xbutton.image.color = Color. gray5;
                Speed3Xbutton.image.color = Color.gray5;
                break;


            case 1f:
                PauseButton.image.color = Color.gray5;
                PlayButton.image.color = Color.white;
                Speed2Xbutton.image.color = Color.gray5;
                Speed3Xbutton.image.color = Color.gray5;
                break;


            case 2f:
                PauseButton.image.color = Color.gray5;
                PlayButton.image.color = Color.gray5;
                Speed2Xbutton.image.color = Color.white;
                Speed3Xbutton.image.color = Color.gray5;
                break;

            case 3f:
                PauseButton.image.color = Color.gray5;
                PlayButton.image.color = Color.gray5;
                Speed2Xbutton.image.color = Color.gray5;
                Speed3Xbutton.image.color = Color.white;
                break;











        }

        }
    

}
