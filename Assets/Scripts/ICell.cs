using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
	internal interface ICell
	{
		Vector3 Position { get; set; }
		Quaternion Rotation { get; set; }
		Vector3 Scale { get; set; }
		ICollection<Vector3> Collisions { get; set;}
	}
}
