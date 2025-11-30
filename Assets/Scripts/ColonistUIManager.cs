using TMPro;
using UnityEngine;



public class ColonistUIManager : MonoBehaviour
{
    private ColonistHealthUI colonistHealthUI;

    private ColonistStatusUI colonistStatusUI;

    private JobSwitchUI switchUI;


    public TextMeshProUGUI NameText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
   /// <summary>
   /// awake()はstartを実行前に実行される。初期化用メソッド。
   /// </summary>
    void Awake()
    {

        //GetcomponentInchildrenはヒエラルキーwindowの
        //このコンポーネントがついかされたgameObjectの階層下から取得する
        colonistHealthUI = GetComponentInChildren<ColonistHealthUI>();
        colonistStatusUI = GetComponentInChildren<ColonistStatusUI>();
        switchUI = GetComponentInChildren<JobSwitchUI>();
        
    }


    //ColonistUIManager君が持っている2つのコンポーネントにColonistAIを渡してあげたい
    //小()の中身は引数と言って
    //引数に渡された物は、この処理の中で使う事ができる
   public void SetColonistAI(ColonistAI colonistAI)
    {
        colonistHealthUI.ColonistAI = colonistAI;
        colonistStatusUI.ColonistAI = colonistAI;

        //JobSwitchUIにcolonistAIを割り当てる
        switchUI.SetSwitchUI(colonistAI);

        //名前の表示を行う
        NameText.text = colonistAI.gameObject.name;

    }

}