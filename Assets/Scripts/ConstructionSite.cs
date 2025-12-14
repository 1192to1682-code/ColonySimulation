using UnityEngine;

public class ConstructionSite : MonoBehaviour

   
{
    public string BuildingName = "House";
    /// <summary>
    /// 作業が完成したときに生成するGameObject(HouseやBakeryなどの建物)
    /// </summary>
    public GameObject CompletedPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    /// <summary>
    /// コロニストに位置を知らせるためのTransform変数
    /// </summary>
    public Transform BuildPoint;

    /// <summary>
    /// 工事が完了するのに必要な作業量
    /// </summary>
    public float RequiredWork = 100f;

    /// <summary>
    /// Workの仕事量に対して消費される資産
    /// </summary>
    public float ResourcePerWork = 1f;

    /// <summary>
    /// 資産の値を参照したいので、倉庫のコンポーネントを参照させる
    /// </summary>
    public Warehouse Warehouse;


    /// <summary>
    /// 今どれくらい作業しているか
    /// </summary>
    private float currentWork = 0f;

    public bool IsCompleted {
        get { return currentWork >= RequiredWork; }
    }
    /// <summary>
    /// 現状の作業達成度
    /// </summary>
    public float GetProgress
    {
        get { return currentWork / RequiredWork; }

    }

    public bool Build(float workAmount)
    {
        if (IsCompleted) 
        
        {
            return true;
        }

        //倉庫の資産を使いたいが、倉庫の参照がない場合、計算できないのでfalseを返します

        if(Warehouse ==null)
        {
            return false;
        }

        float requiredResource = workAmount * ResourcePerWork;

        if (!Warehouse.HasEnough((int)requiredResource))
        {
            //必要な資産がない場合はfalseを返す

            return false;
        }
            Warehouse.Withdraw((int)requiredResource);

            //ここから
            currentWork += workAmount;

            if (IsCompleted)
            {

                //建築完了のメソッドを実行する
                CompleteBuilding();
            }

            return true;
     }



    
     private void CompleteBuilding()
    {
        Debug.Log($"{BuildingName}の建築が完了しました");
        //完了時の建物が指定されていたら
        if (CompletedPrefab != null)
        {
            //CompletedPrefabをConstruvtionSiteの位置に生成します
            Instantiate(CompletedPrefab, this.transform.position, Quaternion.identity);
        }

        //ConstruvtionSiteのObjectのアクティブを切ります
        this.gameObject.SetActive(false);

    }

    public Vector3 GetBuildposition()
    {
        if (BuildPoint != null)
        {
            return BuildPoint.position;
        }
        //そうじゃなかったら、ConstructionSiteの世界座標を返します
        return this.transform.position;

    }
}
