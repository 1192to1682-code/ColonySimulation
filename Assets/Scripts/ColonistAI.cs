using UnityEngine;
//UnityEngineのUIの要素を使う宣言
using UnityEngine.UI;

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
    /// <summary>

    [SerializeField]
    private float timer = 2f;

    public float MoveSpeed = 2.0f;

    private Vector3 targetPosition = new Vector3(2, 0, 2);


    /// <summary>
    /// <最大体力値>
    /// </summary>
   
    public float MaxHealth = 100f;


    /// <summary>
    /// <既存の体力値>
    /// </summary>
    /// 
    [SerializeField]
    private float currentHealth;

    public float GetCurrentHealth
    {
        get { return currentHealth; }

    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //コロニストの状態をIdele(待機)から始める
        State = ColonistState.Idle;

        //現在の体力をmaxにする
        currentHealth = MaxHealth;

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

                currentHealth += 2f* Time.deltaTime;

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

                    //現在の体力値から1秒間で5ポイント体力を減らす
                    currentHealth -= 5f * Time.deltaTime;

                    if (currentHealth <= 20f)
                    {

                        //回復のために眠らせる
                        State = ColonistState.Sleep;
                    }

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

                //現在の体力を10P減らす
                currentHealth -= 10f + Time.deltaTime;

                //現在の体力が20ポイントを下回ったら
                if (currentHealth <= 20f)
                {

                    //体力が20を下回ったら眠らせる
                    State = ColonistState.Sleep;
                }

                if (timer <= 0f)
                {
                    State = ColonistState.Idle;
                    timer = Random.Range(1f,5f);
                                      
                    //State = ColonistState.Idle;
                    //timer = 2f;
                    //StateをColonistState.Sleepに変更してください。
                    //timerを10秒で設定してください。
                }

                break;
            case ColonistState.Sleep:

                //1秒間に8回復させる
                currentHealth += 8f * Time.deltaTime;

                //もし、コロニストの体力が完全に回復したら。
                if (currentHealth >= MaxHealth)
                 {
                    State = ColonistState.Idle;
                    timer = 2f;

                }



                break;
        
        }


    }
}
