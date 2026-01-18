using UnityEngine;

public class SEManager : MonoBehaviour
{

    /// <summary>
    /// SEMangaerをどこからでも呼べるようにするstatic変数を用意します
    /// static修飾子をつけると、ゲーム実行時にどこからでも参照することができます。
    /// </summary>
    public static SEManager Instance;

    /// <summary>
    /// AudioSourceは音をならすためのスピーカの役割をするコンポーネント
    /// </summary>
    private AudioSource SEAudiosource;

    /// <summary>
    /// Startが実行されるより前に実行されるメソッド
    /// 主に初期化などを行う時に使われる
    /// </summary>
    private void Awake()
    {
        Instance = this;
        if (SEAudiosource == null)
     //Addcomponentはこのクラスが追加されたGameObjectに、
     //指定したコンポーネントを追加したいときに使います。
     SEAudiosource = this.gameObject.AddComponent<AudioSource>();

    }

    /// <summary>
    /// SEを再生するためのメソッド
    /// 引数のAudioClip(mp3ファイル等)の音源をAudioSourceに再生させる
    /// </summary>
    /// <param name="audioClip"></param>
    public void PlaySE(AudioClip audioClip)
    {
        SEAudiosource.PlayOneShot(audioClip);
    }

    /// <summary>
    /// 外部のスライダーからSEを調整する
    /// </summary>
    /// <param name="value"></param>

    public void ChangeSEVolume(float value)
    {
        SEAudiosource.volume = value;

    }

}
