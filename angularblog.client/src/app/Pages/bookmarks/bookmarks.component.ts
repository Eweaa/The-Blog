import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ArticleService} from "../../Services/article.service";
import {ArticleCardComponent} from "../../Components/article-card/article-card.component";
import { Article } from '../../Models/Article';
import {LoaderComponent} from "../../Components/loader/loader.component";

@Component({
  selector: 'app-bookmarks',
  standalone: true,
  imports: [
    ArticleCardComponent,
    LoaderComponent,
  ],
  templateUrl: './bookmarks.component.html',
  styleUrl: './bookmarks.component.css'
})
export class BookmarksComponent implements OnInit
{
  constructor(private articleService: ArticleService) { }

  articles: Array<Article> = [];
  loading: boolean = false;

  ngOnInit(): void
  {
    this.loadBookmarks();
  }

  loadBookmarks()
  {
    this.articleService.getBookmarks().subscribe({
      next: res => {
        console.log(res)
        for(let i = 0; i < res.length; i++)
        {
          let obj = JSON.parse(JSON.stringify(res[i]));
          obj.isBookmarked = true;
          this.articles.push(obj);
        }
        setTimeout(()=>{
          this.loading = true;
        }, 1000)
      },
      error: err => {
        console.log(err);
      }
    })
  }

}
