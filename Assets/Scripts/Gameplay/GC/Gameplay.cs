using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;

/// <summary> Classe responsável pelos save e status do jogo </summary>
[Serializable]
public class Checkpoint {
    public int PositionRoom = 0;
    public string CurrentScene = "";
    public Events Events = new Events();
}

public class Gameplay {
    
    /// <summary> Guarda o nome da SceneAtual </summary>
    private static string currentScene;
    public static string CurrentScene {
        get { return currentScene;  }
        set { currentScene = value;  }
    }

    /// <summary>Guarda informação da sala atual que o personagem está</summary>
    private static int positionRoom = 0;
    public static int PositionRoom {
        set { positionRoom = value; }
        get { return positionRoom; }
    }

    ///<summary>Define a direção que o player estará ao mudar de sala</summary>
    private static bool playerDirection = true;     //TRUE - Direita | False - Esquerda
    public static bool PlayerDirection {
        get { return playerDirection; }
        set { playerDirection = value; }
    }

    /// <summary>Classe responsável por ativa e desativar os eventos do jogo</summary>
    private static Events events = new Events();
    public static Events Events { get { return events; } }

    //<summary> O Checkpoint com os ultimos dados </summary>
    private static Checkpoint checkpoint = new Checkpoint();
    public static Checkpoint Checkpoint {
        get { return checkpoint; }
        set { checkpoint = value;
            //Atualiza as informaçõe
            currentScene = checkpoint.CurrentScene;
            positionRoom = checkpoint.PositionRoom;
            events = checkpoint.Events;
        }
    }


    public static void SaveProgress() {
        checkpoint.PositionRoom  = positionRoom;
        checkpoint.CurrentScene  = currentScene;
        checkpoint.Events        = events;
        //SaveLoad.Save();        //Salva no pc
    }

    public static void LoadLastProgress(string file = "/playerData.dat") {
        SaveLoad.Load(file);        //Carrega do PC
        TimeManager.Paused = false;
        SceneManager.LoadScene(checkpoint.CurrentScene);
    }

    public static void NewGame() {
        currentScene = "";
        positionRoom = 0;
        events = new Events();
        checkpoint = new Checkpoint();
    }

}
