using System;
using System.Collections.Generic;
using System.Text;

namespace QuizGame
{
    class Player
    {

        private string name;
        private int score;
        private DateTime date;
        public Player(string pName)
        {
            name = pName;
            score = 0;
            date = DateTime.Now;
        }

        public string getName()
        {
            return name;
        }

        public int getScore()
        {
            return score;
        }

        public DateTime getDate()
        {
            return date;
        }

        public void increaseScore(int pScore)
        {
            score += pScore;
        }
    }
}