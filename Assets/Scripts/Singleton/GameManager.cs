using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    public int coins = 0;
    public int key = 0;
    public bool running = false;
    public bool levelCompleted = false;

    public bool transitionInProgress = false;

    //Level data
    public int[] levelData;

    private void OnEnable()
    {
        //Load if file exists, else create a new data
        if (File.Exists(Application.persistentDataPath + "/saveGame.dat"))
        {
            LoadLevel();
        }
        else
        {
            levelData = new int[10];
            levelData[0] = 1;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Insert))
        {
            levelData[0] = 3;
            levelData[1] = 3;
            levelData[2] = 3;
            levelData[3] = 3;
            levelData[4] = 3;
            levelData[5] = 3;
            levelData[6] = 3;
            levelData[7] = 3;
            levelData[8] = 3;
            levelData[9] = 3;
            SaveLevel();
        }
    }

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        else if (instance!=null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    //Save and load level data
    public void SaveLevel()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/saveGame.dat");

        SaveData sv = new SaveData(levelData);

        bf.Serialize(file, sv);
        file.Close();
    }

    public void LoadLevel()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/saveGame.dat", FileMode.Open);

        SaveData sv = (SaveData)bf.Deserialize(file);

        file.Close();

        levelData = sv.save;
    }
}

[System.Serializable]
class SaveData
{
    public int[] save = new int[10];

    public SaveData(int[] ld)
    {
        save = ld;
    }
}
