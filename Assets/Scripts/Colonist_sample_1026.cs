using UnityEngine;

public class Colonist_sample_1026 : MonoBehaviour
{

    public enum ColonistState
    { 
    
    Move,//ˆÚ“®
    
    }

    public ColonistState State;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Colonist‚Ìó‘Ô‚ğMove‚Ìó‘Ô‚©‚çn‚ß‚é
        State = ColonistState.Move;


    }

    [SerializeField]
    private float timer = 2f;

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;
        
    }
}
