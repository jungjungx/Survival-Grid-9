using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    //game win picutre from 
    //https://www.geekwire.com/2018/goodbye-bfr-hello-starship-elon-musk-gives-classic-name-mars-spaceship/

    public void GameOver(){
        Debug.Log("Game over!");
        Youdied();
    }

    public void GameWin(){
        Debug.Log("Game Win!");
        Youwin();
    }

    void Restart(){
        SceneManager.LoadScene("MainMenu");
    }

    void Youdied(){
        Debug.Log("You died!");
        SceneManager.LoadScene("Death");
    }

    void Youwin(){
        Debug.Log("you win!");
        SceneManager.LoadScene("GameWin");
    }
}
