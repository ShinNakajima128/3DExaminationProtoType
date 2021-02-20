using UnityEngine;

/// <summary>
/// アイテムの共通処理を実装したクラス
/// アイテムはこのクラスを継承して作ること
/// </summary>
public class ItemBase : MonoBehaviour
{
    [SerializeField] AudioClip m_sfx = null;
    Vector3 m_swapPoint = new Vector3(0, -100, 0);

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
        AudioSource.PlayClipAtPoint(m_sfx, Camera.main.transform.position);
        DestroyImmediate(this.gameObject);
    }
}
