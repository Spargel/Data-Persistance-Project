using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class StartMenu : MonoBehaviour
{
   public static StartMenu Instance;
   public TMP_InputField inputField;

   public string PlayerName;
   public string Name;
   public int Score = 0;


   private void Awake()
   {
      if (Instance != null)
      {
         Destroy(gameObject);
         return;
      }

      Instance = this;
      DontDestroyOnLoad(gameObject);
      LoadNameScore();
   }

   public void StartButton()
   {
      SceneManager.LoadScene(0);
   }

   public  void SavePlayerName()
   {
      PlayerName = inputField.text;
   }

   [System.Serializable]
   class SaveData
   {
      public string Name;
      public int Score = 0;

   }

   public void SaveNameScore()
   {
      SaveData data = new SaveData();
      data.Name = Name;
      data.Score = Score;

      string json = JsonUtility.ToJson(data);

      File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
   }

   public void LoadNameScore()
   {
      string path = Application.persistentDataPath + "/savefile.json";
      if (File.Exists(path))
      {
         string json = File.ReadAllText(path);
         SaveData data = JsonUtility.FromJson<SaveData>(json);

         Name = data.Name;
         Score = data.Score;
      }
   }
}
