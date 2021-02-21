using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
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

        }
    }
    void OnTriggerExit(Collider other)
    {
        // Player が接触したら音を鳴らしてテキストを消す
        if (other.gameObject.CompareTag("Player"))
        {
            
        }
    }
}
