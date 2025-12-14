using UnityEngine;

/// <summary>
/// Sleepの時にHouseで寝る
/// </summary>

public class House : MonoBehaviour
{
    /// <summary>
    /// 家で休む際のボーナス
    /// </summary>
    public float RecoveryBonus = 2f;

    public Vector3 GetHousePosition()
    {
        return this.transform.position;
    
    }


}
