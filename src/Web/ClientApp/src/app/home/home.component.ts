import { Component } from '@angular/core';
import { ArticlesClient } from '../web-api-client';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  data: article[];
  constructor(private service: ArticlesClient) { }
  ngOnInit() {
    this.service.getArticles().subscribe(res => {
      this.data = res;
    })
  }
  test:article[];

  bookmarkIcon: boolean = false;

  bookmark = () => {
    this.bookmarkIcon = !this.bookmarkIcon
  }

  GenericUser: string = "../../../assets/GenericUser.png";
}


interface article {
  id?: number,
  writerImg?: string,
  writerName?: string,
  writerId?: number,
  date?: string,
  title?: string,
  content?: string,
  articleImg?: string,
}
