using UnityEngine;

public class Colonist : MonoBehaviour
{
    public string Name = "Taro";
    public float MoveSpeed = 2.0f;

    private Vector3 targetPosition=new Vector3(2,0,2);


    //�ްт̏���Ɉ�񂾂����s�����

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

     Debug.Log($"{Name}���R���j�[�ɓ������܂���");
        SetRandomTarget();
    }

    // �Q�[���̎��s���A��Ɏ��s�����

    void Update()
    {

        //�ړ��������B�ړ�����̂ɕK�v�Ȃ͎̂����̈ʒu�ƁA�s���ׂ��ꏊ�B
        //�����̈ʒu��targetPosition�܂ňړ�������
        //.�͐ڑ����ƍl����OK
        transform.position = Vector3.MoveTowards(
            transform.position, targetPosition, MoveSpeed * Time.deltaTime);
        //�����A()���̏�����������A
        if(Vector3.Distance(transform.position,targetPosition)<0.1f)
        {
            //���̃^�[�Q�b�g�̈ʒu�����߂�
            SetRandomTarget(); 
               };


    }

//������ʒu�����߂鏈������͂���
void SetRandomTarget()

    {
        targetPosition = new Vector3(
            Random.Range(-5f,5f),0,Random.Range(-5f,5f));
    
    }
}
