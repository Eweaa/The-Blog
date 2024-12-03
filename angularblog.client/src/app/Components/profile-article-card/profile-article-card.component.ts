import {Component, Input} from '@angular/core';
import {DatePipe, NgIf, SlicePipe} from "@angular/common";
import {RouterLink} from "@angular/router";
import {ArticleBookmark} from "../../Models/ArticleBookmark";

@Component({
  selector: 'app-profile-article-card',
  standalone: true,
    imports: [
        DatePipe,
        NgIf,
        RouterLink,
        SlicePipe
    ],
  templateUrl: './profile-article-card.component.html',
  styleUrl: './profile-article-card.component.css'
})
export class ProfileArticleCardComponent
{
  @Input() article: any;

  bookmark(article: ArticleBookmark)
  {
    console.log("Bookmark");
    article.isBookmarked = !article.isBookmarked;
  }
}
