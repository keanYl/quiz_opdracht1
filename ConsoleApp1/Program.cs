using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Question> questions = new List<Question>();

            Question first = new Question()
            {
                Difficulty = 1,
                Vraag = "1+1",
                Antwoord = "2"
            };

            ChoiceQuestion second = new ChoiceQuestion()
            {
                Difficulty = 3,
                Vraag = "In which country was the inventor of Java born?"

            };

            second.AddChoice("Australia", false);
            second.AddChoice("Canada", true);
            second.AddChoice("Denmark", false);
            second.AddChoice("United States", false);

            Question third = new Question() {
                Difficulty=2,
                Vraag="10+10",
                Antwoord="20"
            };

            questions.Add(first);
            questions.Add(second);
            questions.Add(third);

            Sortquestions(questions);

            foreach (Question x in questions) {
                Console.WriteLine(x.Difficulty);

            }
            Console.WriteLine("chose difficulty");
           
            int Graad = Convert.ToInt32(Console.ReadLine());


            questions = (from x in questions
                        where x.Difficulty == Graad
                        select x).ToList();

            foreach (Question x in questions) {
                PresentQuestion(x);
            }

        }

        public static void PresentQuestion(Question q)
        {
            q.Display();
            string antwoord = Console.ReadLine();
            if (antwoord == q.Antwoord)
            {
                Console.WriteLine("true");
            }
            else
            {   
                Console.WriteLine("false");
            }
        }
        



        public static void Sortquestions(List<Question> question)
        {
            var order = from x in question orderby x.Difficulty select x;
            foreach(Question x in order) {
                PresentQuestion(x);
                
                }

        }


    }

    class Question
    {
        public int Difficulty { get; set; }
        public string Vraag { get; set; }
        public string Antwoord { get; set; }

        public void SetAntwoord(string Antwoord)
        {
            this.Antwoord = Antwoord;
        }

        public virtual void Display()
        {
            Console.WriteLine(Vraag);
        }
    }

    class ChoiceQuestion : Question
    {
        private List<string> Choices;

        public ChoiceQuestion()
        {

            Choices = new List<string>();
        }

        public void AddChoice(string Choice, bool correct)
        {
            Choices.Add(Choice);
            if (correct)
            {
                SetAntwoord(Choice);
            }
        }

        public override void Display()
        {
            base.Display();
            foreach (string x in Choices)
            {
                Console.WriteLine(x);
            }
        }
    }
}


