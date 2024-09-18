public class Health : MonoBehaviour
{
    GameManager gm;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();   
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Spike"))
        {
            gm.health -= 1;
            print(gm.health);
            

        }
    }




    void Update()
    {
        
    }
}