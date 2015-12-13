using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Chess
{
	public class Queen : ChessPiece
	{
		public override ChessPieceType Type
		{
			get
			{
				return ChessPieceType.QUEEN;
			}
		}

		public Queen(Chessboard chessboard, ChessPieceSuit suit) : base(chessboard, suit)
		{

		}
	}
}
