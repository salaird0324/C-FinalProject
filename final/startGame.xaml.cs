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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace salf22FinalSnake
{


    /// <summary>
    /// Interaction logic for startGame.xaml
    /// </summary>
    public partial class startGame : Window
    {
        DispatcherTimer time;
        DispatcherTimer bombTime;
        List<loadTheSnake> snake;
        List<addFood> food;
        List<getBomb> bomb;
        Random rand = new Random();
        double x = 100;
        double y = 100;
        int dir = 0;
        int goleft = 4;
        int goright = 6;
        int goup = 8;
        int godown = 2;
        int totalScore = 0;
        int count = 0;
        String message = "oh no you hit yourself! Try again.";
        String OOBMessage = "looks like you hit the wall! Try again.";
        String wrongFood = "Your snake got food poisoning! Try again.";

        public startGame()
        {
            InitializeComponent();
            time = new DispatcherTimer();
            bombTime = new DispatcherTimer();
            snake = new List<loadTheSnake>();
            food = new List<addFood>();
            bomb = new List<getBomb>();
            snake.Add(new loadTheSnake(x, y));
         
            bomb.Add(new getBomb(rand.Next(0, 25) * 10, rand.Next(0, 25) * 10));
            bomb[0].setBombPosition();
            food.Add(new addFood(rand.Next(0, 37) * 10, rand.Next(0, 35) * 10));
            time.Interval = new TimeSpan(0, 0, 0, 0, 100);
            bombTime.Interval = new TimeSpan(0, 0, 0, 20);
            bombTime.Tick += getBombTime;
            time.Tick += updateCanvas;

           
        }

        void getBombTime(object sender, EventArgs e) {
            bomb[0] = new getBomb(rand.Next(0, 37) * 10, rand.Next(0, 35) * 10);

            mycanvas.Children.Add(bomb[0].ell);
        }

        void addfood()
        {
            food[0].setfoodposition();
         
            mycanvas.Children.Insert(0, food[0].ell);
         
           
        }

        void addBomb()
        {
            foreach (getBomb bomb in bomb)
            {
                bomb.setBombPosition();

                mycanvas.Children.Add(bomb.ell);
            }


        }


        void addsnake()
        {
            foreach (loadTheSnake snake in snake)
            {
                snake.setsnakeposition();
                mycanvas.Children.Add(snake.rec);
            }
        }



        void updateCanvas(object sender, EventArgs e)
        {


            if (totalScore >= 5)
            {
                time.Interval = new TimeSpan(0, 0, 0, 0, 90);

            }
            if (totalScore >= 10)
            {
                time.Interval = new TimeSpan(0, 0, 0, 0, 80);
            }
             if (totalScore >= 15)
            {
                time.Interval = new TimeSpan(0, 0, 0, 0, 70);
            }
            if (totalScore >= 20) {
                time.Interval = new TimeSpan(0, 0, 0, 0, 60);
            }
            if (totalScore >= 25)
            {
                time.Interval = new TimeSpan(0, 0, 0, 0, 50);
            }
            if (totalScore >= 30)
            {
                time.Interval = new TimeSpan(0, 0, 0, 0, 40);
            }
            if (totalScore >= 35)
            {
                time.Interval = new TimeSpan(0, 0, 0, 0, 30);
            }


            if (dir != 0)
            {
                for (int i = snake.Count - 1; i > 0; i--)
                {
                    snake[i] = snake[i - 1];
                }
            }


            if (dir == goup)
            {
                y -= 10;
            }
            if (dir == godown)
            {
                y += 10;
            }
            if (dir == goleft)
            {

                x -= 10;
            }
            if (dir == goright)
            {
                x += 10;
            }


            if (snake[0].x == food[0].x && snake[0].y == food[0].y)
            {
                snake.Add(new loadTheSnake(food[0].x, food[0].y));
                food[0] = new addFood(rand.Next(0, 37) * 10, rand.Next(0, 35) * 10);
                bomb[0] = new getBomb(rand.Next(0, 37) * 10, rand.Next(0, 35) * 10);
                mycanvas.Children.RemoveAt(0);
                bomb[0].setBombPosition();
                mycanvas.Children.Add(bomb[0].ell);
                
                addfood();
                totalScore++;
               
                Score.Text = totalScore.ToString();
            }

            if (snake[0].x == bomb[0].x && snake[0].y == bomb[0].y) {
                MessageBox.Show(wrongFood);
                this.Close();
            }


            snake[0] = new loadTheSnake(x, y);

            if (snake[0].x > 370 || snake[0].y > 350 || snake[0].x < 0 || snake[0].y < 0)
            {
                
                this.Close();
            }


            for (int i = 1; i < snake.Count; i++)
            {

                if (snake[0].x == snake[i].x && snake[0].y == snake[i].y)
                {

                    MessageBox.Show(message);
                    this.Close();
                }
            }


            for (int i = 0; i < mycanvas.Children.Count; i++)
            {
                if (mycanvas.Children[i] is Rectangle || mycanvas.Children[i] is Ellipse)
                    count++;
            }
            mycanvas.Children.RemoveRange(1, count);
            count = 0;
            addBomb();
            addsnake();
            
        }


        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up && dir != godown)
            {
                dir = goup;
            }
            if (e.Key == Key.Down && dir != goup)
            {
                dir = godown;
            }
            if (e.Key == Key.Left && dir != goright)
            {
                dir = goleft;
            }
            if (e.Key == Key.Right && dir != goleft)
            {
                dir = goright;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            addsnake();
            addBomb();
            addfood();
           

            time.Start();
        }
    }
}
