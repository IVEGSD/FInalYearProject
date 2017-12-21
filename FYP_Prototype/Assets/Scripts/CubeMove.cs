using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : Chessman {

	public override bool[,] PossibleMove(){
		bool[,] r = new bool[8, 8];
		Chessman c, c2;
		for(int i = 2;i>0;i--){
			
		c = BoardM.Instance.Chessmans [CurrentX - i, CurrentY + i];
		r [CurrentX - i, CurrentY + i] = true;
			c = BoardM.Instance.Chessmans [CurrentX + i, CurrentY + i];
			r [CurrentX - i, CurrentY + i] = true;
			//c = BoardM.Instance.Chessmans [CurrentX + i, CurrentY - i];
			//r [CurrentX - i, CurrentY + i] = true;
			//c = BoardM.Instance.Chessmans [CurrentX - i, CurrentY - i];
			//r [CurrentX - i, CurrentY + i] = true;
		}
		/*if (isWhite) {
			if (CurrentX != 0 && CurrentY != 7) {
				c = BoardM.Instance.Chessmans [CurrentX - 1, CurrentY + 1];
				if (c != null && !c.isWhite)
					r [CurrentX - 1, CurrentY + 1] = true;
			}
			if (CurrentX != 7 && CurrentY != 7) {
				c = BoardM.Instance.Chessmans [CurrentX + 1, CurrentY + 1];
				if (c != null && !c.isWhite)
					r [CurrentX + 1, CurrentY + 1] = true;
			}
			if (CurrentY != 7) {
				c = BoardM.Instance.Chessmans [CurrentX, CurrentY + 1];
				if (c == null)
					r [CurrentX, CurrentY + 1] = true;
			}
			if (CurrentY == 1) {
				c = BoardM.Instance.Chessmans [CurrentX, CurrentY + 1];
				c2 = BoardM.Instance.Chessmans [CurrentX, CurrentY + 2];
				if (c == null & c2 == null)
					r [CurrentX, CurrentY + 2] = true;
			}
		} else {
			if (CurrentX != 0 && CurrentY != 0) {
				c = BoardM.Instance.Chessmans [CurrentX - 1, CurrentY - 1];
				if (c != null && c.isWhite)
					r [CurrentX - 1, CurrentY - 1] = true;
			}
			if (CurrentX != 7 && CurrentY != 0) {
				c = BoardM.Instance.Chessmans [CurrentX + 1, CurrentY - 1];
				if (c != null && c.isWhite)
					r [CurrentX + 1, CurrentY - 1] = true;
			}
			if (CurrentY != 0) {
				c = BoardM.Instance.Chessmans [CurrentX, CurrentY - 1];
				if (c == null)
					r [CurrentX, CurrentY - 1] = true;
			}
			if (CurrentY == 1) {
				c = BoardM.Instance.Chessmans [CurrentX, CurrentY + 1];
				c2 = BoardM.Instance.Chessmans [CurrentX, CurrentY + 2];
				if (c == null & c2 == null)
					r [CurrentX, CurrentY - 2] = true;
		}
		
	}*/
		return r;
}
}
