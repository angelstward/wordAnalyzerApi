import { Component, OnInit } from "@angular/core";
import { MessageModel } from "../models/message.model";
import { TextModel } from "../models/Text.model";
import { WordModel } from "../models/word.model";
import { SenderService } from "../services/sender.service";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.css"],
})
export class HomeComponent implements OnInit {
  ngOnInit(): void {}

  constructor(private service: SenderService) {}

  public textToSend: string = "";
  public listWords: WordModel[];

  public ApplyChange(text: string) {
    this.textToSend = text;
  }

  public sendText() {
    const textModel: TextModel = {
      body: this.textToSend,
    };
    this.service
      .GetWords(textModel)
      .subscribe((x: MessageModel<WordModel[]>) => {
        if (x.status) {
          this.listWords = x.data;
        }
      });
      this.textToSend = "";
  }

  public cleanText(): void {
    this.textToSend = "";
    this.listWords = [];

  }
}
