using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int starthealth=3;
    [SerializeField] GameObject robotexplosion;
    Gamemanager gamemanager;
    int currenthealth=0;
    void Awake()
    {
     currenthealth=starthealth;   
     gamemanager=FindFirstObjectByType<Gamemanager>();

    }
    void Start()
    {
        gamemanager.adustenimies(1);
    }
    public void takedamage(int amount)
    {
        currenthealth-=amount;
        if(currenthealth<=0)
        {
            gamemanager.adustenimies(-1);
            selfdistruct();

        }
    }

    public  void selfdistruct()
    {
        Instantiate(robotexplosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

}
