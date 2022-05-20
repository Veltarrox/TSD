package main

import (
	"fmt"
	"strings"
)

func WordCount(s string) map[string]int {
	m := make(map[string]int)
    words := strings.Fields(s) 
	for i := 0; i < len(words); i++ {
		m[words[i]]+=1
	}
	
	return m
}

func main() {
	var text="word word not me once once once a b c"
	fmt.Print(WordCount(text))
}
