using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    [SerializeField] private float speedLerp;
    [SerializeField] private Vector3 startCamPos;
    [SerializeField] private GameObject objectRenderer;
    //[SerializeField] private
    private Transform player;
    private bool isTutor;
    [SerializeField] Transform worldPointre;
    private void Start()
    {
        isTutor = true;
    }

    void LateUpdate()
    {

        player = Player.Instance.transform;
        FollowToPlayer();
        if (isTutor)
        {

            //Vector3 fromPLayerToArrow = objectRenderer.transform.position - player.transform.position;
            //Ray ray = new Ray(player.transform.position, fromPLayerToArrow);
            //Gizmos.DrawRay(player.transform.position, fromPLayerToArrow);
            //Plane[] planes = GeometryUtility.CalculateFrustumPlanes(GetComponent<Camera>());
            //float midDistance = Mathf.Infinity;
            //for (int i = 0; i < 4; i++)
            //{
            //    if (planes[i].Raycast(ray, out float distance))
            //    {


            //        if (distance < midDistance)
            //        {
            //            midDistance = distance;
            //        }
            //    }
            //}
            //midDistance = Mathf.Clamp(midDistance, 0, fromPLayerToArrow.magnitude);
            //Vector3 worldPos = ray.GetPoint(midDistance);
            //Debug.Log(worldPos);


        }


        //// Compare the visibility percentage to the threshold
        //if (visibilityPercentage >= visibilityThreshold)
        //{
        //    return true;
        //}
    }

    private void FollowToPlayer()
    {
        if (transform.position != player.position)
           transform.position = Vector3.MoveTowards(transform.position,player.position + startCamPos , speedLerp);
    }

}
