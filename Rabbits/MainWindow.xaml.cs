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
using System.Windows.Threading;

namespace Rabbits
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Bunny> bunnies = new List<Bunny>();
        Population population = new Population();
        Random random = new Random();

        int femaleRabbitCount = 0;
        int maleRabbitCount = 0;


        int pregCount = 0;
        

        public MainWindow()
        {

            InitializeComponent();
            //AddRabbit();
            //AddRabbit();
            UpdateRabbitDisplay();

            var timer = new DispatcherTimer
            {


            };
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Start();

        }
        private void Timer_Tick(object? sender, EventArgs e)
        {
            //AddRabbit();
            UpdateRabbitDisplay();
            UpdatePregoRabbitDisplay();
           
            foreach (Bunny bunny in bunnies.ToList())
            {
                
                bunny.BunnyAge++;
                
                if (bunny.BunnyIsFemale == true && random.Next(6) > 3 && bunny.BunnyIsPreg == false && maleRabbitCount >= 1 )
                {
                            bunny.Mate(bunny);
                }

                if (bunny.BunnyIsPreg == true && bunny.PregTerm < 6)
                {
                    bunny.PregTerm++;
                }
                if (bunny.PregTerm == 6)
                {
                    GiveBirth();
                    bunny.PregTerm = 0;
                    bunny.BunnyIsPreg = false;
                    bunny.PregChecked = false;
                    pregCount--;
                }
                if (bunny.BunnyAge > 1)
                {
                    if (random.Next(1, 25) == 1 && bunny.BunnyAge > 1)
                    {
                        bunnies.Remove(bunny);
                    }
                    if (random.Next(1, 5) == 1 && bunny.BunnyAge >= 7)
                    {
                        bunnies.Remove(bunny);
                    }
                    if (random.Next(1, 2) == 1 && bunny.BunnyAge >= 10)
                    {
                        bunnies.Remove(bunny);
                    }
                    if (bunny.BunnyAge >= 15)
                    {
                        bunnies.Remove(bunny);
                    }


                }  
            } 
        }
        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            AddRabbit();
            UpdateRabbitDisplay();
            
        }
        public void UpdateRabbitDisplay()
        {
            femaleRabbitCount = 0;
            maleRabbitCount = 0;

            rabbitPopulation.Text = bunnies.Count().ToString();
            foreach (Bunny bunny in bunnies)
            { 
                if(bunny.BunnyIsFemale == true) femaleRabbitCount++;
                else maleRabbitCount++;
            }
            femaleRabbits.Text = femaleRabbitCount.ToString();
            maleRabbits.Text = maleRabbitCount.ToString();
        }

        public void UpdatePregoRabbitDisplay()
        {
            
            foreach (Bunny bunny in bunnies)
            {

                if (bunny.BunnyIsPreg == true && bunny.PregChecked == false)
                {
                    pregCount++;
                    bunny.PregChecked = true;
                }


            }
            pregoRabbitPopulation.Text = pregCount.ToString();

        }
        public void AddRabbit()
        {
             
            if (random.Next(1, 10) <= 6)
            {
                 bunnies.Add(new Bunny() { BunnyIsFemale = true, BunnyNumber = bunnies.Count() + 1, BunnyAge = 0, BunnyIsPreg = false, PregTerm = 0, PregChecked = false}); ;
            }
            else
                bunnies.Add(new Bunny() { BunnyIsFemale = false, BunnyNumber = bunnies.Count() + 1, BunnyAge = 0, BunnyIsPreg = false });
        }
        public void GiveBirth()
        {
            int fluffleSize = random.Next(2, 5);
            for (int i = 0; i < fluffleSize; i++)
            {
                AddRabbit();
                
            }
            
        }
       
            

        
       
    }
}
