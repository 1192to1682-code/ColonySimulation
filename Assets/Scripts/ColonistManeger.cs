using UnityEngine;
using UnityEngine.InputSystem;


public class ColonistManeger : MonoBehaviour
{

    /// <summary>
    /// []�͔z��ƌ����A1�̕ϐ��̒��ŕ�����colonistAI���Ǘ��ł���B
    /// </summary>
    public ColonistAI[] Colonists;
       

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            
            //for����(�����l�A�����l���w��̒l�ɂȂ�܂ŁA�����l�𑝌�������)�Ƃ���������
            //�����l���w��̒l�ɂȂ�܂ł̉񐔏������s��
        for (int i = 0;i< Colonists.Length; i++)

            {

                Colonists[i].State = ColonistAI.ColonistState.Mine;

            }
        }
        

    }
}
