import { Component, Input } from '@angular/core';
import {RouterModule} from "@angular/router";
import {CommonModule} from "@angular/common";
import {Article} from "../../Models/Article";
import {ArticleBookmark} from "../../Models/ArticleBookmark";
import {ArticleService} from "../../Services/article.service";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-article-card',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './article-card.component.html',
  styleUrl: './article-card.component.css'
})
export class ArticleCardComponent
{

  constructor(private articleService: ArticleService, private toastr: ToastrService) {}

  @Input() article: any;

  bookmark(article: ArticleBookmark)
  {
    if(article.isBookmarked)
    {
      article.isBookmarked = false;
      this.articleService.removeBookmark(article.id).subscribe({
        next: res => {
          console.log(res);
          this.toastr.success("Removed from Bookmarks");
        },
        error: err => {
          console.log(err);
          this.toastr.error("Failed Removing from Bookmarks", "", { positionClass: "toast-bottom-right" });
        }
      })
    }
    else
    {
      article.isBookmarked = true;
      this.articleService.addBookmark(article.id).subscribe({
        next: res => {
          console.log(res);
          this.toastr.success("Added to Bookmarks");
        },
        error: err => {
          console.log(err);
          this.toastr.error("Failed Adding to Bookmarks", "", { positionClass: "toast-bottom-right" });
        }
      })
    }
  }
}
