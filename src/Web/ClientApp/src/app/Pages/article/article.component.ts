import { Component } from '@angular/core';
import { ArticlesClient } from '../../web-api-client';

@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.scss']
})
export class ArticleComponent {
  Article: any;
  constructor(private service: ArticlesClient) { }
  ngOnInit() {
    const currentUrl = window.location.href;
    const Id = currentUrl.split("https://localhost:44447/article/");
    //console.log(currentUrl);
    //console.log("test", test);
    this.service.getArticle(parseInt(Id[1])).subscribe(res => {
      this.Article = res;
      console.log(res);
    })
  }
}
