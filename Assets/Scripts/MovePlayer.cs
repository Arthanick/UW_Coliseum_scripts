using UnityEngine;
using System.Collections;

    public class MovePlayer : MonoBehaviour
    {
         public float stopStart = 1.5f, speed = 5f, rotationSpeed = 100f, heightPlayer = 1f;

         private float mag, angleToTarget;
         private Ray look_ray, ray;
         private RaycastHit hit;
         private Vector3 dir;
         private Vector3 target = new Vector3();
		 private Vector3 Look_target = new Vector3();
         private Vector3 lastTarget = new Vector3();
	 	 private Vector3 lastLook_target = new Vector3();


		 private bool walk;
	
		 private void Start()
		 {
			walk = false;
		 }

         private void Update()
         {
			look_ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(look_ray, out hit, 10000.0f))
		 	{
				Look_target = hit.point;
			}
			LookAtThis();
            if (Input.GetMouseButton(1))
            {
				ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out hit, 10000.0f))
				{
					target = hit.point;
				}
				walk = true;
            }
			if (walk)
				MoveTo();
             
             
         }

         private void CalculateAngle(Vector3 temp)
         {
             dir = new Vector3(temp.x, transform.position.y, temp.z) - transform.position;
             angleToTarget = Vector3.Angle(dir, transform.forward);
         }

         private void LookAtThis()
         {
		 	if (Look_target != lastLook_target)
            {
				CalculateAngle(Look_target);
                if(angleToTarget > 1)
                	transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(dir), rotationSpeed * UnityEngine.Time.deltaTime);
 			}
         }

         private void MoveTo()
         {
             if (target != lastTarget)
             {
                 if ((transform.position - target).sqrMagnitude > heightPlayer + 0.1f)
                 {
                     mag = (transform.position - target).magnitude;
                     transform.position = Vector3.MoveTowards(transform.position, target, mag > stopStart ? speed * UnityEngine.Time.deltaTime : Mathf.Lerp(speed * 0.5f, speed, mag / stopStart) * UnityEngine.Time.deltaTime);
                     ray = new Ray(transform.position, -Vector3.up);
                     if (Physics.Raycast(ray, out hit, 1000.0f))
                     {
                         transform.position = new Vector3(transform.position.x, hit.point.y + heightPlayer, transform.position.z);
                     }
                 }
                 else
                 {
					walk = false;
                    lastTarget = target;
                 }
             }
         }
     } 