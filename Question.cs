using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO;

namespace QuizGame
{
    class Question
    {
        private ArrayList quest = new ArrayList();

        public Question()
        {

        }

        public string askQuestion(string pCategoria)
        {
            using (var reader = new StreamReader(@"./data/Questions.csv"))
            {
                //Lee la primera linea que tiene informacion irrelevante
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    //Agrego todos los arreglos con las preguntas, no distingue categorias
                    quest.Add(values);
                }
            }

            ArrayList element = new ArrayList();
            foreach (string[] item in quest)
            {
                //Si cumple con la categoria que queremos, lo agrega a las preguntas
                if (item[0].Equals(pCategoria))
                {
                    //Agrega la informacion de toda la pregunta, es un array
                    element.Add(item);
                }
            }

            Random rnd = new Random();
            //Generamos un numero aleatorio entre la cantidad de preguntas de la categoria deseada
            int choosed = rnd.Next(element.Count);

            string[] selected = (string[]) element[choosed];

            //Imprimimos la pregunta
            Console.WriteLine(selected[1]);

            //Imprimos las opciones, podria hacerse en un for si hubieran mas de 4 opciones, eso depende del negocio
            //Se dejara asi por simplicidad
            Console.WriteLine($"A. {selected[2]}");
            Console.WriteLine($"B. {selected[3]}");
            Console.WriteLine($"C. {selected[4]}");
            Console.WriteLine($"D. {selected[5]}");

            //Y para trabajar en la clase principal, retornamos la respuesta correcta
            return selected[6];
        }
    }
}