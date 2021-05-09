using System;

public static class ChessEngine{


    public char[,] generateNewBoard(){
        char[,] board = new char[,]{{'r','n','b','q','k','b','n','r'},
                                    {'p','p','p','p','p','p','p','p'},
                                    {'0','0','0','0','0','0','0','0'},
                                    {'0','0','0','0','0','0','0','0'},
                                    {'0','0','0','0','0','0','0','0'},
                                    {'0','0','0','0','0','0','0','0'},
                                    {'P','P','P','P','P','P','P','P'},                  
                                    {'R','N','B','Q','K','B','N','R'}};
    }




    public static void Main(string[] args){
        chessBoard = generateNewBoard();
        print(chessBoard);
    }
}