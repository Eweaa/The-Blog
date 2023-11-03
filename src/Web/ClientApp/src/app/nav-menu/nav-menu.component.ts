import { Component } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.scss']
})
export class NavMenuComponent {

  drop: boolean = true;

  dark: boolean = true;

  body = document.getElementById('Body');

  toggleTheme = () => {
    this.dark = !this.dark;
    if(this.body.classList.contains('dark')){
      this.body.classList.remove('dark');
      this.body.classList.add('light')
    }
    else{
      this.body.classList.remove('light');
      this.body.classList.add('dark')
    }
  }

  showDrop = () => {
    this.drop = !this.drop
  }
}
