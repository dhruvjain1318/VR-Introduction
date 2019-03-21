using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CornellTech.View
{
	/// <summary>
	/// This class manages the Cornell Tech logo in the scene.
	/// </summary>
	public class Logo : MonoBehaviour
	{
		//Readonly/const
		protected readonly int COLLISION_LIMIT = 5;
		
		/////Protected/////
		//References
		protected LogoPiece[] pieces;
		//Primitives
		private int counter;
		///////////////////////////////////////////////////////////////////////////
		//
		// Inherited from MonoBehaviour
		//
		
		protected void Awake ()
		{
			counter = 0;
			pieces = GetComponentsInChildren<LogoPiece> ();
			for (int i = 0; i < pieces.Length; i++)
			{
				pieces [i].CollisionEnteredAction += OnCollisionEntered;
			}
		}
		
		protected void Start ()
		{	

		}
		
		protected void Update ()
		{	

		}
		
		///////////////////////////////////////////////////////////////////////////
		//
		// Logo Functions
		//

		protected void FallApart()
		{
			//TODO: Fill
			for (int i = 0; i < pieces.Length; i++) 
			{
				if (pieces[i].ShouldFall == true) 
				{
					pieces [i].AddRigidbody();
				}
			}
		}
		
		////////////////////////////////////////
		//
		// Event Functions

		protected void OnCollisionEntered()
		{
			//TODO: Fill
			counter = counter + 1;
			Debug.Log ("counter = " + counter);
			if (counter == COLLISION_LIMIT) 
			{
				FallApart();
			}
		}

	}
}