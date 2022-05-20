package main

import (
	"encoding/csv"
	"fmt"
	"log"
	"os"
	"strconv"
)

type Question struct {
	question string
	answer   string
}

func GetQuestions(dataRaw [][]string) []Question {
	var questionList []Question
	for _, line := range dataRaw {
		var q Question
		for j, field := range line {
			if j == 0 {
				q.question = field
			} else if j == 1 {
				q.answer = field
			}
		}
		questionList = append(questionList, q)
	}
	return questionList
}

func main() {
	file, err := os.Open("quiz.csv")
	if err != nil {
		fmt.Println(err)
	}
	defer file.Close()
	csvReader := csv.NewReader(file)
	dataRaw, err := csvReader.ReadAll()
	if err != nil {
		log.Fatal(err)
	}
	questions := GetQuestions(dataRaw)

	var answer string
	right := 0
	wrong := 0

	for i, q := range questions {
		fmt.Println("Your score is: " + strconv.Itoa(right) + "/" + strconv.Itoa(wrong) + "/" + strconv.Itoa(right+wrong) + "(Right/Wrong/All)")
		fmt.Println("question number " + strconv.Itoa(i) + " is: ")
		fmt.Println(q.question)
		fmt.Println("your answer is:")
		fmt.Scanln(&answer)
		if answer == q.answer {
			right++
		} else {
			wrong++
		}
	}
	fmt.Println("Your final score is " + strconv.Itoa(right) + "/" + strconv.Itoa(wrong) + "/" + strconv.Itoa(right+wrong) + "(Right/Wrong/All)")
}
