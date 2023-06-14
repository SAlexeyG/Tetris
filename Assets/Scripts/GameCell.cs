using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
	internal class GameCell : ICell
	{
		private const int contactsCapacity = 8;
		private Transform transform;
		private Collider2D collider;
		private Collider2D[] contacts;

		public Vector3 Position { get => transform.position; set => throw new NotImplementedException(); }
		public Quaternion Rotation { get => transform.rotation; set => throw new NotImplementedException(); }
		public Vector3 Scale { get => transform.lossyScale; set => throw new NotImplementedException(); }
		public ICollection<Vector3> Collisions 
		{
			get
			{
				collider.GetContacts(contacts);
				return contacts.Select(contact => contact.gameObject.transform.position).ToList();
			}
			
			set => throw new NotImplementedException(); 
		}

		public GameCell(GameObject prefab, Vector3 position)
		{
			contacts = new Collider2D[contactsCapacity];
			var cell = GameObject.Instantiate(prefab, position, Quaternion.identity);
			transform = cell.transform;
			collider = cell.transform.GetComponent<Collider2D>();
		}
	}
}
