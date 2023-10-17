import { Component } from '@angular/core';
import { ArticleDto, ArticlesClient } from '../web-api-client';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  data: articleb[];
  constructor(private service: ArticlesClient) { }
  ngOnInit() {
    this.service.getArticles().subscribe(res => {
      this.data = [];
       
      for (var i = 0; i < res.length; i++) {
        var obj = JSON.parse(JSON.stringify(res[i])) 
        obj.isBookmarked = false;
        this.data.push(obj)
      }
      console.log(this.data)
    })
  }
   
  bookmark = (a: articleb) => {
    a.isBookmarked = !a.isBookmarked;
  }

  GenericUser: string = "../../../assets/GenericUser.png";
}

interface articleb extends ArticleDto {
  isBookmarked: boolean
}
