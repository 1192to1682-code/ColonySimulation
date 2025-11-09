//UnityEngineのUIの要素を使う宣言
using UnityEngine;
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
    Sleep,　//就寝
　　Carry,//運ぶ
  Rest,//休憩
　　Dead //死亡

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

    public Vector3 tarnetPosition = new Vector3(2, 0, 2);


    /// <summary>
    /// 採掘場の位置
    /// </summary>
    public Vector3 MinePoint;


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

    /// <summary>
    ///疲労回復速度
    /// </summary>
    public float RecoveryRate = 1f;

    /// <summary>
    /// 疲れやすさ
    /// </summary>
    public float FatigueRate = 1f;

    /// <summary>
    /// コロニストの年齢
    /// </summary>
    public int ColonistAge = 20;

    /// <summary>
    /// 年齢によって色を変更する
    /// </summary>

    public Material YoungMaterial;
    public Material NormalMaterial;
    public Material OldMaterial;

    /// <summary>
    /// Colonistの3Dモデル表示部分
    /// </summary>
    private MeshRenderer[] colonistMeshRenderers = new MeshRenderer[2];

    /// <summary>
    /// 掘削スキルが高いほど速い
    /// </summary>
  
    [Range(0.5f,3f)]
    public float MiningSkill = 1f;

    public int Minedsource = 10;

    /// <summary>
    /// 空腹度
    /// </summary>
    private float hunger = 100f;

    /// <summary>
    /// ストレス
    /// </summary>

    public float stress = 0f;

    public bool IsAlive
    {
        //boolは真偽の判定になるので、条件を作ることができます
        //今回は体力があって、空腹度も飢えていないとします
        //||は""もしくは""です。
        get { return currentHealth > 0 || hunger > 0; }
    }

    public Transform WareHouse;

    public Transform MarketPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //コロニストの状態をIdele(待機)から始める
        State = ColonistState.Idle;

        //現在の体力をmaxにする
        currentHealth = MaxHealth;

        //3d表示部分を取得
        colonistMeshRenderers = GetComponentsInChildren<MeshRenderer>();


        ColonistAge = Random.Range(18, 70);


        if (ColonistAge < 20)
        {
            RecoveryRate = 2f;
            FatigueRate = 0.5f;
            MoveSpeed = 5f;
            MiningSkill = 3f;

            //foreach文は配列に対して、全ての要素に変更を加えたい時に使います
            foreach (var renderer in colonistMeshRenderers)
            {

                renderer.material = YoungMaterial;
            
            }
        }

        else if (ColonistAge < 40)//else ifは''(ifの条件)じゃない場合''

        {
            RecoveryRate = 1f;
            FatigueRate = 1f;
            MoveSpeed = 2f;
            MiningSkill = 2f;


            //foreach文は配列に対して、全ての要素に変更を加えたい時に使います
            foreach (var renderer in colonistMeshRenderers)
            {

                renderer.material = NormalMaterial;

            }

        }
        else {
            RecoveryRate = 0.8f;
            FatigueRate = 2f;
            MoveSpeed = 0.5f;
            MiningSkill = 1f;

            //foreach文は配列に対して、全ての要素に変更を加えたい時に使います
            foreach (var renderer in colonistMeshRenderers)
            {

                renderer.material = OldMaterial;


            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        //!は否定の意味。!（bool変数）でbool型の変数の反対の判定をします。
        //生存していなかったら
        if (!IsAlive) {

            State = ColonistState.Dead;
            Debug.Log($"死亡しました");
            return;
        }
        //1フレームにかかった時間をtimerから減算していきます

        timer -= Time.deltaTime;

        //1秒間に2ポイントづつ空腹になる
        hunger -= 2f * Time.deltaTime;

        //1秒間に1ポイントづつ、ストレスがかかっていきます
        stress += 1f * Time.deltaTime;

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
                    targetPosition = MinePoint;

                    

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
                    currentHealth -=FatigueRate* 5f * Time.deltaTime;
                    //空腹度も1秒間に5ポイトづつ回復
                    hunger += 5f * Time.deltaTime;

                    //ストレスも1秒間にポイントづつ現象する
                    stress -= 5f * Time.deltaTime;

                   
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
                //1秒間にminingSkillが3の人は1秒間に360ド回転する
                transform.Rotate(Vector3.up * 120f *MiningSkill* Time.deltaTime);

                //現在の体力を10P減らす
                currentHealth -=FatigueRate* 10f * Time.deltaTime;

                //現在の体力が20ポイントを下回ったら
                if (currentHealth <= 20f)
                {

                    //体力が20を下回ったら眠らせる
                    State = ColonistState.Sleep;
                }

                if (timer <= 0f)
                {
                    int mined = Mathf.RoundToInt(10 * MiningSkill);
                    Minedsource += mined;
                    Debug.Log($"採掘完了");

                    State = ColonistState.Idle;
                    timer = Random.Range(1f,5f);

                    State = ColonistState.Carry;

                    
                    //移動先を倉庫の位置にする
                    targetPosition = WareHouse.position;


                }

                break;
                               
            case ColonistState.Carry://運ぶ状態
                transform.position = Vector3.MoveTowards(
                       transform.position, targetPosition, MoveSpeed * Time.deltaTime);


                //体力が回復するまで休ませる？
                //体力があったらもう1回Moveにして採掘場に向かわせるか。
                //休憩場所に言って、休憩する.
                if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
                {

                    //次の行動をおこなう(休憩)
                    State = ColonistState.Rest;
                    //掘削時間を1～5秒にする
                    timer = Random.Range(1f, 5f);

                    targetPosition = MarketPosition.position;

                }

                break;

            case ColonistState.Rest://休憩の状態
                                transform.position = Vector3.MoveTowards(
                       transform.position, targetPosition, MoveSpeed * Time.deltaTime);
                if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
                {

                    hunger += 5f * Time.deltaTime;
                    stress -=5f * Time.deltaTime;
                    currentHealth +=RecoveryRate *2f* Time.deltaTime;

                    if (currentHealth > 80f && hunger > 80)
                    {
                        timer = 1f;
                        //状態を待機状態に戻す
                        State = ColonistState.Idle;
                    }

                }

                break;
            case ColonistState.Sleep:

                //1秒間に8回復させる
                currentHealth +=RecoveryRate* 8f * Time.deltaTime;
                if (currentHealth >= MaxHealth)
                                       
                 {
                    State = ColonistState.Idle;
                    timer = 2f;

                }



                break;
        
        }


    }
}
