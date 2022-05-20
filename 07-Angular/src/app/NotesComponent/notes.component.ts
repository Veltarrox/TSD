import { Component, OnInit } from "@angular/core";
import Note from "./note.ts";

@Component({
  selector: "app-notes",
  templateUrl: "./notes.component.html",
  styleUrls: ["./notes.component.css"]
})
export class NotesComponent implements OnInit {
  notes: Note[] = [
    { text: "Note1", date: new Date("2012-02-18") },
    { text: "Note2", date: new Date("2011-12-15") },
    { text: "Note3", date: new Date("2021-11-05") }
  ];

  ngOnInit(): void {}
}
