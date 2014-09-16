using UnityEngine;
using System.Collections;
using Gamelogic.Grids;
using System.Collections.Generic;

public class TerritoryGrid : GridBehaviour<RectPoint> {

	public Color[] playerColors = {Color.green, Color.red};

	private IGrid<TerritoryCell, RectPoint> territoryGrid;

	public override void InitGrid () {
		territoryGrid = Grid.CastValues<TerritoryCell, RectPoint> ();
		PlayerManager.Instance.joinGame();
	}

	public void OnClick(RectPoint point)
	{
		Piece newPiece = new Piece ();
		newPiece.player = PlayerManager.Instance.players [0];
		PlacePiece(point, newPiece, new List<Piece>());
		foreach (TerritoryCell territory in territoryGrid.Values) {
			territory.resolve();
		}
	}

	void PlacePiece (RectPoint point, Piece piece, List<Piece> placedPieces)
	{
		placedPieces.Add (piece);
		//territoryGrid [point].HighlightOn = false;
		List<RectPoint> allyLocations = new List<RectPoint> ();
		foreach (RectPoint p in piece.range) {
			RectPoint targetTerritory = point.MoveBy(p);
			if(territoryGrid.Contains(targetTerritory)){
				TerritoryCell territory = territoryGrid[targetTerritory];
				territory.attack(piece.player);
				if(territory.piece != null && territory.owner == piece.player){
					allyLocations.Add(targetTerritory);
				}
			}
		}
		foreach (RectPoint allyLocation in allyLocations) {
			PlacePiece(allyLocation, territoryGrid[allyLocation].piece, placedPieces);
		}
	}
}
	
