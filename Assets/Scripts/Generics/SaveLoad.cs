using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/// <summary>
/// Classe responsável por salvar os dados do jogo no pc do jogador
/// </summary>
public class SaveLoad {

    /// <summary> Método responsável por salvar o progresso no PC </summary>
	public static void Save() {

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerData.dat");
        var data = Gameplay.Checkpoint;
        bf.Serialize(file, data);
        file.Close();


    }

    /// <summary> Método responsável por carregar o progresso no PC </summary>
    public static void Load(string fileName = "/playerData.dat") {
        if (HasSave()) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + fileName, FileMode.Open);
            Checkpoint data = (Checkpoint)bf.Deserialize(file);
            file.Close();

            Gameplay.Checkpoint = data;
        }
    }

    /// <summary> Método responsável por verificar se há algo salvo </summary>
    public static bool HasSave() {
        return File.Exists(Application.persistentDataPath + "/playerData.dat");
    }
}
