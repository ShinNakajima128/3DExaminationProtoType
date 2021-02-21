using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    /// <summary> 操作方法などを表示するUI </summary>
    [SerializeField] GameObject m_UI;
    /// <summary> Itemの所持状況を表示するUI </summary>
    [SerializeField] GameObject m_itemCanvas;
    /// <summary>子オブジェクトの Canvas</summary>
    [SerializeField] Canvas m_tutorialCanvas = null;
    /// <summary>画面に表示する Text オブジェクト。m_canvas の子オブジェクトであること</summary>
    [SerializeField] Text m_textUI = null;
    /// <summary>画面に表示する文字列</summary>
    [SerializeField, TextArea(1, 6)] string m_textString;
    /// <summary>表示する時の効果音</summary>
    [SerializeField] AudioClip m_showSfx = null;
    /// <summary>表示を消す時の効果音</summary>
    [SerializeField] AudioClip m_hideSfx = null;
    [SerializeField] Animator m_anim;

    void Start()
    {
        m_textUI.text = m_textString;
        m_tutorialCanvas.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        // Player が接触したらテキストを表示して音を鳴らす
        if (other.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(m_showSfx, Camera.main.transform.position);
            m_tutorialCanvas.gameObject.SetActive(true);
            m_anim.Play("Open");
            m_UI.SetActive(false);
            m_itemCanvas.SetActive(false);
        }
    }
    void OnTriggerExit(Collider other)
    {
        // Player が接触したら音を鳴らしてテキストを消す
        if (other.gameObject.CompareTag("Player"))
        {
            m_anim.Play("Close");
            AudioSource.PlayClipAtPoint(m_hideSfx, Camera.main.transform.position);
            //m_tutorialCanvas.gameObject.SetActive(false);
            m_UI.SetActive(true);
            m_itemCanvas.SetActive(true);
        }
    }
}
