using UnityEngine;
using UnityEngine.InputSystem;


public class ColonistManeger : MonoBehaviour
{

    /// <summary>
    /// []は配列と言い、1つの変数の中で複数のcolonistAIを管理できる。
    /// </summary>
    public ColonistAI[] Colonists;
       

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            
            //for文は(初期値、初期値が指定の値になるまで、初期値を増減させる)という書き方
            //初期値が指定の値になるまでの回数処理を行う
        for (int i = 0;i< Colonists.Length; i++)

            {

                Colonists[i].State = ColonistAI.ColonistState.Mine;

            }
        }
        

    }
}
