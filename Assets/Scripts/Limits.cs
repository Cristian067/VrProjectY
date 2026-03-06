using UnityEngine;

public class Limits : MonoBehaviour
{


    [SerializeField] private bool left;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && UpgradesManager.instance.upgrades.Contains(UpgradesManager.instance.effects.sideToSideEffect))
        {
            if (left)
            {
                GameObject.Find("Player").transform.position = new Vector3(6.2f, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z); 
            }
            else
            {

                GameObject.Find("Player").transform.position = new Vector3(-6.2f, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z);
                
            }
        }
    }

}
