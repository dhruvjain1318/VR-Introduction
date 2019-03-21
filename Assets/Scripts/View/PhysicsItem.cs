using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Valve.VR;
using Valve.VR.InteractionSystem;

namespace CornellTech.View
{
	/// <summary>
	/// This class represents a physics item, an item which follows the laws of physics and interacts with the Valve interaction system.
	/// </summary>
	public class PhysicsItem : MonoBehaviour
	{
		//Readonly/const
		protected readonly float SCALE_MULTIPLIER = 0.5f;
		
		/////Protected/////
		//References
		protected Hand activeHand;
		protected Rigidbody rigidbody;
		//Primitives
		protected bool isAnimating;

		///////////////////////////////////////////////////////////////////////////
		//
		// Inherited from MonoBehaviour
		//
		
		protected void Awake ()
		{

		}
		
		protected void Start ()
		{	
			AddPhysics ();
			MakeThrowable ();
		}
		
		protected void Update ()
		{	
			UpdateScale ();
		}

		///////////////////////////////////////////////////////////////////////////
		//
		// PhysicsItem Functions
		//

		protected void UpdateScale()
		{
			if (activeHand != null)
			{
				//TODO: Fill
//				var position1 = SteamVR_Input._default.inActions.ScaleItem.GetAxis(SteamVR_Input_Sources.Any).y;
//				GameObject AttachedObj = this.gameObject;
				float deltadistance = SteamVR_Input._default.inActions.ScaleItem.GetAxis(activeHand.handType).y;
				var startsize = transform.localScale;
				var change = deltadistance * SCALE_MULTIPLIER;
				Vector3 NewScale = new Vector3(change, change, change) + startsize;
				if (NewScale.y < 0.0f) 
				{
					NewScale =  new Vector3(0.1f, 0.1f, 0.1f);
				}
				if (deltadistance != 0.0) 
				{
					transform.localScale = NewScale;
				}
			}
		}

		protected void AddPhysics ()
		{
			//TODO: Fill
			GameObject AttachedObj = this.gameObject;
			Rigidbody AddedRigid = AttachedObj.AddComponent<Rigidbody> () as Rigidbody;
			rigidbody = AddedRigid;
			Transform[] meshchecks = AttachedObj.GetComponentsInChildren<Transform>();
			foreach (Transform child in meshchecks)
			{
				MeshFilter filtcheck = child.GetComponent<MeshFilter>();
				if (filtcheck != null) 
				{
					MeshCollider addCollider = child.gameObject.AddComponent<MeshCollider> () as MeshCollider;
					addCollider.convex = true;
				}
			}
		}

		protected void MakeThrowable ()
		{
			//TODO: Fill
			GameObject AttachedObj = this.gameObject;
			Interactable addInteract = AttachedObj.AddComponent<Interactable> () as Interactable;
			VelocityEstimator addVelEst = AttachedObj.AddComponent<VelocityEstimator> () as VelocityEstimator;
			Throwable addThrow = AttachedObj.AddComponent<Throwable> () as Throwable;
			addThrow.releaseVelocityStyle = ReleaseStyle.ShortEstimation;
			addThrow.restoreOriginalParent = true;
		}

		protected void SetRigidBodyEnabled (bool value)
		{
			rigidbody.useGravity = !value;
			rigidbody.isKinematic = value;
		}

		protected IEnumerator ReturnToOrigin ()
		{
			//TODO: Fill
			GameObject Anchor = GameObject.FindGameObjectWithTag("Anchor");
//			Vector3 Rotationneeded = new Vector3 (0.0f, 0.0f, 0.0f);
//			Vector3 Scaleneeded = new Vector3 (1.0f, 1.0f, 1.0f);
//			Vector3 StartRot = new Vector3 (transform.rotation.x, transform.rotation.y, transform.rotation.z);
			yield return new WaitForSeconds(3);
//			if (transform.position == Anchor.transform.position) {

//			} 
			while (transform.position != Anchor.transform.position && transform.rotation != Anchor.transform.rotation && transform.localScale != new Vector3(1.0f, 1.0f, 1.0f))
			{
				isAnimating = true;
				SetRigidBodyEnabled (true);
				transform.position = Vector3.MoveTowards(transform.position, Anchor.transform.position, Time.deltaTime);
//				transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, Anchor.transform.rotation.eulerAngles, Time.deltaTime);
				transform.localRotation = Quaternion.Lerp(transform.rotation, Anchor.transform.rotation, Time.deltaTime);
				transform.localScale = Vector3.Lerp(transform.localScale, new Vector3 (1.0f, 1.0f, 1.0f), Time.deltaTime);
				yield return null;
			}
//			while (transform.rotation != Anchor.transform.rotation)
//			{
//				isAnimating = true;
//				SetRigidBodyEnabled (true);
//				transform.localRotation = Quaternion.Lerp(transform.rotation, Anchor.transform.rotation, Time.deltaTime);
//				transform.localScale = Vector3.Lerp(transform.localScale, new Vector3 (1.0f, 1.0f, 1.0f), Time.deltaTime);
//				Debug.Log ("Transform.rotation = " + transform.rotation);
//				Debug.Log ("Anchor rotation = " + Anchor.transform.rotation);
//				yield return null;
//			}
//			while (transform.localScale != new Vector3(1.0f, 1.0f, 1.0f)) 
//			{
//				isAnimating = true;
//				SetRigidBodyEnabled (true);
//				transform.localScale = Vector3.Lerp(transform.localScale, new Vector3 (1.0f, 1.0f, 1.0f), Time.deltaTime);
//				yield return null;
//			}
			isAnimating = false;
			SetRigidBodyEnabled (false);
//				transform.rotation = Vector3.MoveTowards (new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z), new Vector3(Anchor.transform.rotation.x, Anchor.transform.rotation.y, Anchor.transform.rotation.z), Time.deltaTime * 3.0f);
//				transform.localScale = Vector3.MoveTowards (transform.localScale, new Vector3(1.0f, 1.0f, 1.0f), Time.deltaTime * 3.0f);

		}
		
		////////////////////////////////////////
		//
		// Event Functions

		//Called with SendMessage from Valve.VR.InteractionSystem.Hand
		protected void OnAttachedToHand (Hand hand)
		{
			activeHand = hand;
		}

		//Called with SendMessage from Valve.VR.InteractionSystem.HAnd
		protected void OnDetachedFromHand (Hand hand)
		{
			activeHand = null;
		}
			
		protected void OnCollisionEnter (Collision collision)
		{
			//The tag of the GameObject with the collider we hit.
			string colliderTag = collision.collider.gameObject.tag;

			if (colliderTag == "Platform" || colliderTag == "Floor")
			{
				if (!isAnimating)
					StartCoroutine (ReturnToOrigin ());
			}
		}

	}
}