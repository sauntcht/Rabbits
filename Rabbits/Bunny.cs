using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbits
{
    internal class Bunny
    {
        Random random = new Random();

        

        private int bunnyNumber;
        private int bunnyAge;
        private bool bunnyIsFemale;
        private bool bunnyIsPreg;
        private int pregTerm;
        private bool pregChecked = false;
        
        
        public int BunnyNumber { get; set; }
        public int BunnyAge { get; set;}
        public bool BunnyIsFemale { get; set; }
        public bool BunnyIsPreg { get; set; }
        public int PregTerm { get; set; }
        public bool PregChecked { get; set; }

        

        public void LookForFood(int luck)
        { 
            // 2 in 5 chance food is found - else perish()
        
        }
        public void Mate(Bunny bunny)
        {
            if (random.Next(2) < 1)
            { 
                bunny.BunnyIsPreg = true;
            }
        }
       
        
        
        



    }
}
