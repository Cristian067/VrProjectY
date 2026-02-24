using Oculus.Interaction.Samples;
using UnityEngine;

public class FollowCam : MonoBehaviour
{


    public Camera cam;
    public Transform player;

    public float distance;
    public float thing;
    public Vector3 offset = new Vector3(0, 0, -2f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        //transform.localPosition = player.position + new Vector3(1,1,distance);
        //Ray raycam = cam.ViewportPointToRay(transform.position);
        
        //Vector3 distance = 
        //Debug.Log(raycam.GetPoint(1));
        

        
    }

    private void LateUpdate()
    {
        transform.position = cam.transform.TransformPoint(offset);
        
        transform.rotation = cam.transform.rotation;

        transform.forward = -(cam.transform.position - transform.position);
    }
}
