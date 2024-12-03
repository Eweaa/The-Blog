import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ArticleService} from "../../Services/article.service";
import {ArticleCardComponent} from "../../Components/article-card/article-card.component";
import { Article } from '../../Models/Article';

@Component({
  selector: 'app-bookmarks',
  standalone: true,
  imports: [
    ArticleCardComponent
  ],
  templateUrl: './bookmarks.component.html',
  styleUrl: './bookmarks.component.css'
})
export class BookmarksComponent implements OnInit
{
  constructor(private articleService: ArticleService) { }

  articles!: Array<Article>;

  ngOnInit(): void
  {

    this.articleService.getBookmarks().subscribe({
      next: res => {
        console.log(res);
        this.articles = [...res];
      },
      error: err => {
        console.log(err);
      }
    })
  }


}
