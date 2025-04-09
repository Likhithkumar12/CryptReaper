using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    [SerializeField] GameObject YouWin;
    [SerializeField] TMP_Text enimiesleft;
    const string enemyleft="Enimies Left : ";
    int enimiessleft=0;

    public void adustenimies(int amount)
    {
        enimiessleft+=amount;
        if(enimiessleft<=0)
        {
            YouWin.SetActive(true);

        }
        enimiesleft.text=enemyleft+enimiessleft.ToString();
    }
   public void restartApplication()
    {
        Debug.Log("restarting");
        int currentscene=SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentscene);

    }
   public  void quitApplication()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
