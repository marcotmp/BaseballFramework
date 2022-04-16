using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcoTMP.BaseballFramework.Core
{
    public enum Half
    {
        FirstHalf = 1,
        SecondHalf = 2
    }

    public class InningsManager
    {
        public int inning;
        public int finalInning = 9;
        public CompetingTeam ofensive;
        public CompetingTeam defensive;
        public string winner = "";
        public int maxInnings = 9;
        public Half half = Half.FirstHalf;

        public Action OnInningComplete { get; set; }

        public void CompleteInning()
        {
            if (inning >= finalInning)
            {
                // check draw
                if (ofensive.runs == defensive.runs)
                {
                    if (inning < maxInnings)
                    {
                        winner = "";
                        inning++; // extra inning
                    }
                    else
                        winner = "Empate";
                }
                else if (ofensive.runs > defensive.runs)
                    winner = ofensive.team;
                else
                    winner = defensive.team;
            }
            else
            {
                inning++;
                winner = "";
            }

            OnInningComplete?.Invoke();
        }

        public void CompleteHalf()
        {
            if (half == Half.SecondHalf)
            {
                CompleteInning();
                half = Half.FirstHalf;
            }
            else
            {
                half = Half.SecondHalf;
            }

            // if there is no winner, swap competitors
            if (string.IsNullOrEmpty(winner))
                SwapCompetitors();
        }

        private void SwapCompetitors()
        {
            CompetingTeam tmpOfensive = ofensive;
            ofensive = defensive;
            defensive = tmpOfensive;

        }
    }
}
