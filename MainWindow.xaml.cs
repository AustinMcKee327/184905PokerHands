using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _184905PokerHands
{
    enum suits {Clubs, Diamonds, Heart, Spades };
    enum face {Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King };
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int Player1Count;
        string line;
        string hand1;
        string hand2;
        
        int ScoreP1;
        int ScoreP2;
        System.IO.StreamReader sr = new System.IO.StreamReader("poker.txt");
        System.IO.StreamReader srt = new System.IO.StreamReader("TestRoyalFlush.txt");
        public MainWindow()
        {
            InitializeComponent();
            
            //temp = sr.ToString();
            //temp1 = temp.Split(' ').ToString();
            //MessageBox.Show(temp1);
            //for(int i= 1; i<1001; i++)
            while(!srt.EndOfStream)
            {
                line = srt.ReadLine().ToString();
                hand1 = line.Substring(0, 14);
                hand2 = line.Substring(15, 14);
                
                

                string[] Hand1Cards = new string[5];
                suits[] Hand1Suites = new suits[5];
                face[] Hand1Face = new face[5];
                string[] Hand2Cards = new string[5];
                suits[] Hand2Suites = new suits[5];
                face[] Hand2Face = new face[5];
                for (int j = 0; j < Hand1Cards.Length; j++)
                {
                    Hand1Cards[j] = hand1.Substring(j * 3, 2);
                    switch (Hand1Cards[j][0])
                    {
                        case 'A': Hand1Face[j] = face.Ace; break;
                        case '2': Hand1Face[j] = face.Two; break;
                        case '3': Hand1Face[j] = face.Three; break;
                        case '4': Hand1Face[j] = face.Four; break;
                        case '5': Hand1Face[j] = face.Five; break;
                        case '6': Hand1Face[j] = face.Six; break;
                        case '7': Hand1Face[j] = face.Seven; break;
                        case '8': Hand1Face[j] = face.Eight; break;
                        case '9': Hand1Face[j] = face.Nine; break;
                        case 'T': Hand1Face[j] = face.Ten; break;
                        case 'J': Hand1Face[j] = face.Jack; break;
                        case 'Q': Hand1Face[j] = face.Queen; break;
                        case 'K': Hand1Face[j] = face.King; break;
                    }
                    switch (Hand1Cards[j][1]) {
                        case 'D': Hand1Suites[j] = suits.Diamonds; break;
                        case 'H': Hand1Suites[j] = suits.Heart; break;
                        case 'C': Hand1Suites[j] = suits.Clubs; break;
                        case 'S': Hand1Suites[j] = suits.Spades; break;
                    }
                    

               //     MessageBox.Show(Hand1Face[j].ToString() + Hand1Suites[j].ToString());
                }
                for (int j = 0; j < Hand2Cards.Length; j++)
                {
                    Hand2Cards[j] = hand2.Substring(j * 3, 2);
                    switch (Hand2Cards[j][0])
                    {
                        case 'A': Hand2Face[j] = face.Ace; break;
                        case '2': Hand2Face[j] = face.Two; break;
                        case '3': Hand2Face[j] = face.Three; break;
                        case '4': Hand2Face[j] = face.Four; break;
                        case '5': Hand2Face[j] = face.Five; break;
                        case '6': Hand2Face[j] = face.Six; break;
                        case '7': Hand2Face[j] = face.Seven; break;
                        case '8': Hand2Face[j] = face.Eight; break;
                        case '9': Hand2Face[j] = face.Nine; break;
                        case 'T': Hand2Face[j] = face.Ten; break;
                        case 'J': Hand2Face[j] = face.Jack; break;
                        case 'Q': Hand2Face[j] = face.Queen; break;
                        case 'K': Hand2Face[j] = face.King; break;
                    }
                    switch (Hand2Cards[j][1])
                    {
                        case 'D': Hand2Suites[j] = suits.Diamonds; break;
                        case 'H': Hand2Suites[j] = suits.Heart; break;
                        case 'C': Hand2Suites[j] = suits.Clubs; break;
                        case 'S': Hand2Suites[j] = suits.Spades; break;
                    }


                    //     MessageBox.Show(Hand2Face[j].ToString() + Hand1Suites[j].ToString());
                }

                Array.Sort(Hand1Face);
                string output = "";
                for (int i = 0; i < Hand1Face.Length; i++)
                {
                    output += Hand1Face[i];
                }
                MessageBox.Show(output);
                //MessageBox.Show((face.Ace - face.King).ToString());
                ScoreP1 = 0;
                ScoreP2 = 0;
                if (Hand1Suites[0] == Hand1Suites[1] && Hand1Suites[0] == Hand1Suites[2] && Hand1Suites[0] == Hand1Suites[3] && Hand1Suites[0] == Hand1Suites[4])
                {
                    if (Hand1Face[0] == face.Ace)
                    {
                        CheckForFlushes(Hand1Face);
                    }
                    if (Hand1Face[0]!= face.Ace)
                    {
                        CheckForStraightFlush(Hand1Face);
                    }
                    if (ScoreP1 == 0)
                    {
                        ScoreP1 = 6;
                    }
                }
                if (Hand1Face[0] == Hand1Face[1])
                {
                    if (Hand1Face[0] == Hand1Face[2])
                    {
                        if (Hand1Face[3] == Hand1Face[4])
                        {
                            ScoreP1 = 7;
                        }
                    }
                }
                if (Hand1Face[2] == Hand1Face[3])
                {
                    if (Hand1Face[2] == Hand1Face[4])
                    {
                        if (Hand1Face[0] == Hand1Face[1])
                        {
                            ScoreP1 = 7;
                        }
                    }
                }

                if (Hand1Face[0] == Hand1Face[1])
                {
                    if(Hand1Face[0] == Hand1Face[2])
                    {
                        if(Hand1Face[0]== Hand1Face[3])
                        {
                            ScoreP1 = 8;
                        }
                        else
                        {
                            ScoreP1 = 4;
                        }
                    }
                    else
                    {
                        if (ScoreP1 == 3)
                        {
                            break;
                        }
                        else
                        {
                            ScoreP1 = 2;
                        }
                    }
                }
                if(Hand1Face[1] == Hand1Face[2])
                {
                    if(Hand1Face[1] == Hand1Face[3])
                    {
                        if(Hand1Face[1]== Hand1Face[4])
                        {
                            ScoreP1 = 8;
                        }
                        else
                        {
                            ScoreP1 = 4;
                        }
                    }
                    else
                    {
                        if(ScoreP1 == 3)
                        {
                            break;
                        }
                        else
                        {
                            ScoreP1 = 2;
                        }
                        
                    }
                    
                }
                if(Hand1Face[0] == Hand1Face[1] && Hand1Face[2] == Hand1Face[3])
                {
                    ScoreP1 = 3;
                }
                if(Hand1Face[1] == Hand1Face[2] && Hand1Face[3] == Hand1Face[4])
                {
                    ScoreP1 = 3;
                }
                if(Hand1Face[0] == Hand1Face[1] && Hand1Face[3]== Hand1Face[4])
                {
                    ScoreP1 = 3;
                }
                if (Hand1Face[2] == Hand1Face[3])
                {
                    if(Hand1Face[2]== Hand1Face[4])
                    {
                        ScoreP1 = 4;
                    }
                }
                else
                {
                    if (ScoreP1 == 3)
                    {
                        break;
                    }
                    else
                    {
                        ScoreP1 = 2;
                    }
                }
                if (Hand1Face[3] == Hand1Face[4])
                {
                    if (ScoreP1 == 3)
                    {
                        break;
                    }
                    else
                    {
                        ScoreP1 = 2;
                    }
                }
                if (Hand1Face[0] - Hand1Face[1] == -1 && Hand1Face[1] - Hand1Face[2] == -1 && Hand1Face[2] - Hand1Face[3] == -1 && Hand1Face[3] - Hand1Face[4] == -1)
                {
                    ScoreP1 = 5;
                }
                else
                {
                    ScoreP1 = 1;

                }



                Array.Sort(Hand2Face);
                string output2 = "";
                for (int i = 0; i < Hand2Face.Length; i++)
                {
                    output2 += Hand2Face[i];
                }
                MessageBox.Show(output2 + "P2");
                //MessageBox.Show((face.Ace - face.King).ToString());
                ScoreP1 = 0;
                if (Hand1Suites[0] == Hand1Suites[1] && Hand1Suites[0] == Hand1Suites[2] && Hand1Suites[0] == Hand1Suites[3] && Hand1Suites[0] == Hand1Suites[4])
                {
                    if (Hand2Face[0] == face.Ace)
                    {
                        //check if Ace, two,...five
                        if (Hand2Face[0] - Hand2Face[1] == -1 && Hand2Face[1] - Hand2Face[2] == -1 && Hand2Face[2] - Hand2Face[3] == -1 && Hand2Face[3] - Hand2Face[4] == -1)
                        {
                            ScoreP1 = 9;
                        }
                        else if (Hand2Face[0] - Hand2Face[4] == -12 && Hand2Face[1] - Hand2Face[2] == -1 && Hand2Face[2] - Hand2Face[3] == -1 && Hand2Face[3] - Hand2Face[4] == -1)
                        {
                            ScoreP1 = 10;
                        }
                    }
                    if (Hand2Face[0] != face.Ace)
                    {
                        if (Hand2Face[0] - Hand2Face[1] == -1 && Hand2Face[1] - Hand2Face[2] == -1 && Hand2Face[2] - Hand2Face[3] == -1 && Hand2Face[3] - Hand2Face[4] == -1)
                        {
                            ScoreP1 = 9;
                        }
                    }
                    if (ScoreP1 == 0)
                    {
                        ScoreP1 = 6;
                    }
                }
                if (Hand2Face[0] == Hand2Face[1])
                {
                    if (Hand2Face[0] == Hand2Face[2])
                    {
                        if (Hand2Face[3] == Hand2Face[4])
                        {
                            ScoreP1 = 7;
                        }
                    }
                }
                if (Hand2Face[2] == Hand2Face[3])
                {
                    if (Hand2Face[2] == Hand2Face[4])
                    {
                        if (Hand2Face[0] == Hand2Face[1])
                        {
                            ScoreP1 = 7;
                        }
                    }
                }

                if (Hand2Face[0] == Hand2Face[1])
                {
                    if (Hand2Face[0] == Hand2Face[2])
                    {
                        if (Hand2Face[0] == Hand2Face[3])
                        {
                            ScoreP1 = 8;
                        }
                        else
                        {
                            ScoreP1 = 4;
                        }
                    }
                    else
                    {
                        if (ScoreP1 == 3)
                        {
                            break;
                        }
                        else
                        {
                            ScoreP1 = 2;
                        }
                    }
                }
                if (Hand2Face[1] == Hand2Face[2])
                {
                    if (Hand2Face[1] == Hand2Face[3])
                    {
                        if (Hand2Face[1] == Hand2Face[4])
                        {
                            ScoreP1 = 8;
                        }
                        else
                        {
                            ScoreP1 = 4;
                        }
                    }
                    else
                    {
                        if (ScoreP1 == 3)
                        {
                            break;
                        }
                        else
                        {
                            ScoreP1 = 2;
                        }
                    }

                }
                if (Hand2Face[0] == Hand2Face[1] && Hand2Face[2] == Hand2Face[3])
                {
                    ScoreP1 = 3;
                }
                if (Hand2Face[1] == Hand2Face[2] && Hand2Face[3] == Hand2Face[4])
                {
                    ScoreP1 = 3;
                }
                if (Hand2Face[0] == Hand2Face[1] && Hand2Face[3] == Hand2Face[4])
                {
                    ScoreP1 = 3;
                }
                if (Hand2Face[2] == Hand2Face[3])
                {
                    if (Hand2Face[2] == Hand2Face[4])
                    {
                        ScoreP1 = 4;
                    }
                }
                else
                {
                    if (ScoreP1 == 3)
                    {
                        break;
                    }
                    else
                    {
                        ScoreP1 = 2;
                    }
                }
                if (Hand2Face[3] == Hand2Face[4])
                {
                    if (ScoreP1 == 3)
                    {
                        break;
                    }
                    else
                    {
                        ScoreP1 = 2;
                    }
                }
                if (Hand2Face[0] - Hand2Face[1] == -1 && Hand2Face[1] - Hand2Face[2] == -1 && Hand2Face[2] - Hand2Face[3] == -1 && Hand2Face[3] - Hand2Face[4] == -1)
                {
                    ScoreP1 = 5;
                }
                else
                {
                    ScoreP1 = 1;

                }

                /*MessageBox.Show("works");
                for (int didntusethisi = 0; didntusethisi < Hand1Suites.Length; didntusethisi++)
                {
                    newOutput += ((face)Hand1Face[didntusethisi]).ToString() + "\n";
                }
                MessageBox.Show(newOutput);

                Array.Sort(Hand1Face);
                newOutput = "";
                for (int didntusethisi = 0; didntusethisi < Hand1Suites.Length; didntusethisi++)
                {
                    newOutput += ((face)Hand1Face[didntusethisi]).ToString() + "\n";
                }
                MessageBox.Show(newOutput);

                MessageBox.Show(((int)(Hand1Face[0] - Hand1Face[1])).ToString());*/
                MessageBox.Show(ScoreP1.ToString() +" " + ScoreP2.ToString());
            }
            WinnerLabel.Content = "Player 1 wins This many times: " + Player1Count;
        }

        private void CheckForStraightFlush(face[] Hand1Face)
        {
            if (Hand1Face[0] - Hand1Face[1] == -1 && Hand1Face[1] - Hand1Face[2] == -1 && Hand1Face[2] - Hand1Face[3] == -1 && Hand1Face[3] - Hand1Face[4] == -1)
            {
                ScoreP1 = 9;
            }
        }

        private void CheckForFlushes(face[] Hand1Face)
        {
            //check if Ace, two,...five
            if (Hand1Face[0] - Hand1Face[1] == -1 && Hand1Face[1] - Hand1Face[2] == -1 && Hand1Face[2] - Hand1Face[3] == -1 && Hand1Face[3] - Hand1Face[4] == -1)
            {
                ScoreP1 = 9;
            }
            else if (Hand1Face[0] - Hand1Face[4] == -12 && Hand1Face[1] - Hand1Face[2] == -1 && Hand1Face[2] - Hand1Face[3] == -1 && Hand1Face[3] - Hand1Face[4] == -1)
            {
                ScoreP1 = 10;
            }
        }
    }
}
