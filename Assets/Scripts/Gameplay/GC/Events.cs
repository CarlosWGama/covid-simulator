using UnityEngine;
using System;

/// <summary>
/// Classe controller dos eventos realizados no jogo
/// </summary>
[Serializable]
public class Events {

    public int Level = 1;


    /********** Ações dos Levels **********/
    public bool LVL1Init = true;
    public bool LVL1SeeYou = true;

    /**********   Mecânicas  ***********/
    /// <summary>Está na Introdução do Jogo </summary>
    public bool Intro = true;
    public bool CanUseLights = true;


    /**********   Objects  ***********/
    /// <summary>Portas do Hotel estão fechadas (Serve para exibir o texto de portas fechadas)</summary>
    public bool DoorsClosed = false;
    
}
