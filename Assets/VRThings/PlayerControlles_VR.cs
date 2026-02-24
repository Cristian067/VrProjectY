using System.Collections;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PlayerControlles_VR : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public IEnumerator HitInCooldown()
    //{
    //    hitbox.enabled = false;
    //    PlayerMaterialGO.GetComponent<MeshRenderer>().material.color = new Vector4(PlayerMaterialGO.GetComponent<MeshRenderer>().material.color.r, PlayerMaterialGO.GetComponent<MeshRenderer>().material.color.g, PlayerMaterialGO.GetComponent<MeshRenderer>().material.color.b, 0.30f);
    //    yield return new WaitForSeconds(hitCooldown);
    //    hitbox.enabled = true;
    //    PlayerMaterialGO.GetComponent<MeshRenderer>().material.color = new Vector4(PlayerMaterialGO.GetComponent<MeshRenderer>().material.color.r, PlayerMaterialGO.GetComponent<MeshRenderer>().material.color.g, PlayerMaterialGO.GetComponent<MeshRenderer>().material.color.b, 1);
    //}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {

        }
    }
}
