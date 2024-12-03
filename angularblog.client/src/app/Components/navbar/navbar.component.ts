import {Component, OnDestroy, OnInit} from '@angular/core';
import {Router, RouterModule} from "@angular/router";
import {CommonModule} from "@angular/common";
import {AccountService} from "../../Services/account.service";
import {Subscription} from "rxjs";

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [RouterModule, CommonModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent implements OnInit, OnDestroy
{

  constructor(private router: Router, private accountService: AccountService) {}

  drop: boolean = true;

  dark: boolean = true;

  body: HTMLElement | null = null;

  userSub: Subscription | null = null;
  userName: string | null = null;
  userImg: string | null = null;


  ngOnInit(): void
  {
    this.userName = localStorage.getItem("Name");
    console.log(this.userName);
    this.loadUserInfo();
  }


  loadUserInfo()
  {
    this.userSub = this.accountService.GetUserInfo().subscribe({
      next: res => {
        localStorage.setItem("UserImg", JSON.stringify(res));
        this.userImg = JSON.parse(localStorage.getItem("UserImg")!).userImg;
      },
      error: err => {
        console.log(err);
      }
    })
  }

  toggleTheme()
  {
    this.body = document.getElementById('Body')!
    this.dark = !this.dark;
    if(this.body.classList.contains('dark'))
    {
      this.body.classList.remove('dark');
      this.body.classList.add('light')
    }
    else
    {
      this.body.classList.remove('light');
      this.body.classList.add('dark')
    }
  }

  showDrop = () => {
    this.drop = !this.drop
  }

  ngOnDestroy(): void
  {
    this.userSub!.unsubscribe();
  }


  Logout(): void
  {
    localStorage.clear();
    this.router.navigateByUrl('/Register-login');
  }
}
