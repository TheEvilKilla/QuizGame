using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace QuizGame
{
    class Quiz
    {

        private string description = "Este es un juego tipo trivia, donde tendras que responder 5 preguntas correctamente. Las instrucciones son simples, " +
                                    "debes seleccionar la opcion correcta entre las que le son brindadas para continuar a la siguiente pregunta que tendra un mayor nivel de dificultad. " +
                                    "Por cada respuesta correcta tendra la posibilidad de retirarse del juego y llevarse el premio o en caso de decidir continuar, debera responder correctamente " +
                                    "o perdera todos los puntos que acumulo, dando asi final al juego.";
        private Player currentPlayer;
        private Question quest;
        public Quiz()
        {

        }

        public void Play()
        {
            Console.WriteLine("Bienvenido al juego");
            Console.WriteLine($"{description}");
            Console.WriteLine();

            Console.Write("¿Cual es su nombre?: ");
            string playerName = Console.ReadLine();
            currentPlayer = new Player(playerName);

            Console.WriteLine($"Bienvenido {currentPlayer.getName()}, su puntuacion actual es {currentPlayer.getScore()}");
            quest = new Question();

            //Lista de las categorias, esto se simplifica si se vuelven numeros y no tendriamos que hacer esto
            string[] categories = { "Fácil", "Principiante", "Leyenda", "Conocedor", "Profesional" };

            //Lista de puntos obtenidos segun la categoria, el elemento i de este array corresponde a los puntos de 
            //la categoria con indice i
            int[] points = { 1, 2, 3, 4, 5 };

            for (int i = 0; i < categories.Length; i++)
            {
                //Realiza la pregunta, la imprime y nos retorna la respuesta. Secreta a la vista del jugador
                string answer = quest.askQuestion(categories[i]);
                Console.WriteLine("Ingrese su respuesta, recuerde que debe ser explicitamente A,B,C o D");
                string playerAnswer = Console.ReadLine().ToUpper();

                if (answer.Equals(playerAnswer))
                {
                    currentPlayer.increaseScore(points[i]);
                    string continuee;

                    if (i == categories.Length - 1)
                    {
                        Console.WriteLine($"Felicidades por terminar todo el Quiz, se puede llevar {currentPlayer.getScore()} puntos y gracias por participar");
                        writeHistory(currentPlayer);

                        //Acaba el juego
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"¡Respuesta correcta!, ¿Desea continuar o llevarse su premio? (Su puntuacion actual es {currentPlayer.getScore()})");
                        Console.WriteLine("A para continuar, otra tecla para caso omiso");
                        continuee = Console.ReadLine().ToUpper();
                    }
                    //Continuar?
                    if (!continuee.Equals("A"))
                    {
                        Console.WriteLine($"Llevate tu premio de {currentPlayer.getScore()} puntos y gracias por participar");
                        writeHistory(currentPlayer);
                        //Acaba el juego
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("¡Respuesta incorrecta!, lo lamentamos y vuelva pronto.");
                    writeHistory(currentPlayer);

                    //Acaba,el juego
                    break;
                }
            }
        }

        private static async Task writeHistory(Player pPlayer)
        {
            string path = "./data/History.txt";
            string text = $"Player: {pPlayer.getName()}, Score: {pPlayer.getScore()}, Date: {pPlayer.getDate()}";
            using StreamWriter file = new(path, append: true);
            await file.WriteLineAsync(text);
        }
    }
}