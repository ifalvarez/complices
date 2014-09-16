using UnityEngine;
using System.Collections;
using Gamelogic.Grids;
using System.Collections.Generic;

public class TerritoryCell : SpriteCell {
	public Player owner;
	public Piece piece;
	private Dictionary<Player, int> attackers = new Dictionary<Player, int>();

	//Hides SpriteCell.OnClick to avoid highlighting
	public new void OnClick(){
	}

	public bool isNeutral ()
	{
		return owner == null;
	}

	// Declares an attack from a player over a territory
	public void attack(Player attacker){
		if (attackers.ContainsKey (attacker)) {
			attackers [attacker] = + 1;
		}else{
			attackers.Add(attacker, 1);
		}
	}

	// Resolves the status of the territory after all attacks
	public void resolve(){
		Player winner = null;
		int winnerAttacks = 0;
		foreach (KeyValuePair<Player, int> attacker in attackers) {
			if (attacker.Value > winnerAttacks){
				winner = attacker.Key;
				winnerAttacks = attacker.Value;
			} else if (attacker.Value == winnerAttacks){
				winner = null;
			}
		}
		if (winner != null) {
			owner = winner;
			Color = owner.color;
		}
		attackers.Clear();
	}
}
