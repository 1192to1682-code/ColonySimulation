using UnityEngine;

public class Bakery : MonoBehaviour
{
    public float FoodStock = 100;

    /// <summary>
    /// 倉庫資源10→　食料1に変えるレート
    /// </summary>
    public float ExchangeRate = 10f;

    /// <summary>
    /// 再生速度(毎秒)
    /// </summary>
    public float ProduceRate = 1f;

    /// <summary>
    /// 倉庫の中を見たいので参照
    /// </summary>
    public Warehouse Warehouse;

    private float timer = 0f;

    private void Update()
    {

        timer += Time.deltaTime;

        if (ProduceRate <= timer)
        {

            ExchangeWithWarehouse();
            timer = 0f;
        }

    }


    public void ExchangeWithWarehouse()
    {
        if (Warehouse == null)
        {
            //ログの説明
            //参照されていなかったりすると困るので、Warningで注意喚起する
            Debug.LogWarning("WarehouseがUnityで設定されていません");

            //LogErrorにすると、ゲーム実行がストップする。
            //Debug.LogError("WarehouseがUnityで設定されていません");
            return;
        }
        if (Warehouse.HasEnough(ExchangeRate))
        {
            //倉庫から交換を行う
            Warehouse.Withdraw((int)ExchangeRate);
            //毎秒、FoodStockをProduceRateに合わせて加算していく
            FoodStock += ProduceRate ;


        }

    
    }


    /// <summary>
    /// ベーカリーで食事ができるかどうか
    /// </summary>
    /// <returns></returns>
    public bool CanEat()
    {
        return FoodStock > 0;
    }

    public void Eat()
    {
        FoodStock -= Time.deltaTime;
    }
}
