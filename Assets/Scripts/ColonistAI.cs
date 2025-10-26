using UnityEngine;

public class ColonistAI : MonoBehaviour
{
    public enum ColonistState
    { 
        /// <summary>
        /// enum型で宣言したコロニストの状態
        /// </summary>

    Idle, //待機
    Move,　//移動
    Mine,　//掘削
    Sleep　//就寝

    }

    public ColonistState State;

    /// <summary>
    /// コロニストの状態を変更するためのタイマー
    /// [SerealizeField]のようなものを属性(Attritude)という
    /// </summary>

    [SerializeField]
    private float timer = 2f;

    public float MoveSpeed = 2.0f;

    private Vector3 targetPosition = new Vector3(2, 0, 2);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //コロニストの状態をIdele(待機)から始める
        State = ColonistState.Idle;

    }

    // Update is called once per frame
    void Update()
    {
        //1フレームにかかった時間をtimerから減算していきます

        timer -= Time.deltaTime;

        //小かっこの中の値(変数)を使って処理を分岐(switch)させます
        switch (State)
        {

            case ColonistState.Idle:

                //caseとbreakの間に、caseの場合の処理を書く

                //もしタイマーが0秒を下回ったら
                if (timer <= 0f)
                {
                    //コロニスト君の状態を動くという状態に変更

                    State = ColonistState.Move;
                    //ターゲットポジションを決めてあげる
                            targetPosition = new Vector3(
                            Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));

                    

                    timer = 2f;

                }

                break;
            case ColonistState.Move:
                {

                    //移動したい。移動するのに必要なのは自分の位置と、行くべき場所。
                    //自分の位置をtargetPositionまで移動させる
                    //.は接続しと考えてOK

                    transform.position = Vector3.MoveTowards(
                        transform.position, targetPosition, MoveSpeed * Time.deltaTime);

                    //もし、()内の条件だったら、
                    if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
                    {

                        //次の行動をおこなう
                        State = ColonistState.Mine;
                        //掘削時間を1～5秒にする
                        timer = Random.Range(1f,5f);

                     
                    }


                }

                break;
            case ColonistState.Mine:
                //仮で採掘アニメーション再生の代わりにログを出力します
                Debug.Log("Colonist is mining");

                //毎フレーム回転させ続ける
                transform.Rotate(Vector3.up * 30f * Time.deltaTime);


                if (timer <= 0f)
                {
                    State = ColonistState.Sleep;
                    timer = Random.Range(1f,5f);
                                      
                    //State = ColonistState.Idle;
                    //timer = 2f;
                    //StateをColonistState.Sleepに変更してください。
                    //timerを10秒で設定してください。
                }

                break;
            case ColonistState.Sleep:

                //もし、timerが0秒を下回ったら、StateをIdleに変更しましょう。
                //timerを2秒で設定してください.
                if (timer <= 0f)
                 {
                    State = ColonistState.Idle;
                    timer = 2f;

                }



                break;
        
        }


    }
}
