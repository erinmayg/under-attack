using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

[System.Serializable]
public class SaveLoad: MonoBehaviour {

    private static int user;
    private static int currentSceneIndex;
    private static int sceneToContinue;
    private static int currentNutrigems;
    private static int savedNutrigems;

    private static string[] powerups = {"Shield", "NKC"};
    private static string[] data = {"username", "CurrScene", "CurrNutrigems"};

    // public static SaveLoad saveManager = new SaveLoad();


    // private void AddPowerups() {

    //     // 0 means powerup is not yet available
    //     powerups.Add("shield", 0);
    //     powerups.Add("NKC", 0);
    // }

    public static void SetUser(int i) {
        user = i;
    }

    // public static void AddPowerup(string name) {
    //     powerups[name] = 1;
    // }

    public static void Save(int powerupID) {
        // AddPowerup(powerupName);
        PlayerPrefs.SetInt(powerups[powerupID] + user, 1);
        Save();
    }

    public static void Save() {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        currentNutrigems = PlayerStats.GetNutrigems();
        PlayerPrefs.SetInt("CurrScene" + user, currentSceneIndex);
        PlayerPrefs.SetInt("CurrNutrigems" + user, currentNutrigems);
        
        // foreach(string powerup in powerups.Keys) {
        //     PlayerPrefs.SetInt(powerup + user, powerups[powerup]);
        // }
    }

    public static void Resume() {
        Debug.Log("SL USER" + user);
        sceneToContinue = PlayerPrefs.GetInt("CurrScene" + user);
        savedNutrigems = PlayerPrefs.GetInt("CurrNutrigems" + user);
        if (sceneToContinue > 0) {
            SceneManager.LoadScene(sceneToContinue);
        } else {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public static int GetLevel() {
        int sceneIndex = PlayerPrefs.GetInt("CurrScene" + user);
        if (sceneIndex <= 6) {
            return 1;
        } else if (sceneIndex <= 10) {
            return 2;
        } else {
            return 0;
        }
    }

    public static int GetNutrigems() {
        return PlayerPrefs.GetInt("CurrNutrigems" + user);
    }

    public static int GetPowerup(int powerupID) {
        return PlayerPrefs.GetInt(powerups[powerupID] + user, 0);
    }

    public static int[] GetSuperpower() {
        int[] superpowers = new int[powerups.Length];
        for (int i = 0; i < superpowers.Length; i++) {
            superpowers[i] = GetPowerup(i);
        }

        return superpowers;
    }

    public static void ResetData(int user) {
        foreach(string playerdata in data) {
            PlayerPrefs.DeleteKey(playerdata + user);
        }

        foreach(string powerup in powerups) {
            PlayerPrefs.DeleteKey(powerup + user);
        }
    }
}
