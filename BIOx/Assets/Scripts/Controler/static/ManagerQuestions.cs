using System;
using System.Collections.Generic;
using Unity.VisualScripting;

public static class ManagerQuestions {
    private class Question {
        private string question;
        private string correct;
        private string incorrect;
        public Question(string question,
                        string correct,
                        string incorrects) {
            this.question = question;
            this.correct = correct;
            this.incorrect = incorrects;
        }

        public bool IsCorrect(string res) {
            return res == correct;
        }
        public string ToString() {
            return question + ";;" + correct + ";;" + incorrect;
        }
    }
    private static Question[] listQuestions = {
        new Question("Os biodigestores só podem ser utilizados em unidades produtivas de médio e grande porte?",
                    "Falso",
                    "Verdadeiro"),
        new Question("Em que processo biológico os biodigestores estão envolvidos?",
                    "Digestão anaeróbica",
                    "Fotossíntese"),
        new Question("Quais são os principais tipos de resíduos que podem ser utilizados em biodigestores?",
                    "Estercos e restos de alimentos",
                    "Papel e plástico"),
        new Question("Como a temperatura afeta o desempenho de um biodigestor?",
                    "Altas temperaturas aumentam a atividade microbiana",
                    "A temperatura não influencia"),
        new Question("Quais são os benefícios ambientais associados ao uso de biodigestores?",
                    "Redução de emissões de metano e reciclagem de nutrientes",
                    "Aumento da poluição atmosférica"),
    };
    private static int questionsQuant = listQuestions.Length;
    private static int[] orderQuestion = new int[questionsQuant];
    private static int numQuestion = 0;
    private static Question activeQuest = null;
    
    public static string SortRandomQuest() {
        if(numQuestion == questionsQuant) numQuestion = 0;
        if(numQuestion == 0) createOrderQuestion();
        Question quest = listQuestions[orderQuestion[numQuestion]];
        numQuestion++;
        activeQuest = quest;
        return quest.ToString();
    }
    public static bool CheckeedIfCorrect(string res) {
        bool isCorrect = activeQuest.IsCorrect(res);
        return isCorrect;
    }

    private static void createOrderQuestion() {
        Random rand = new Random();
        List<int> numbers = new List<int>();
        for(int i = 0; i < questionsQuant; i++) numbers.Add(i);
        for(int i = 0; i < questionsQuant; i++) {
            int indexNumber = rand.Next(0, numbers.Count);
            orderQuestion[i] = numbers[indexNumber];
            numbers.RemoveAt(indexNumber);
        }
    }
}