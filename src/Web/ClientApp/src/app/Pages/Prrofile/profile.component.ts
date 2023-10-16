import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WritersClient } from '../../web-api-client';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent {
  constructor(private service: WritersClient) { }
  data: any = [];
  

  newPost: boolean = false;

  toggleNewPost = () => {
    this.newPost = !this.newPost;
  }

  ngOnInit() {
    const currentUrl = window.location.href;
    const Id = currentUrl.split("https://localhost:44447/profile/");
    this.service.getWriter(parseInt(Id[1])).subscribe(res => {
      console.log(res);
      this.data = res;
    })
  }
}
