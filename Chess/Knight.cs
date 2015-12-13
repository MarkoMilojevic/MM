using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Chess
{
	public class Knight : ChessPiece
	{
		public override ChessPieceType Type
		{
			get
			{
				return ChessPieceType.KNIGHT;
			}
		}

		public Knight(Chessboard chessboard, ChessPieceSuit suit) : base(chessboard, suit)
		{

		}
	}
}
