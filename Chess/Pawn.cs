using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Chess
{
	public class Pawn : ChessPiece
	{
		public override ChessPieceType Type
		{
			get
			{
				return ChessPieceType.PAWN;
			}
		}

		public Pawn(Chessboard chessboard, ChessPieceSuit suit) : base(chessboard, suit)
		{

		}
	}
}
