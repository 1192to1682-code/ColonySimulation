using UnityEngine;



public class ColonistUIManager : MonoBehaviour
{
    private ColonistHealthUI colonistHealthUI;

    private ColonistStatusUI colonistStatusUI;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
   /// <summary>
   /// awake()はstartを実行前に実行される。初期化用メソッド。
   /// </summary>
    void Awake()
    {

        //GercomponentInchildrenはヒエラルキーwindowの
        //このコンポーネントがついかされたgameObjectの階層下から取得する
        colonistHealthUI = GetComponentInChildren<ColonistHealthUI>();
        colonistStatusUI = GetComponentInChildren<ColonistStatusUI>();
        
    }


    //ColonistUIManager君が持っている2つのコンポーネントにColonistAIを渡してあげたい
    //小()の中身は引数と言って
    //引数に渡された物は、この処理の中で使う事ができる
   public void SetColonistAI(ColonistAI colonistAI)
    {
        colonistHealthUI.ColonistAI = colonistAI;
        colonistStatusUI.ColonistAI = colonistAI;

    }

}