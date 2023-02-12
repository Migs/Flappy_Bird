using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Menu{
    public class MenuController : MonoBehaviour
    {

        public static MenuController menuController;

        // Start is called before the first frame update
        void Start()
        {
            menuController = this;
        }

        public static void ChangeScene(string sceneName)
        {
            switch(sceneName){
                default:
                    break;
                case "playGame":
                    UnityEngine.SceneManagement.SceneManager.LoadScene("GameScreen");
                    break;
                case "mainmenu":
                    UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
                    break;
            }
        }
    }
}
