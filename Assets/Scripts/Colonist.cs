using UnityEngine;

public class Colonist : MonoBehaviour
{
    public string Name = "Taro";
    public float MoveSpeed = 2.0f;

    private Vector3 targetPosition=new Vector3(2,0,2);


    //ｹﾞｰﾑの初回に一回だけ実行される

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

     Debug.Log($"{Name}がコロニーに到着しました");
        SetRandomTarget();
    }

    // ゲームの実行中、常に実行される

    void Update()
    {

        //移動したい。移動するのに必要なのは自分の位置と、行くべき場所。
        //自分の位置をtargetPositionまで移動させる
        //.は接続しと考えてOK
        transform.position = Vector3.MoveTowards(
            transform.position, targetPosition, MoveSpeed * Time.deltaTime);
        //もし、()内の条件だったら、
        if(Vector3.Distance(transform.position,targetPosition)<0.1f)
        {
            //次のターゲットの位置を決める
            SetRandomTarget(); 
               };


    }

//うろつく位置を決める処理を入力する
void SetRandomTarget()

    {
        targetPosition = new Vector3(
            Random.Range(-5f,5f),0,Random.Range(-5f,5f));
    
    }
}
