import {Component, OnInit} from '@angular/core';
import {Subscription} from "rxjs";
import {Article} from "../../Models/Article";
import {ArticleService} from "../../Services/article.service";
import {ActivatedRoute, RouterLink} from "@angular/router";

@Component({
  selector: 'app-article',
  standalone: true,
  imports: [
    RouterLink
  ],
  templateUrl: './article.component.html',
  styleUrl: './article.component.css'
})

export class ArticleComponent implements OnInit
{
  constructor(private activatedRoute: ActivatedRoute, private articleService: ArticleService) {}

  articleSub: Subscription | null = null;
  // article: Article = new Article("", "", "", "", "", "", "");
  article!: Article;

  ngOnInit(): void
  {
    this.loadData();
  }

  loadData()
  {
    this.articleSub = this.activatedRoute.params.subscribe(params => {
      this.articleService.getArticleById(params['Id']).subscribe({
        next: res => {
          console.log(res);
          this.article = res;
        },
        error: err => {
          console.log(err);
        }
      })
    })
  }
}


