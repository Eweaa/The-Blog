import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ArticlesClient, WritersClient } from '../../web-api-client';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent {
  constructor(private WriterService: WritersClient, private ArticleService: ArticlesClient) { }
  data: any = [];
  

  newPost: boolean = false;

  toggleNewPost = () => {
    this.newPost = !this.newPost;
  }

  CreateArticle = () => {
    let WriterId = (<HTMLInputElement>document.getElementById("WriterId")).value;
    let Title = (<HTMLInputElement>document.getElementById("Title")).value;
    let Content = (<HTMLInputElement>document.getElementById("Content")).value;
    let ArticleImg = (<HTMLInputElement>document.getElementById("ArticleImg")).value;
    console.log(WriterId, Title, Content, ArticleImg)
    this.ArticleService.createArticle(Title, Content, ArticleImg, parseInt(WriterId)).subscribe(() => {
      console.log('it worked')
    })
  }

  ngOnInit() {
    const currentUrl = window.location.href;
    const Id = currentUrl.split("https://localhost:44447/profile/");
    this.WriterService.getWriter(parseInt(Id[1])).subscribe(res => {
      console.log(res);
      this.data = res;
    })
  }
}
