using UnityEngine;
using System.Collections;

/// <summary>
/// アイテムの共通処理を実装したクラス
/// アイテムはこのクラスを継承して作ること
/// </summary>
public class ItemBase : MonoBehaviour
{
    /// <summary> アイテムを使用した時のSE </summary>
    public AudioClip m_sfx = null;
    /// <summary> アイテムを隠す場所 </summary>
    Vector3 m_swapPoint = new Vector3(0, -100, 0);
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    /// <summary>アイテムを手に入れた時に呼ばれる</summary>
    public void Get()
    {
        // 見えない所にアイテムを隠す
        this.transform.position = m_swapPoint;
    }

    /// <summary>アイテムが捨てられた時に呼ばれる</summary>
    public void Throw(Vector3 position)
    {
        // 引数で指定された場所にアイテムを出現させる
        this.transform.position = position;
    }

    /// <summary>
    /// アイテムを使う時の共通処理
    /// </summary>
    public virtual void Use()
    {
        // 効果音を鳴らし、アイテムをすぐに破棄する
        //audioSource.PlayOneShot(m_sfx);
        AudioSource.PlayClipAtPoint(m_sfx, Camera.main.transform.position);
        DestroyImmediate(this.gameObject);
    }
}
