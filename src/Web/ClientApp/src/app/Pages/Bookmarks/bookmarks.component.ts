import { Component } from '@angular/core';
import { ArticleDto, ArticlesClient } from '../../web-api-client';

@Component({
  selector: 'app-bookmarks',
  templateUrl: './bookmarks.component.html',
  styleUrls: ['./bookmarks.component.scss']
})
export class BookmarksComponent {
  constructor(private service: ArticlesClient) { }

  data: Array<any> = [];
  ngOnInit() {
    this.service.getBookmarkArticles(1).subscribe(res => {
      this.data = res;
      console.log(this.data)
    })
  }

}
