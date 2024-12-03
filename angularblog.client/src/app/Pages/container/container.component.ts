import { Component } from '@angular/core';
import {NavbarComponent} from "../../Components/navbar/navbar.component";
import {RouterModule} from "@angular/router";

@Component({
  selector: 'app-container',
  standalone: true,
  imports: [NavbarComponent, RouterModule],
  templateUrl: './container.component.html',
  styleUrl: './container.component.css'
})
export class ContainerComponent {

}
