using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : Chessman {

	public override bool[,] PossibleMove(){
		bool[,] r = new bool[8, 8];
	
		Chessman c, c2;
		int move = 1;
		int bs = 7,mv = 0;
		for(int i = move;i>=0;i--){
			for (int j = move; j >= 0; j--) {

				if(((i)*(i)+(j)*(j))<=(move*move)&&mv==0&&isWhite )
                {


					if (CurrentX <= bs - move&&CurrentY>=move) {
						c = BoardM.Instance.Chessmans [CurrentX + i, CurrentY - j];
						r [CurrentX + i, CurrentY - j] = true;
					}
					if (CurrentX <= bs - move&&CurrentY<=bs-move) {
						c = BoardM.Instance.Chessmans [CurrentX + i, CurrentY + j];
						r [CurrentX + i, CurrentY + j] = true;
					}

					if (CurrentX >=move&&CurrentY>=move) {
						c = BoardM.Instance.Chessmans [CurrentX - i, CurrentY - j];
						r [CurrentX - i, CurrentY - j] = true;
					}
					if (CurrentX >=move&&CurrentY<=bs-move) {
						c = BoardM.Instance.Chessmans [CurrentX - i, CurrentY + j];
						r [CurrentX - i, CurrentY + j] = true;
					}
					if(CurrentX <= bs- move+1&&CurrentY>=move-1){
						if (i < move&&j<move) {
							c = BoardM.Instance.Chessmans [CurrentX + i, CurrentY - j];
							r [CurrentX + i, CurrentY - j] = true;
						}
					}
					if(CurrentX>=move-1&&CurrentY <= bs- move+1){
						if (i < move&&j<move) {
							c = BoardM.Instance.Chessmans [CurrentX - i, CurrentY + j];
							r [CurrentX - i, CurrentY + j] = true;
						}
					}
					if(CurrentX <= bs- move+1&&CurrentY <= bs- move+1){
						if (i < move&&j<move) {
							c = BoardM.Instance.Chessmans [CurrentX + i, CurrentY + j];
							r [CurrentX + i, CurrentY + j] = true;
						}
					}
					if(CurrentX>=move-1&&CurrentY>=move-1){
						if (i < move&&j<move) {
							c = BoardM.Instance.Chessmans [CurrentX - i, CurrentY - j];
							r [CurrentX - i, CurrentY - j] = true;
						}
					}

				}
                // else {
                //   c = BoardM.Instance.Chessmans[CurrentX,CurrentY];
                //   r[CurrentX , CurrentY] = true;
                //}

            }
        }
        if(r[CurrentX , CurrentY]!= true){
			BoardM.m2 = false;
		}
		mv++;
		return r;

	}
}
