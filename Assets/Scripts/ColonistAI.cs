using UnityEngine;

public class ColonistAI : MonoBehaviour
{
    public enum ColonistState
    { 
        /// <summary>
        /// enum�^�Ő錾�����R���j�X�g�̏��
        /// </summary>

    Idle, //�ҋ@
    Move,�@//�ړ�
    Mine,�@//�@��
    Sleep�@//�A�Q

    }

    public ColonistState State;

    /// <summary>
    /// �R���j�X�g�̏�Ԃ�ύX���邽�߂̃^�C�}�[
    /// [SerealizeField]�̂悤�Ȃ��̂𑮐�(Attritude)�Ƃ���
    /// </summary>

    [SerializeField]
    private float timer = 2f;

    public float MoveSpeed = 2.0f;

    private Vector3 targetPosition = new Vector3(2, 0, 2);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //�R���j�X�g�̏�Ԃ�Idele(�ҋ@)����n�߂�
        State = ColonistState.Idle;

    }

    // Update is called once per frame
    void Update()
    {
        //1�t���[���ɂ����������Ԃ�timer���猸�Z���Ă����܂�

        timer -= Time.deltaTime;

        //���������̒��̒l(�ϐ�)���g���ď����𕪊�(switch)�����܂�
        switch (State)
        {

            case ColonistState.Idle:

                //case��break�̊ԂɁAcase�̏ꍇ�̏���������

                //�����^�C�}�[��0�b�����������
                if (timer <= 0f)
                {
                    //�R���j�X�g�N�̏�Ԃ𓮂��Ƃ�����ԂɕύX

                    State = ColonistState.Move;
                    //�^�[�Q�b�g�|�W�V���������߂Ă�����
                            targetPosition = new Vector3(
                            Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));

                    

                    timer = 2f;

                }

                break;
            case ColonistState.Move:
                {

                    //�ړ��������B�ړ�����̂ɕK�v�Ȃ͎̂����̈ʒu�ƁA�s���ׂ��ꏊ�B
                    //�����̈ʒu��targetPosition�܂ňړ�������
                    //.�͐ڑ����ƍl����OK

                    transform.position = Vector3.MoveTowards(
                        transform.position, targetPosition, MoveSpeed * Time.deltaTime);

                    //�����A()���̏�����������A
                    if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
                    {

                        //���̍s���������Ȃ�
                        State = ColonistState.Mine;
                        //�@�펞�Ԃ�1�`5�b�ɂ���
                        timer = Random.Range(1f,5f);

                     
                    }


                }

                break;
            case ColonistState.Mine:
                //���ō̌@�A�j���[�V�����Đ��̑���Ƀ��O���o�͂��܂�
                Debug.Log("Colonist is mining");

                //���t���[����]����������
                transform.Rotate(Vector3.up * 30f * Time.deltaTime);


                if (timer <= 0f)
                {
                    State = ColonistState.Sleep;
                    timer = Random.Range(1f,5f);
                                      
                    //State = ColonistState.Idle;
                    //timer = 2f;
                    //State��ColonistState.Sleep�ɕύX���Ă��������B
                    //timer��10�b�Őݒ肵�Ă��������B
                }

                break;
            case ColonistState.Sleep:

                //�����Atimer��0�b�����������AState��Idle�ɕύX���܂��傤�B
                //timer��2�b�Őݒ肵�Ă�������.
                if (timer <= 0f)
                 {
                    State = ColonistState.Idle;
                    timer = 2f;

                }



                break;
        
        }


    }
}
