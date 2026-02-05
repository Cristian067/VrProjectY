using UnityEngine;

public class ShootVR : MonoBehaviour
{

    public GameObject hand;
    public GameObject bullet;
    public GameObject chargeBullet;

    float charge = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //   if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger,OVRInput.Controller.RTouch))
        // {
        //     Instantiate(bullet,transform.position,transform.rotation);
        // }
        if (UpgradesManager.instance.upgrades.Contains(UpgradesManager.instance.effects.chargedShoot))
        {
            if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger,OVRInput.Controller.RTouch) && !GameManager.instance.paused)
            {
                if (UpgradesManager.instance.upgrades.Contains(UpgradesManager.instance.effects.magicMirror))
                {
                    
                    ChargedShoot(true);
                }
                else
                {
                    ChargedShoot(true);
                }
                
            }
            else if(OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger,OVRInput.Controller.RTouch) && !GameManager.instance.paused)
            {
                ChargedShoot(false);
            }
        }

        else if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger,OVRInput.Controller.RTouch) && !GameManager.instance.paused)
        {
            if (UpgradesManager.instance.upgrades.Contains(UpgradesManager.instance.effects.magicMirror))
            {
                
                DoubleShoot();
            }
            else
            {
                Shoot();
            }
               
        }
    }





    private void DoubleShoot()
    {
        
                GameObject bulletOut = Instantiate(bullet, transform.position + new Vector3(0.4f,0,0), Quaternion.Euler(new Vector3(transform.rotation.x,0,transform.rotation.z)));
                GameObject bulletOut2 = Instantiate(bullet, transform.position + new Vector3(-0.4f,0,0), Quaternion.Euler(new Vector3(transform.rotation.x,0,transform.rotation.z)));

                bulletOut.GetComponent<BulletsBehavior>().damage = GameManager.instance.GetPlayerDamage() * 0.75f;
                bulletOut2.GetComponent<BulletsBehavior>().damage = GameManager.instance.GetPlayerDamage() * 0.75f;

                Destroy(bulletOut, 5f);
                Destroy(bulletOut2, 5f);
                
            
    }

    private void Shoot()
    {
       
                GameObject bulletOut = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(transform.rotation.x,0,transform.rotation.z)));

                bulletOut.GetComponentInChildren<BulletsBehavior>().damage = GameManager.instance.GetPlayerDamage();

                Destroy(bulletOut, 5f);
  
    }

    private void ChargedShoot(bool charging)
    {

        if (charging)
        {
            chargeBullet.SetActive(true);
            chargeBullet.transform.localScale = new Vector3(charge,charge,charge);

            charge += Time.deltaTime*0.5f;

        }

        else
        {
            
            GameObject bulletOut = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(transform.rotation.x,0,transform.rotation.z)));
            chargeBullet.SetActive(false);
            bulletOut.GetComponentInChildren<BulletsBehavior>().damage = GameManager.instance.GetPlayerDamage() * charge;
            bulletOut.transform.localScale = new Vector3(charge/2, charge/2,charge/2);

            Destroy(bulletOut, 5f);
            charge =0;
            
        }
        


    }




}
