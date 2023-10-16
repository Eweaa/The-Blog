import { Component } from '@angular/core';
import { ArticlesClient } from '../../web-api-client';

@Component({
  selector: 'app-bookmarks',
  templateUrl: './bookmarks.component.html',
  styleUrls: ['./bookmarks.component.scss']
})
export class BookmarksComponent {
  constructor(private service: ArticlesClient) { }

  ngOnInit() {
    this.service.getBookmarkArticles(1).subscribe(res => {
      console.table(res);
    })
  }

}
