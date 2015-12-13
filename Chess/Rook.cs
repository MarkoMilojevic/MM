using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Chess
{
	public class Rook : ChessPiece
	{
		public override ChessPieceType Type
		{
			get
			{
				return ChessPieceType.ROOK;
			}
		}

		public Rook(Chessboard chessboard, ChessPieceSuit suit) : base(chessboard, suit)
		{

		}
	}
}
