import { Component } from '@angular/core';
import { ArticleDto, ArticlesClient, BookmarkDto, BookmarksClient } from '../../web-api-client';

@Component({
  selector: 'app-bookmarks',
  templateUrl: './bookmarks.component.html',
  styleUrls: ['./bookmarks.component.scss']
})
export class BookmarksComponent {
  constructor(private service: ArticlesClient, private bookmarkService: BookmarksClient) { }

  data: Array<BookmarkB> = [];
  ngOnInit() {
    this.service.getBookmarkArticles(1).subscribe(res => {
      // this.data = [];

      for (var i = 0; i < res.length; i++) {
        var obj = JSON.parse(JSON.stringify(res[i])) 
        obj.isBookmarked = true;
        this.data.push(obj)
      }

      console.log(this.data)
    })
  }

  unBookmark = (b: BookmarkB) => {
    console.log('unbookmarked');
    this.bookmarkService.removeBookmark(b.id);
    b.isBookmarked = false;
  } 
}


interface BookmarkB extends BookmarkDto {
  isBookmarked?: boolean;
}
