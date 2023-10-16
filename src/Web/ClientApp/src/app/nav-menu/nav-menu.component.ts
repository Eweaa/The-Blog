import { Component } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.scss']
})
export class NavMenuComponent {

  drop: boolean = true;

  dark: boolean = true;

  toggleTheme = () => {
    this.dark = !this.dark;
  }

  showDrop = () => {
    this.drop = !this.drop
  }
}
