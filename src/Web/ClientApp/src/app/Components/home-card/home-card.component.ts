import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-home-card',
  templateUrl: './home-card.component.html',
  styleUrls: ['./home-card.component.scss']
})
export class HomeCardComponent {
  @Input() article: article[] = [];

  bookmarkIcon: boolean = false;

  bookmark = () => {
    this.bookmarkIcon = !this.bookmarkIcon
  }

  GenericUser: string = "../../../assets/GenericUser.png";
}


interface article {
  id: number,
  writerImg: string,
  writer: string,
  date: string,
  title: string,
  content: string,
  articleImg: string,
}
