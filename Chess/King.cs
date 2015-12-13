using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Chess
{
	public class King : ChessPiece
	{
		public override ChessPieceType Type
		{
			get
			{
				return ChessPieceType.KING;
			}
		}

		public King(Chessboard chessboard, ChessPieceSuit suit) : base(chessboard, suit)
		{

		}
	}
}
