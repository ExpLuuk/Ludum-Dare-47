using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ExpPlus.BreakAway.UI {

    public class EndScreenManager : MonoBehaviour {

        public void ClickedTryAgain() {

            SceneManager.LoadScene(1);
        }

        public void MainMenu() {

            SceneManager.LoadScene(0);
        }
    }
}