using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Chess
{
	public class Bishop : ChessPiece
	{
		public override ChessPieceType Type
		{
			get
			{
				return ChessPieceType.BISHOP;
			}
		}

		public Bishop(Chessboard chessboard, ChessPieceSuit suit) : base(chessboard, suit)
		{

		}
	}
}
