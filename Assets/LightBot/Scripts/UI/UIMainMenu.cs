using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace LightBot {
    public class UIMainMenu : MonoBehaviour {

        public void LoadBasicsLevels(int levelNo) {
            SceneManager.LoadScene($"Basics_Level {levelNo}");
        }

        public void LoadProceduresLevels(int levelNo) {
            SceneManager.LoadScene($"Procedures_Level {levelNo}");
        }

        public void LoadLoopsLevels(int levelNo) {
            SceneManager.LoadScene($"Loops_Level {levelNo}");
        }
    }
}
