import {Component, OnDestroy, OnInit} from '@angular/core';
import {HomeService} from "../../Services/home.service";
import {Subscription} from "rxjs";
import {ArticleCardComponent} from "../../Components/article-card/article-card.component";
import {ArticleBookmark} from "../../Models/ArticleBookmark";

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [ArticleCardComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit, OnDestroy
{
  articlesSub: Subscription | null = null;
  articles: Array<ArticleBookmark> = [];

  constructor(private homeService: HomeService) {}

  ngOnInit(): void
  {
    this.loadHomeData();
  }

  loadHomeData(): void
  {
    this.articlesSub = this.homeService.getHomeArticles().subscribe({
      next: res => {
        for(let i = 0; i < res.length; i++)
        {
          let obj = JSON.parse(JSON.stringify(res[i]));
          obj.isBookmarked = obj.isBookmarked == false;
          this.articles.push(obj);
        }
      },
      error: err => {
        console.log(err);
      }
    })
  }

  ngOnDestroy(): void
  {
      this.articlesSub!.unsubscribe();
  }

}
