import { ChangeDetectorRef, Component } from '@angular/core';
import { ArticlesClient, BookmarkDto, BookmarksClient } from '../../web-api-client';

@Component({
  selector: 'app-bookmarks',
  templateUrl: './bookmarks.component.html',
  styleUrls: ['./bookmarks.component.scss']
})
export class BookmarksComponent {
  constructor(private service: ArticlesClient, private bookmarkService: BookmarksClient, private changeDetectorRef: ChangeDetectorRef) { }

  data: Array<BookmarkB> = [];
  newList: Array<BookmarkB> = [];

  ngOnInit() {
    this.service.getBookmarkArticles(1).subscribe(res => {
      // this.data = [];

      for (var i = 0; i < res.length; i++) {
        var obj = JSON.parse(JSON.stringify(res[i])) 
        obj.isBookmarked = true;
        this.data.push(obj)
      }
      this.newList = [...this.data];
      console.log(this.data)
    })
  }

  unBookmark = (b: BookmarkB) => {
    this.bookmarkService.removeBookmark(b.id).subscribe(() => console.log('removed'));
    b.isBookmarked = false;
    // console.log(this.data);

    for (let index = 0; index < this.data.length; index++) {
      if(this.newList[index].id === b.id){
        this.newList.splice(index, 1)
      }
    }
  } 
}


interface BookmarkB extends BookmarkDto {
  isBookmarked?: boolean;
}
