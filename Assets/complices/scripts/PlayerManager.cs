using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager {

	// Static instantiation Singleton implementation as in http://msdn.microsoft.com/en-us/library/ff650316.aspx
	private static readonly PlayerManager instance = new PlayerManager();
	
	public static PlayerManager Instance{
		get { return instance; }
	}

	public List<Player> players;
	public Color[] playerColors;

	private PlayerManager(){
		players = new List<Player> ();
		playerColors = new Color[]{Color.green, Color.cyan, Color.red, Color.yellow};
	}

	public Player joinGame(){
		Player player = new Player ();
		player.name = "Player " + players.Count + 1;
		player.color = playerColors [players.Count];
		players.Add (player);
		return player;
	}
}
