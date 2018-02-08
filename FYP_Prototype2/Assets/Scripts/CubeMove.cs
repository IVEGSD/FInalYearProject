using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : Chessman {

	public override bool[,] PossibleMove(){
		bool[,] r = new bool[8, 8];
		Chessman c, c2;
		int move = 2;
		int bs = 7,mv = 0;
		for(int i = move;i>=0;i--){
			for (int j = move; j >= 0; j--) {
				
				if(((i)*(i)+(j)*(j))<=(move*move)&&mv==0&&isWhite==true){
					

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

			}
		}
		BoardM.m1 = false;
		mv++;
		return r;
	
}
}
/*if (CurrentX >= move && CurrentX <= bs - move && CurrentY >= move && CurrentY <= bs - move) {
						c = BoardM.Instance.Chessmans [CurrentX + i, CurrentY - j];
						r [CurrentX + i, CurrentY - j] = true;
						c = BoardM.Instance.Chessmans [CurrentX + i, CurrentY + j];
						r [CurrentX + i, CurrentY + j] = true;
						c = BoardM.Instance.Chessmans [CurrentX - i, CurrentY - j];
						r [CurrentX - i, CurrentY - j] = true;
						c = BoardM.Instance.Chessmans [CurrentX - i, CurrentY + j];
						r [CurrentX - i, CurrentY + j] = true;
					}
						else if (CurrentX >= move && CurrentX <= bs - move && CurrentY >= move-1 && CurrentY <= bs - move) {
						c = BoardM.Instance.Chessmans [CurrentX + i, CurrentY ];
						r [CurrentX + i, CurrentY ] = true;
						c = BoardM.Instance.Chessmans [CurrentX + i, CurrentY + j];
						r [CurrentX + i, CurrentY + j] = true;
						c = BoardM.Instance.Chessmans [CurrentX - i, CurrentY ];
						r [CurrentX - i, CurrentY ] = true;
						c = BoardM.Instance.Chessmans [CurrentX - i, CurrentY + j];
						r [CurrentX - i, CurrentY + j] = true;
						c = BoardM.Instance.Chessmans [CurrentX + i-1, CurrentY - (move-1)];
						r [CurrentX + i-1, CurrentY - (move-1)] = true;
						c = BoardM.Instance.Chessmans [CurrentX - i+1, CurrentY - (move-1)];
						r [CurrentX - i+1, CurrentY - (move-1)] = true;
					}
					else if (CurrentX >= move && CurrentX <= bs - move  && CurrentY <= bs - move) {
						c = BoardM.Instance.Chessmans [CurrentX + i, CurrentY ];
						r [CurrentX + i, CurrentY ] = true;
						c = BoardM.Instance.Chessmans [CurrentX + i, CurrentY + j];
						r [CurrentX + i, CurrentY + j] = true;
						c = BoardM.Instance.Chessmans [CurrentX - i, CurrentY ];
						r [CurrentX - i, CurrentY ] = true;
						c = BoardM.Instance.Chessmans [CurrentX - i, CurrentY + j];
						r [CurrentX - i, CurrentY + j] = true;
					}
					else if (CurrentX >= move-1 && CurrentX <= bs - move && CurrentY >= move && CurrentY <= bs - move) {
						c = BoardM.Instance.Chessmans [CurrentX + i, CurrentY - j];
						r [CurrentX + i, CurrentY - j] = true;
						c = BoardM.Instance.Chessmans [CurrentX + i, CurrentY + j];
						r [CurrentX + i, CurrentY + j] = true;
						c = BoardM.Instance.Chessmans [CurrentX, CurrentY - j];
						r [CurrentX, CurrentY - j] = true;
						c = BoardM.Instance.Chessmans [CurrentX , CurrentY + j];
						r [CurrentX , CurrentY + j] = true;
						c = BoardM.Instance.Chessmans [ CurrentX - (move-1),CurrentY + i-1];
						r [ CurrentX - (move-1),CurrentY + i-1] = true;
						c = BoardM.Instance.Chessmans [ CurrentX - (move-1),CurrentY - i+1];
						r [ CurrentX - (move-1),CurrentY - i+1] = true;
					}
					else if (CurrentX <= bs - move && CurrentY >= move && CurrentY <= bs - move) {
						c = BoardM.Instance.Chessmans [CurrentX + i, CurrentY - j];
						r [CurrentX + i, CurrentY - j] = true;
						c = BoardM.Instance.Chessmans [CurrentX + i, CurrentY + j];
						r [CurrentX + i, CurrentY + j] = true;
						c = BoardM.Instance.Chessmans [CurrentX , CurrentY - j];
						r [CurrentX , CurrentY - j] = true;
						c = BoardM.Instance.Chessmans [CurrentX , CurrentY + j];
						r [CurrentX , CurrentY + j] = true;
					}
					else if (CurrentX >= move && CurrentX <= bs - move && CurrentY >= move && CurrentY <= bs - move+1) {
						c = BoardM.Instance.Chessmans [CurrentX + i, CurrentY- j ];
						r [CurrentX + i, CurrentY - j] = true;
						c = BoardM.Instance.Chessmans [CurrentX + i, CurrentY];
						r [CurrentX + i, CurrentY ] = true;
						c = BoardM.Instance.Chessmans [CurrentX - i, CurrentY - j];
						r [CurrentX - i, CurrentY - j] = true;
						c = BoardM.Instance.Chessmans [CurrentX - i, CurrentY ];
						r [CurrentX - i, CurrentY ] = true;
						c = BoardM.Instance.Chessmans [CurrentX + i-1, CurrentY + (move-1)];
						r [CurrentX + i-1, CurrentY + (move-1)] = true;
						c = BoardM.Instance.Chessmans [CurrentX - i+1, CurrentY + (move-1)];
						r [CurrentX - i+1, CurrentY + (move-1)] = true;
					}
					else if (CurrentX >= move && CurrentX <= bs - move  && CurrentY >= move) {
						c = BoardM.Instance.Chessmans [CurrentX + i, CurrentY - j];
						r [CurrentX + i, CurrentY - j] = true;
						c = BoardM.Instance.Chessmans [CurrentX + i, CurrentY ];
						r [CurrentX + i, CurrentY ] = true;
						c = BoardM.Instance.Chessmans [CurrentX - i, CurrentY - j];
						r [CurrentX - i, CurrentY - j] = true;
						c = BoardM.Instance.Chessmans [CurrentX - i, CurrentY];
						r [CurrentX - i, CurrentY] = true;
					}
					else if (CurrentX >= move && CurrentX <= bs - move+1 && CurrentY >= move && CurrentY <= bs - move) {
						c = BoardM.Instance.Chessmans [CurrentX , CurrentY - j];
						r [CurrentX , CurrentY - j] = true;
						c = BoardM.Instance.Chessmans [CurrentX , CurrentY + j];
						r [CurrentX , CurrentY + j] = true;
						c = BoardM.Instance.Chessmans [CurrentX -i, CurrentY - j];
						r [CurrentX -i, CurrentY - j] = true;
						c = BoardM.Instance.Chessmans [CurrentX -i, CurrentY + j];
						r [CurrentX -i, CurrentY + j] = true;
						c = BoardM.Instance.Chessmans [ CurrentX + (move-1),CurrentY + i-1];
						r [ CurrentX + (move-1),CurrentY + i-1] = true;
						c = BoardM.Instance.Chessmans [ CurrentX + (move-1),CurrentY - i+1];
						r [ CurrentX + (move-1),CurrentY - i+1] = true;
					}
					else 	if (CurrentX >= move  && CurrentY >= move && CurrentY <= bs - move) {
						c = BoardM.Instance.Chessmans [CurrentX , CurrentY - j];
						r [CurrentX, CurrentY - j] = true;
						c = BoardM.Instance.Chessmans [CurrentX, CurrentY + j];
						r [CurrentX , CurrentY + j] = true;
						c = BoardM.Instance.Chessmans [CurrentX - i, CurrentY - j];
						r [CurrentX - i, CurrentY - j] = true;
						c = BoardM.Instance.Chessmans [CurrentX - i, CurrentY + j];
						r [CurrentX - i, CurrentY + j] = true;
					}*/