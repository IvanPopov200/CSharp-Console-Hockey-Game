
using System;
using System.Threading;
namespace PingPong
{

    class Program
        {
            static readonly int PlayerOneSize = 10;
            static readonly int PlayerTwoSize = 10;
            static int ballPositionX = 0;
            static int ballPositionY = 0;
            static bool ballDirectionUp = true; 
            static bool ballDirectionRight = false;
            static int PlayerOnePos = 0;
            static int PlayerTwoPos = 0;
            static int PlayerOneResult = 0;
            static int PlayerTwoResult = 0;
            static void Main(string[] args)
            {
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
            Console.WriteLine("Simple Ping Pong Console Game by Ivan Popov CHB99132");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            SetDefaultPos();
                while (true)
                {
                    if (Console.KeyAvailable)
                    {
                        var input = Console.ReadKey();                      
                        switch (input.Key)
                    {
                        case ConsoleKey.W: MovePlayerOneUp();break;
                        case ConsoleKey.S: MovePlayerOneDown();break;
                        case ConsoleKey.UpArrow: MovePlayerTwoUp();break;
                        case ConsoleKey.DownArrow: MovePlayerTwoDown();break;
                    }
                    }
                    if(PlayerOneResult==5)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 12, Console.WindowHeight / 2);
                    Console.WriteLine("PLAYER 1 IS THE WINNER!");
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.WindowHeight / 2);
                    Console.WriteLine("PRESS (R) TO PLAY AGAIN OR PRESS (Q) TO EXIT");
                    var newGame = Console.ReadKey();
                    if (newGame.Key == ConsoleKey.R)
                    {
                        SetDefaultPos();
                        PlayerOneResult = 0;
                        PlayerTwoResult = 0;
                    }
                    else if (newGame.Key == ConsoleKey.Q)
                    {
                        break;
                    }

                }
                if (PlayerTwoResult == 5)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 12, Console.WindowHeight / 2);
                    Console.WriteLine("PLAYER 2 IS THE WINNER!");
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.WindowHeight / 2);
                    Console.WriteLine("PRESS (R) TO PLAY AGAIN OR PRESS (Q) TO EXIT");
                    var newGame = Console.ReadKey();
                    if(newGame.Key==ConsoleKey.R)
                    {
                        SetDefaultPos();
                        PlayerOneResult = 0;
                        PlayerTwoResult = 0;
                    }
                    else if(newGame.Key==ConsoleKey.Q)
                    {
                        break;
                    }
                    
                }

                    MoveBall();
                    Console.Clear();
                    DisplayPlayerOne();
                    DisplayPlayerTwo();
                    DisplayBall();
                    DisplayResult();
                    Thread.Sleep(50);
                }
            }
            static void DisplayPlayerOne()
            {
                for (int i = PlayerOnePos; i < PlayerOnePos + PlayerOneSize; i++)
                {
                    DisplayPosition(0, i, '[');
                    DisplayPosition(1, i, ']');
                }
            }
            static void DisplayPlayerTwo()
            {
                for (int i = PlayerTwoPos; i < PlayerTwoPos + PlayerTwoSize; i++)
                {
                    DisplayPosition(Console.WindowWidth - 1, i, ']');
                    DisplayPosition(Console.WindowWidth - 2, i, '[');
                }
            }
            static void DisplayPosition(int x, int y, char s)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(s);
            }
            static void DisplayBall()
            {
                DisplayPosition(ballPositionX, ballPositionY, 'O');
            }          
            static void DisplayResult()
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 12, 0);
                Console.Write("THE SCORE IS: "+PlayerOneResult+"--"+PlayerTwoResult);             
            }
            static void CenterBall()
            {
                ballPositionX = Console.WindowWidth / 2;
                ballPositionY = Console.WindowHeight / 2;
            }

           static void SetDefaultPos()
            {
                PlayerOnePos = Console.WindowHeight / 2 - PlayerOneSize / 2;
                PlayerTwoPos = Console.WindowHeight / 2 - PlayerTwoSize / 2;
                CenterBall();
            }

           

            static void MovePlayerOneDown()
            {
                if (PlayerOnePos < Console.WindowHeight - PlayerOneSize)
                {
                    PlayerOnePos++;
                }
            }

            static void MovePlayerOneUp()
            {
                if (PlayerOnePos > 0)
                {
                    PlayerOnePos--;
                }
            }

            static void MovePlayerTwoDown()
            {
                if (PlayerTwoPos < Console.WindowHeight - PlayerTwoSize)
                {
                    PlayerTwoPos++;
                }
            }

            static void MovePlayerTwoUp()
            {
                if (PlayerTwoPos > 0)
                {
                    PlayerTwoPos--;
                }
            }
            private static void MoveBall()
            {
                if (ballPositionY == 0)
                {
                    ballDirectionUp = false;
                }
                if (ballPositionY == Console.WindowHeight - 1)
                {
                    ballDirectionUp = true;
                }
                if (ballPositionX == Console.WindowWidth - 1)
                {
                    CenterBall();
                    ballDirectionRight = false;
                    ballDirectionUp = true;
                    PlayerOneResult++;
                    Console.SetCursorPosition(Console.WindowWidth / 2-12, Console.WindowHeight / 2);
                    Console.WriteLine("PLAYER 1 SCORES A POINT!");
                    Console.ReadKey();
                }
                if (ballPositionX == 0)
                {
                    CenterBall();
                    ballDirectionRight = true;
                    ballDirectionUp = true;
                    PlayerTwoResult++;
                    Console.SetCursorPosition(Console.WindowWidth / 2-12, Console.WindowHeight / 2);
                    Console.WriteLine("PLAYER 2 SCORES A POINT!");
                    Console.ReadKey();
                }

                if (ballPositionX < 3)
                {
                    if (ballPositionY >= PlayerOnePos && ballPositionY < PlayerOnePos + PlayerOneSize)
                    {
                        ballDirectionRight = true;
                    }
                }

                if (ballPositionX >= Console.WindowWidth-4)
                {
                    if (ballPositionY >= PlayerTwoPos && ballPositionY < PlayerTwoPos + PlayerTwoSize)
                    {
                        ballDirectionRight = false;
                    }
                }

                if (ballDirectionUp)
                {
                    ballPositionY--;
                }
                else
                {
                    ballPositionY++;
                }


                if (ballDirectionRight)
                {
                    ballPositionX++;
                }
                else
                {
                    ballPositionX--;
                }
            }

           
        }
    }
