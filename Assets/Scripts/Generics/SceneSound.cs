using UnityEngine;
using System.Collections;

public class SceneSound : MonoBehaviour {

    [Header("BGM")]
    /// <summary> Música de Fundo </summary>
    [SerializeField]
    private AudioClip BGM;

    /// <summary> Verifica se o BGM deve rodar em Loop </summary>
    [SerializeField]
    private bool loopBGM = true;

    [Header("BGS")]
    /// <summary> Som de Fundo </summary>
    [SerializeField]
    private AudioClip BGS;

    /// <summary> Verifica se o BGS deve rodar em Loop </summary>
    [SerializeField]
    private bool loopBGS = true;

    [Header("SE")]
    /// <summary> Efeito </summary>
    [SerializeField]
    private AudioClip SE;

    /// <summary> Atraso para ativar o SE </summary>
    [SerializeField]
    private float delaySE;

    void Start () {
        SoundManager.Instance.PlayBGM(BGM, loopBGM);
        SoundManager.Instance.PlayBGS(BGS, loopBGS);
    }

    void Update() {
        if (SE != null) {
            delaySE = Time.deltaTime;
            if (delaySE <= 0) {
                SoundManager.Instance.PlaySE(SE);
                enabled = false;
            }
        } else 
            enabled = false;
        
    }
	
}
