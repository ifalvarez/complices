using UnityEngine;
using System.Collections;
using Gamelogic.Grids;

public class Piece {

	public PointList<RectPoint> range;
	public Player player;

	public Piece(){
		range = new PointList<RectPoint> ();
		range.Add (new RectPoint (0, 0));
		range.Add (new RectPoint (1, 0));
		range.Add (new RectPoint (2, 0));
		range.Add (new RectPoint (-1, 0));
		range.Add (new RectPoint (-2, 0));
		range.Add (new RectPoint (0, 1));
		range.Add (new RectPoint (0, 2));
		range.Add (new RectPoint (0, -1));
		range.Add (new RectPoint (0, -2));
	}
}
