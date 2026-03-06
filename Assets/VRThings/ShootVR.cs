using UnityEngine;

public class ShootVR : MonoBehaviour
{

    public GameObject hand;
    public GameObject bullet;
    public GameObject chargeBullet;
    public GameObject specialOrb;

    private bool grab;

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


        if (OVRInput.GetDown(OVRInput.Button.Four))
        {
            UIManager.instance.DisplayUpgrades(true);

        }
        else if (OVRInput.GetUp(OVRInput.Button.Four))
        {
            UIManager.instance.DisplayUpgrades(false);
        }

        if (OVRInput.GetDown(OVRInput.Button.Two) && UpgradesManager.instance.special != null && !GameManager.instance.specialInCooldown && GameManager.instance.specials > 0)
        {
            specialOrb.SetActive(true);
            specialOrb.GetComponent<Renderer>().material.color = UpgradesManager.instance.special.orbColor;
            specialOrb.transform.localPosition = new Vector3(-14, -102, 0);
        }
        //if (GameManager.instance.specials <= 0)
        //{
        //    specialOrb.SetActive(false);
        //}
        if (OVRInput.GetUp(OVRInput.Button.Two))
        {
            UnDisplaySpecialOrb();
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch) && !GameManager.instance.paused && grab )
        {

            GameManager.instance.specials -= 1;
            UIManager.instance.RefreshStatsUi();
            StartCoroutine(UpgradesManager.instance.special.special.Use(gameObject));
            UnDisplaySpecialOrb();

        }
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
    

    

    public void UnDisplaySpecialOrb()
    {
        grab = false;
        specialOrb.SetActive(false);
    }

    public void UnGrab()
    {
        grab = false;
        specialOrb.transform.localPosition = new Vector3(-14, -102, 0);
    }
    public void Grabbed()
    {
        grab = true;
    }


    private void DoubleShoot()
    {
        
        GameObject bulletOut = Instantiate(bullet, transform.position + new Vector3(0.4f,0,0), hand.transform.rotation);
        GameObject bulletOut2 = Instantiate(bullet, transform.position + new Vector3(-0.4f,0,0), hand.transform.rotation);
        //bulletOut.transform.rotation = Quaternion.Euler(0, bulletOut.transform.rotation.y, bulletOut.transform.rotation.z);
        //bulletOut2.transform.rotation = Quaternion.Euler(0, bulletOut2.transform.rotation.y, bulletOut2.transform.rotation.z);
        bulletOut.GetComponent<BulletsBehavior>().damage = GameManager.instance.GetPlayerDamage() * 0.75f;
        bulletOut2.GetComponent<BulletsBehavior>().damage = GameManager.instance.GetPlayerDamage() * 0.75f;

        Destroy(bulletOut, 5f);
        Destroy(bulletOut2, 5f);
                
            
    }

    private void Shoot()
    {
       
        GameObject bulletOut = Instantiate(bullet, transform.position, hand.transform.rotation);
        //bulletOut.transform.rotation = Quaternion.Euler(0, bulletOut.transform.rotation.y, bulletOut.transform.rotation.z);
        bulletOut.GetComponentInChildren<BulletsBehavior>().damage = GameManager.instance.GetPlayerDamage();

        Destroy(bulletOut, 5f);
  
    }

    private void ChargedShoot(bool charging)
    {

        if (charging)
        {
            chargeBullet.SetActive(true);
            chargeBullet.transform.localScale = new Vector3(charge/18,charge/18,charge/18);

            charge += Time.deltaTime*1f;
            Debug.Log(charge);

            if (charge > 3)
            {
                charge = 3;
            }

        }

        else
        {
            
            GameObject bulletOut = Instantiate(bullet, transform.position, hand.transform.rotation);
            //bulletOut.transform.rotation = Quaternion.Euler(0, bulletOut.transform.rotation.y, bulletOut.transform.rotation.z);
            chargeBullet.SetActive(false);
            bulletOut.GetComponentInChildren<BulletsBehavior>().damage = GameManager.instance.GetPlayerDamage() * charge;
            bulletOut.transform.localScale = new Vector3(charge/8, charge/8,charge/8);

            Destroy(bulletOut, 5f);
            charge =0;
            
        }
        


    }




}
